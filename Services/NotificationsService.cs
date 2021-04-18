using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Matterix.Data;
using Matterix.Models;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace Matterix.Services
{
    public class NotificationsService
    {
        private static bool _emailInProgress = false;
        private static bool _smsInProgress = false;
        private readonly ApplicationDbContext _context;
        private readonly IFluentEmailFactory _fluentFactory;
        private readonly PdfService _pdf;

        public NotificationsService(ApplicationDbContext context, IFluentEmailFactory fluentFactory, PdfService pdf)
        {
            _context = context;
            _fluentFactory = fluentFactory;
            _pdf = pdf;
        }

        public async Task RevokeEmail()
        {
            
            if(_emailInProgress)
                return;
            
            var notifications = await GetUnSentNotifications(EnumList.NotifyMethod.Email);

            _emailInProgress = true;


            while (notifications.Any())
            {

                foreach (var notification in notifications)
                {

                    try
                    {
                        

                        var text = ExtractText(notification.Body);
                        var mail = _fluentFactory.Create().SetFrom(StaticInformation.ContactEmail, StaticInformation.FirstName)
                            .To(notification.Email).Subject(notification.Subject)
                            .Body(notification.Body, true);
                        
                        //Add attachment in case it is applicable to this notification
                        var attachments = await Attachments(notification.Reference, notification.Type);
                        foreach (var attachment in attachments)
                        {
                            try
                            {
                                mail.Attach(attachment);
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine($"Error by adding attachment from notification {notification.Id}");
                            }
                            
                        }
                        
                            

                        


                        mail.PlaintextAlternativeBody(text);
                        await mail.SendAsync();
                        
                        
                        notification.Completed = true;
                        notification.TimeSent = Format.NorwayDateTimeNow();
                        notification.Body = text;
                        _context.Update(notification);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception e)
                    {
                        await NotificationFailure(notification, e.Message);
                        
                    }
                    
                    
                    
                }
                
                
                
                notifications = await GetUnSentNotifications(EnumList.NotifyMethod.Email);
            }


            _emailInProgress = false;

        }






        public async Task RevokeSms()
        {
            if(_smsInProgress)
                return;
            
            var notifications = await GetUnSentNotifications(EnumList.NotifyMethod.SMS);

            _smsInProgress = true;
            
            
            while (notifications.Any())
            {

                foreach (var notification in notifications)
                {

                    try
                    {

                        
                        await MessageResource.CreateAsync(
                            body: notification.Body,
                            from: new Twilio.Types.PhoneNumber(StaticInformation.FirstName),
                            to: new Twilio.Types.PhoneNumber(notification.PhoneNumber)
                        );

                        
                        
                        
                        notification.Completed = true;
                        notification.TimeSent = Format.NorwayDateTimeNow();
                        _context.Update(notification);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception e)
                    {
                        await NotificationFailure(notification, e.Message);
                    }
                    
                    
                    
                }



                notifications = await GetUnSentNotifications(EnumList.NotifyMethod.SMS);
            }


            _smsInProgress = false;
            
            
            
            
            
        }


        private async Task<List<Notification>> GetUnSentNotifications(EnumList.NotifyMethod method)
        {
            return await _context.Notifications.Where(x=>x.Method == method)
                .Where(x => !x.Completed)
                .Where(x=> x.Attempts < 3)
                .Where(x => x.TimeToSend <= Format.NorwayDateTimeNow()).ToListAsync();
        }

        private async Task NotificationFailure(Notification notification, string failureMessage )
        {
            Console.WriteLine("NOTIFICATION ERROR -------------------------------------------------------------------------");
            notification.Attempts += 1;
            if (notification.Attempts >= 3)
                notification.Body += $"\n{failureMessage}";
            _context.Update(notification);
            await _context.SaveChangesAsync();
        }

        private string ExtractText(string html)
        {
            const string patternAll = "<.+?>";
//            var patternEnd = "</.+?>";

            html = html.Replace("</p>", "\n");
            html = html.Replace("<br/>", "\n");
            html = Regex.Replace(html, patternAll, "").Trim().Replace("\n\n", "\n");
            return html;

        }


        private async Task<List<Attachment>> Attachments(string objectReference, EnumList.Notifications notification)
        {
            var attachments = new List<Attachment>();

            switch (notification)
            {
                
                case EnumList.Notifications.InvoiceReminder:
                case EnumList.Notifications.InvoiceReceipt:
                    
                    var invoice = await _context.Invoices.FindAsync(int.Parse(objectReference));
                    var courseName = _context.Courses.Find(invoice.CourseId)?.Subject;
                    var invoiceFile = _pdf.GetInvoicePdfAttachment(invoice.Number);
                    var invoiceFileName = invoice.Paid
                        ? $"Kvittering - {invoice.Number} - {courseName}.pdf"
                        : $"{invoice.InvoiceType.ToString()} - {invoice.Number} - {courseName}.pdf";
                                
                    attachments.Add(new Attachment(){Data = invoiceFile, ContentType = "application/pdf", Filename = invoiceFileName});
                    
                    
                    break;
                
                case EnumList.Notifications.PlusApplicationInvoices:
                    var applicationInvoices = _context.Invoices.Where(x => x.ApplicationId == objectReference).ToList();

                    foreach (var appInvoice in applicationInvoices)
                    {
                        var appInvoiceFile = _pdf.GetInvoicePdfAttachment(appInvoice.Number);
                        var appInvoiceFileName = $"Faktura - {appInvoice.Number}.pdf";
                        
                        attachments.Add(new Attachment(){Data = appInvoiceFile, ContentType = "application/pdf", Filename = appInvoiceFileName});
                    }
                    

                    break;
                
                
                case EnumList.Notifications.Admin:
                    //ToDo :: Check if there is an temp attachment in folder, attach it then find way to delete it
                    break;
                
                case EnumList.Notifications.CourseRegisterConfirmation:
                    var registerKeys = objectReference.Split(",").ToList();
                    if(registerKeys.Count < 2)
                        return new List<Attachment>();

                    var registration = _context.Registrations.Where(x => x.StudentId == registerKeys[1])
                        .SingleOrDefault(x => x.CourseId == registerKeys[0]);
                    
                    if(registration == null || !string.IsNullOrEmpty(registration.ApplicationId))
                        return new List<Attachment>();
                    
                    
                    var registerConfirmationFile = _pdf.RegistrationsConfirmationPdfAttachment(new List<string>{registration.CourseId}, registration.StudentId);
                    attachments.Add(new Attachment(){Data = registerConfirmationFile, ContentType = "application/pdf", Filename = "Påmeldingsbekreftelse.pdf"});

                    break;
                
                case EnumList.Notifications.PlusApplicationReceivedUser:
                    var applicationUser = _context.PlusApplications.Find(objectReference);
                    var admissionFileUser = _pdf.GetMatterixApplicationAttachment(applicationUser.Id,
                        EnumList.MatterixPlusRegDocument.Approval);
                    attachments.Add(new Attachment(){Data = admissionFileUser, ContentType = "application/pdf", Filename = "Godkjenningsdokument.pdf"});
                    break;
                case EnumList.Notifications.PlusApplicationReceivedOrg:
                    var application = _context.PlusApplications.Find(objectReference);
                    
                    var aboutSchoolFile = _pdf.GetMatterixApplicationAttachment(application.Id,
                        EnumList.MatterixPlusRegDocument.AboutSchool);
                    attachments.Add(new Attachment(){Data = aboutSchoolFile, ContentType = "application/pdf", Filename = "Litt om Matterix skole.pdf"});
                    
                    var courseDescriptionFile = _pdf.GetMatterixApplicationAttachment(application.Id,
                        EnumList.MatterixPlusRegDocument.CoursesDescription);
                    attachments.Add(new Attachment(){Data = courseDescriptionFile, ContentType = "application/pdf", Filename = "Kursbeskrivelse.pdf"});
                    
                    var admissionFile = _pdf.GetMatterixApplicationAttachment(application.Id,
                        EnumList.MatterixPlusRegDocument.Approval);
                    attachments.Add(new Attachment(){Data = admissionFile, ContentType = "application/pdf", Filename = "Godkjenningsdokument.pdf"});
                    
                    break;
                case EnumList.Notifications.PlusApplicationAccepted:
                    
                    var registrationApplication = _context.PlusApplications.Find(objectReference);

                    var courseIds = registrationApplication.CoursesIds.Split(",").ToList();
                    
                    
                    var registrationFile = _pdf.RegistrationsConfirmationPdfAttachment(courseIds, registrationApplication.StudentId);
                    attachments.Add(new Attachment(){Data = registrationFile, ContentType = "application/pdf", Filename = "Påmeldingsbekreftelse.pdf"});
                    
                    
                    break;
                case EnumList.Notifications.ImportantUpdate:
                case EnumList.Notifications.OfferAndOther:
                case EnumList.Notifications.LectureStart:
                case EnumList.Notifications.CourseUpdate:
                default:
                    return new List<Attachment>();
            }
            
            
            
            
            
            return attachments;
        }
        
        
        
    }
}