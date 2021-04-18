using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.Html2pdf;
using Matterix.Data;
using Matterix.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Services
{
    public class PdfService
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseService _course;

        public PdfService(ApplicationDbContext context, CourseService course)
        {
            _context = context;
            _course = course;
        }



        //Files can be made ...
        
        //INVOICE AND RECEIPT
        
        // PDF File
        public FileResult GetInvoicePdfFile(int invoiceNumber)
        {

            var invoice = _context.Invoices.Find(invoiceNumber);

            if (invoice == null)
                return null;
            
            var courseName = _context.Courses.Find(invoice.CourseId)?.Subject;
            

            var htmlString = "";
            
            var fileName = invoice.Paid ? $"Kvittering - {invoiceNumber} - {courseName}.pdf" : $"{invoice.InvoiceType.ToString()} - {invoiceNumber} - {courseName}.pdf";

            htmlString = !invoice.Paid ? InvoiceHtmlString(invoiceNumber) : ReceiptHtmlString(invoiceNumber);
            
            var ms = GeneratePdfFile(htmlString);

            
            var file = new FileStreamResult(ms, System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = fileName
            };
            return file;
        }
        //PDF Attachment
        public MemoryStream GetInvoicePdfAttachment(int invoiceNumber) 
        {
            var invoice = _context.Invoices.Find(invoiceNumber);

            if (invoice == null)
                return null;
            
//            var courseName = _context.Courses.Find(invoice.CourseId)?.Subject;
            

            var htmlString = "";
            
//            var fileName = invoice.Paid ? $"Kvittering - {invoiceNumber} - {courseName}.pdf" : $"{invoice.InvoiceType.ToString()} - {invoiceNumber} - {courseName}.pdf";

            htmlString = !invoice.Paid ? InvoiceHtmlString(invoiceNumber) : ReceiptHtmlString(invoiceNumber);

            return GeneratePdfFile(htmlString);
        }
        
        
        //MATTERIX PLUS
        
        //PDF File
        public FileResult GetMatterixApplicationFile(string applicationId, EnumList.MatterixPlusRegDocument plusRegDocument)
        {
            var application = _context.PlusApplications.Find(applicationId);
            if (application == null && plusRegDocument!= EnumList.MatterixPlusRegDocument.AboutSchool)
                return null;

            var fileName = "";
            var htmlString = "";

            switch (plusRegDocument)
            {
                case EnumList.MatterixPlusRegDocument.AboutSchool:
                    fileName = "Litt om Matterix skole.pdf";
                    htmlString = AboutSchoolHtmlString();
                    break;
                case EnumList.MatterixPlusRegDocument.CoursesDescription:
                    fileName = $"{application.Reference} - Kursbeksrivelse.pdf";
                    htmlString = CourseDescriptionHtmlString(applicationId);
                    break;
                case EnumList.MatterixPlusRegDocument.Approval:
                    fileName = $"{application.Reference} - Godkjenningsdokument.pdf";
                    htmlString = ApprovalHtmlString(applicationId);
                    break;
                default:
                    return null;
            }
            
            
            
            
            var ms = GeneratePdfFile(htmlString);
            
            
            
            var file = new FileStreamResult(ms, System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = fileName
            };
            return file;
            
        }
        //PDF Attachment
        
        public MemoryStream GetMatterixApplicationAttachment(string applicationId, EnumList.MatterixPlusRegDocument plusRegDocument)
        {
            var application = _context.PlusApplications.Find(applicationId);
            if (application == null)
                return null;

            var htmlString = "";

            switch (plusRegDocument)
            {
                case EnumList.MatterixPlusRegDocument.AboutSchool:
                    htmlString = AboutSchoolHtmlString();
                    break;
                case EnumList.MatterixPlusRegDocument.CoursesDescription:
                    htmlString = CourseDescriptionHtmlString(applicationId);
                    break;
                case EnumList.MatterixPlusRegDocument.Approval:
                    htmlString = ApprovalHtmlString(applicationId);
                    break;
                default:
                    return null;
            }
            
            
            
            
            return GeneratePdfFile(htmlString);
            
        }
        
        
        //REGISTRATION CONFIRMATION
        
        //PDF File
        public FileResult RegistrationsConfirmationPdfFile(List<string> coursesIds, string studentId)
        {
            var student = _context.Users.Find(studentId);
            if (student == null)
                return null;

            var fileName = $"Bekreftelse - {student.FirstName} {student.LastName}.pdf";
            var htmlString = RegistrationConfirmationHtmlString(coursesIds, studentId);

            
            
            var ms = GeneratePdfFile(htmlString);
            
           
            
            var file = new FileStreamResult(ms, System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = fileName
            };
            return file;
            
        }
        
        //PDF Attachment
        public MemoryStream RegistrationsConfirmationPdfAttachment(List<string> coursesIds, string studentId)
        {
            var student = _context.Users.Find(studentId);
            if (student == null)
                return null;

            var htmlString = RegistrationConfirmationHtmlString(coursesIds, studentId);

            
            return GeneratePdfFile(htmlString);
            
        }
        
        
        
        //Course Description With No Application
        //PDF File
        public FileResult GetCourseDescriptionWithNoApplicationFile(List<string> courseIds)
        {
            
            var fileName = "";
            var htmlString = "";
            fileName = $"Kursbeksrivelse.pdf";
            htmlString = CourseDescriptionWithNoApplicationHtmlString(courseIds);
            
            var ms = GeneratePdfFile(htmlString);
            
            var file = new FileStreamResult(ms, System.Net.Mime.MediaTypeNames.Application.Octet)
            {
                FileDownloadName = fileName
            };
            return file;
            
        }
        
        
        
        
        
        
        
        //END OF Files can be made 
        
        
        
        //Html strings can be generated ...
        private string InvoiceHtmlString(int invoiceNumber)
        {

            var invoice = _context.Invoices.Find(invoiceNumber);
            if (invoice == null || invoice.Paid)
                return string.Empty;
           
            var user = _context.Users.Find(invoice.UserId);
            if (user == null)
                return string.Empty;
            
            var name = string.IsNullOrEmpty(user.MiddleName)
                ? $"{user.FirstName} {user.LastName}"
                : $"{user.FirstName} {user.MiddleName} {user.LastName}";
            
            var address = _context.Addresses.SingleOrDefault(x => x.UserId == user.Id);
            if(address == null)
                return string.Empty;
            
            var course = _context.Courses.Find(invoice.CourseId);
            if(course == null)
                return string.Empty;
            
            var registration = _context.Registrations.Where(x=>x.CourseId == course.Id).ToList().SingleOrDefault(x=>x.StudentId == user.Id);
            if(registration == null)
                return string.Empty;

            var payments = _context.Invoices.ToList().Where(x => x.UserId == user.Id).Where(x => x.CourseId == course.Id)
                .Where(x => x.Paid).Sum(x => x.Amount);
            
            var increments = _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber).OrderBy(x=>x.Date).ToList();
            var incrementsString = "";
            var serial = 2;

            var coverString = "<div style=\"color:red; font-size: 10px;\">Studentrabatt er inkludert. Derfor kan fakturaen ikke betales eller refunderes av private eller offentlige organisasjoner (som NAV, kommuner, introduksjonssentere ... osv). Les mer om dette på www.matterix.no/plus</div>";
            var application = new MatterixPlusApplication();
            var applicationString = "";

            if (invoice.IsPlus())
            {
                payments = 0;
                increments = new List<InvoiceIncrement>();
                coverString = "";
                application = _context.PlusApplications.Find(invoice.ApplicationId);
                if (application == null)
                    return string.Empty;
                applicationString =
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px;margin-bottom:7px;margin-top:25px;\">Knyttet til en Matterix Plus søknad</div>"+
                    "<div style=\"font-size: 10px; margin-bottom:10px; \">www.matterix.no/plus/application</div>"+
        
                    "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5\">"+
                        "<tr>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Søknadsdato</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Søknadsnummer</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Passord</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Organisasjon</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Program</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Kontaktperson</th>"+
                        "</tr>"+
                        "<tr>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(application.ApplyDate)}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Reference}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.PassCode}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Organization}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Program}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.ContactPersonName}</td>" +
                        "</tr>"+
                    "</table>";
            }

            foreach (var increment in increments)
            {
                var claim = "";
                var explanation = "";

                switch (increment.Reason)
                {
                    case EnumList.IncrementReason.Latency:
                        if (increment.Type == EnumList.IncrementType.Fixed)
                        {
                            if (increment.InvoicePhase == EnumList.InvoiceType.Purring)
                            {
                                claim = "Purregebyr";
                                explanation = "Purring sent etter forsinkelsen";
                            }else if (increment.InvoicePhase == EnumList.InvoiceType.Inkassovarsel)
                            {
                                claim = "Inkassovarsel / Siste frist";
                                explanation = "Utsettelse på 15 nye dager som siste frist";
                            }
                            else if (increment.InvoicePhase == EnumList.InvoiceType.Inkasso)
                            {
                                claim = "Inkasso";
                                explanation = "Fakturaen har blitt sent til inkasso";
                            }
                            else
                            {
                                claim = "Gebyr";
                                explanation = "Forsinkelse gebyr";
                            }
                        }else
                        {
                            claim = "Inkassovarsel / Rente";
                            explanation = "Inkassovarsel / Forsinkelse rente på 8.5%";
                        }
                            
                        
                        break;
                    case EnumList.IncrementReason.Discount:
                        break;
                    case EnumList.IncrementReason.PaperInvoice:
                        claim = "Varsel på papir";
                        explanation = "Faktura sent via posten etter forsinkelsen";
                        break;
                    case EnumList.IncrementReason.Delay:
                        claim = "Utsettelse";
                        explanation = $"Betaling utsettet for {increment.Delay} dager";
                        break;
                    default:
                        break;
                }
                

                incrementsString += "<tr>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{serial}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{claim}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{explanation}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(increment.Date)}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(increment.NewDeadline)}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.NumberFormat(increment.Amount)},- kr</td>" +
                                    "</tr>";
                serial++;

            }

            var invoiceType = invoice.InvoiceType == EnumList.InvoiceType.Other || invoice.InvoiceType == EnumList.InvoiceType.Invoice? "Faktura" :
                invoice.InvoiceType == EnumList.InvoiceType.Purring ? "Faktura / Purring" : invoice.InvoiceType.ToString();

            var warning = invoice.InvoiceType == EnumList.InvoiceType.Inkassovarsel
                ? "Inkassovarsel betyr at fakturaen vil bli sendt videre til inkasso om det er ikke betalt før betalingsfrist. Dette kan utsette fakturaen for ekstra salær og renter."
                : "";

            var logo = invoice.IsPlus() ? "LogoPlus.png" : "LogoHomePage.png";
            
            
            var str=
                    "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 12px; height:1748px;\">"+
    
                    "<div style=\"width: 200px; position: absolute; left: 10px;\">"+
                $"<img src=\"https://matterix.no/Images/{logo}\" width=\"200\"/>"+
                "<table style=\"width: 100%; text-align: center\">"+
                "<tr>"+
                $"<td colspan=\"2\" style=\"font-size: 14px;\">{StaticInformation.SecondName}</td>"+
                "</tr>"+
                "<tr>"+
                "<td colspan=\"2\" style=\"font-size: 10px;\">Nettskole</td>"+
                "</tr>"+

                "<tr>"+
                $"<td colspan=\"2\">{StaticInformation.Address}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>"+
                "</tr>"+
                    "<tr>"+
                    $"<td colspan=\"2\">{StaticInformation.Website}</td>"+
                    "</tr>"+
                "</table>"+
                "</div>"+
    
                "<div style=\"width: 200px; position: absolute; right: 20px; text-align: left\">"+
                $"<div style=\"font-size: 25px; font-family: 'Noto Sans', sans-serif \">{invoiceType}</div>"+
                "<table style=\"width: 100%\">"+
                "<tr>"+
                $"<td colspan=\"2\">Kunde id:</td><td>{user.Id.Split("-")[0]}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Fakturanummer:</td><td>{invoiceNumber}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Fakturadato:</td><td>{Format.DateFormat(invoice.CreateDate)}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Forfallsdato:</td><td>{Format.DateFormat(invoice.CurrentDueDate)}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Betalingsfrist:</td><td>{Format.DateFormat(invoice.CurrentDeadline)}</td>"+
                "</tr>"+
                "</table>"+
                "</div>"+
    
    
    
                "<div style=\"margin-top: 200px; margin-left: 30px;\">"+
                $"<div style=\"font-size: 25px; font-family: 'Noto Sans', sans-serif \">{name.ToUpper()}</div>"+
                $"<div>{address.Street}, {address.ZipCode} {address.City}</div>"+
                    $"<p style=\"font-size: 18px; font-family: 'Noto Sans', sans-serif; margin-top: 20px;\">Til betaling: {Format.NumberFormat(invoice.CurrentAmount)},- kr</p>"+
                "</div>"+
                    
                    
                    "<div style=\"text-align: center;\">"+
                    
                    
                    
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px; margin-bottom:10px; margin-top:50px;\">Kursopplysninger</div>"+
        
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5\">"+
                "<tr>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Kursnavn / Kode</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Påmeldingsdato</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Gyldig til</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Kurspris</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Betalt så langt</th>"+
                "</tr>"+
            
                "<tr>"+
                $"<td style=\"padding:5px;\">{course.Subject} / {course.Code}</td>"+
                $"<td style=\"padding:5px;\">{Format.DateFormat(registration.RegisterDate)}</td>"+
                $"<td style=\"padding:5px;\">{Format.DateFormat(registration.ExpireDate)}</td>"+
                $"<td style=\"padding:5px;\">{Format.NumberFormat(registration.Price)},- kr</td>"+
                $"<td style=\"padding:5px;\">{Format.NumberFormat(payments)},- kr</td>"+
                "</tr>"+
                "</table>"+
        
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px;margin-bottom:10px; \">Fakturaopplysninger</div>"+
        
                "<table style=\"width: 100%; font-size:9px;background-color: #f5f5f5\">"+
                "<tr>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">#</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Krav</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Beskrivelse</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Dato opprettet</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">(Ny) Betalingsfrist</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Beløp</th>"+
                "</tr>"+
            
                "<tr>"+
                "<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">1</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">Faktura - {invoiceNumber}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{invoice.ExtraDescription}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(invoice.CreateDate)}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(invoice.OriginalDeadline)}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.NumberFormat(invoice.Amount)},- kr</td>"+
                "</tr>"+
                    
                    incrementsString+
                    
                    
                    "<tr>"+
                    "<th></th>"+
                    "<th style=\"padding:8px; font-size: 11px;\">Total</th>"+
                    "<th colspan=\"3\"></th>"+
                    $"<th style=\"padding:8px; font-size: 11px;\">{Format.NumberFormat(invoice.CurrentAmount)},- kr</th>"+
                    "</tr>"+
                    
                "</table>"+
                    
                    applicationString+
        
                "</div>"+
                    
                    "<div style=\"margin-top: 100px; width:250px; text-align: left\">" +
                    "<table style=\"width:100%; \">" +
                    "<tr>" +
                    "<th style=\"text-align: left; padding: 3px;\">Kontonummer:</th>"+
                    $"<td>{StaticInformation.AccountNumber}</td>"+
                    "</tr>" +
                    
                    "<tr>"+
                    "<th style=\"text-align: left;padding: 3px;\">Kidnummer:</th>"+
                    $"<td>{invoice.CIDNumber}</td>"+
                    "</tr>"+
                    
                    "<tr>"+
                    "<th style=\"text-align: left;padding: 3px;\">Beløp:</th>"+
                    $"<td>{Format.NumberFormat(invoice.CurrentAmount)},- kr</td>"+
                    "</tr>"+
                    
                    "<tr>"+
                    "<th style=\"text-align: left; padding: 3px;\">Betalingsfrist:</th>"+
                    $"<td>{Format.DateFormat(invoice.CurrentDeadline)}</td>"+
                    "</tr>"+
                    
                    "</table>" +
                    "</div>"+
                    
                    $"<p>{coverString}</p>"+
                    
                    
                    
                    $"<div style=\"text-align: center; font-size: 9px; margin-top: 10px;\">{warning}</div>"+
                    
                    
                    
                    
                    
                    
                    
                    "<div style=\"position: absolute; bottom: 0px; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                    "<tr>"+
                    $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                    "</tr>"+
                    "</table>"+
                    "</div>"+
    
    
                "</div>";
            return str;
        }
        
        private string ReceiptHtmlString(int invoiceNumber)
        {

            var invoice = _context.Invoices.Find(invoiceNumber);
            if (invoice == null || invoice.ActiveInvoice())
                return string.Empty;

            var payment = _context.Payments.SingleOrDefault(x => x.InvoiceNumber == invoiceNumber);
            if(payment == null)
                return string.Empty;
           
            var user = _context.Users.Find(invoice.UserId);
            if (user == null)
                return string.Empty;
            
            var name = string.IsNullOrEmpty(user.MiddleName)
                ? $"{user.FirstName} {user.LastName}"
                : $"{user.FirstName} {user.MiddleName} {user.LastName}";
            
            var address = _context.Addresses.SingleOrDefault(x => x.UserId == user.Id);
            if(address == null)
                return string.Empty;
            
            var course = _context.Courses.Find(invoice.CourseId);
            if(course == null)
                return string.Empty;
            
            var registration = _context.Registrations.Where(x=>x.CourseId == course.Id).SingleOrDefault(x=>x.StudentId == user.Id);
            if(registration == null)
                return string.Empty;

            var payments = _context.Invoices.Where(x => x.UserId == user.Id).Where(x => x.CourseId == course.Id)
                .Where(x => x.Paid).Sum(x => x.Amount);
            
            var increments = _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber).OrderBy(x=>x.Date).ToList();
            var incrementsString = "";
            var serial = 2;
            
            var coverString = "<div style=\"color:red; font-size: 10px;\">Studentrabatt er inkludert. Derfor kan beløpet ikke betales eller refunderes av private eller offentlige organisasjoner (som NAV, kommuner, introduksjonssentere ... osv). Les mer om dette på www.matterix.no/plus</div>";
            var application = new MatterixPlusApplication();
            var applicationString = "";

            if (invoice.IsPlus())
            {
                coverString = "";
                
                
                
                application = _context.PlusApplications.Find(invoice.ApplicationId);
                if (application == null)
                    return string.Empty;
                applicationString =
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px;margin-bottom:7px;margin-top:25px;\">Knyttet til en Matterix Plus søknad</div>"+
                    "<div style=\"font-size: 10px; margin-bottom:10px; \">www.matterix.no/plus/application</div>"+
        
                    "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5\">"+
                        "<tr>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Søknadsdato</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Søknadsnummer</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Passord</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Organisasjon</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Program</th>"+
                            "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Kontaktperson</th>"+
                        "</tr>"+
                        "<tr>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(application.ApplyDate)}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Reference}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.PassCode}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Organization}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.Program}</td>" +
                            $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{application.ContactPersonName}</td>" +
                        "</tr>"+
                    "</table>";
            }

            foreach (var increment in increments)
            {
                var claim = "";
                var explanation = "";

                switch (increment.Reason)
                {
                    case EnumList.IncrementReason.Latency:
                        if (increment.Type == EnumList.IncrementType.Fixed)
                        {
                            if (increment.InvoicePhase == EnumList.InvoiceType.Purring)
                            {
                                claim = "Purregebyr";
                                explanation = "Purring sent etter forsinkelsen";
                            }else if (increment.InvoicePhase == EnumList.InvoiceType.Inkassovarsel)
                            {
                                claim = "Inkassovarsel / Siste frist";
                                explanation = "Utsettelse på 15 nye dager som siste frist";
                            }
                            else if (increment.InvoicePhase == EnumList.InvoiceType.Inkasso)
                            {
                                claim = "Inkasso";
                                explanation = "Fakturaen har blitt sent til inkasso";
                            }
                            else
                            {
                                claim = "Gebyr";
                                explanation = "Forsinkelse gebyr";
                            }
                        }else
                        {
                            claim = "Inkassovarsel / Rente";
                            explanation = "Inkassovarsel / Forsinkelse rente på 8.5%";
                        }
                            
                        
                        break;
                    case EnumList.IncrementReason.Discount:
                        break;
                    case EnumList.IncrementReason.PaperInvoice:
                        claim = "Varsel på papir";
                        explanation = "Faktura sent via posten etter forsinkelsen";
                        break;
                    case EnumList.IncrementReason.Delay:
                        claim = "Utsettelse";
                        explanation = $"Betaling utsettet for {increment.Delay} dager";
                        break;
                    default:
                        break;
                }
                

                incrementsString += "<tr>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{serial}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{claim}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{explanation}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(increment.Date)}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(increment.NewDeadline)}</td>" +
                                    $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.NumberFormat(increment.Amount)},- kr</td>" +
                                    "</tr>";
                serial++;

            }

            var paymentMethod = payment.Method == EnumList.PaymentMethod.BankCID ? "Bankoverføring med kidnummer" :
                payment.Method == EnumList.PaymentMethod.Stripe ? "Bankkort" :
                payment.Method == EnumList.PaymentMethod.Admin || payment.Method == EnumList.PaymentMethod.Other ? "Direkte betaling til vår administrasjon" :
                payment.Method == EnumList.PaymentMethod.Vipps ? "Vipps" : "Annet";
            
            var paymentRef = payment.Id.Split("-").Any()? payment.Id.Split("-")[0] : "00000000";
            
            var logo = invoice.IsPlus() ? "LogoPlus.png" : "LogoHomePage.png";


            
            
            var htmlString=
                    "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 12px; height:1748px;\">"+
    
                    "<div style=\"width: 200px; position: absolute; left: 10px;\">"+
                $"<img src=\"https://matterix.no/Images/{logo}\" width=\"200\"/>"+
                "<table style=\"width: 100%; text-align: center\">"+
                "<tr>"+
                $"<td colspan=\"2\" style=\"font-size: 14px;\">{StaticInformation.SecondName}</td>"+
                "</tr>"+
                "<tr>"+
                "<td colspan=\"2\" style=\"font-size: 10px;\">Nettskole</td>"+
                "</tr>"+

                "<tr>"+
                $"<td colspan=\"2\">{StaticInformation.Address}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>"+
                "</tr>"+
                    "<tr>"+
                    $"<td colspan=\"2\">{StaticInformation.Website}</td>"+
                    "</tr>"+
                "</table>"+
                "</div>"+
    
                "<div style=\"width: 200px; position: absolute; right: 20px; text-align: left\">"+
                $"<div style=\"font-size: 25px; font-family: 'Noto Sans', sans-serif \">Kvittering</div>"+
                "<table style=\"width: 100%\">"+
                "<tr>"+
                $"<td colspan=\"2\">Kunde id:</td><td>{user.Id.Split("-")[0]}</td>"+
                "</tr>"+
                "<tr>"+
                $"<td colspan=\"2\">Fakturanummer:</td><td>{invoiceNumber}</td>"+
                "</tr>"+
                "</table>"+
                "</div>"+
    
    
    
                "<div style=\"margin-top: 200px; margin-left: 30px;\">"+
                $"<div style=\"font-size: 25px; font-family: 'Noto Sans', sans-serif \">{name.ToUpper()}</div>"+
                $"<div>{address.Street}, {address.ZipCode} {address.City}</div>"+
                    $"<p style=\"font-size: 14px; font-family: 'Noto Sans', sans-serif; margin-top: 20px;\">Bekreftelse på at du har betalt denne fakturaen på: {Format.NumberFormat(payment.Amount)},- kr</p>"+
                "</div>"+
                    
                    
                    "<div style=\"text-align: center;\">"+
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px; margin-bottom:10px; margin-top:50px;\">Kursopplysninger</div>"+
        
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5\">"+
                "<tr>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Kursnavn / Kode</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Påmeldingsdato</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Gyldig til</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Kurspris</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;\">Betalt så langt</th>"+
                "</tr>"+
            
                "<tr>"+
                $"<td style=\"padding:5px;\">{course.Subject} / {course.Code}</td>"+
                $"<td style=\"padding:5px;\">{Format.DateFormat(registration.RegisterDate)}</td>"+
                $"<td style=\"padding:5px;\">{Format.DateFormat(registration.ExpireDate)}</td>"+
                $"<td style=\"padding:5px;\">{Format.NumberFormat(registration.Price)},- kr</td>"+
                $"<td style=\"padding:5px;\">{Format.NumberFormat(payments)},- kr</td>"+
                "</tr>"+
                "</table>"+
        
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px;margin-bottom:10px; \">Fakturaopplysninger</div>"+
        
                "<table style=\"width: 100%; font-size:9px;background-color: #f5f5f5\">"+
                "<tr>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">#</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Krav</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Beskrivelse</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Dato opprettet</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">(Ny) betalingsfrist</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;\">Beløp</th>"+
                "</tr>"+
            
                "<tr>"+
                "<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">1</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">Faktura - {invoiceNumber}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{invoice.ExtraDescription}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(invoice.CreateDate)}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.DateFormat(invoice.OriginalDeadline)}</td>"+
                $"<td style=\"border-bottom: 0.01rem solid #D3D3D3; padding:5px;\">{Format.NumberFormat(invoice.Amount)},- kr</td>"+
                "</tr>"+
                    
                    incrementsString+
                    
                    
                    "<tr>"+
                    "<th></th>"+
                    "<th style=\"padding:8px; font-size: 11px;\">Total</th>"+
                    "<th colspan=\"3\"></th>"+
                    $"<th style=\"padding:8px; font-size: 11px;\">{Format.NumberFormat(invoice.CurrentAmount)},- kr</th>"+
                    "</tr>"+
                    
                "</table>"+
        
                "</div>"+
                    
                    "<div style=\"margin-top: 100px; width:350px; text-align: left\">" +
                    "<table style=\"width:100%; \">" +
                    "<tr>" +
                    "<th style=\"text-align: left; padding: 3px;\">Betalingsdato:</th>"+
                    $"<td>{Format.DateFormat(payment.DateTime)}</td>"+
                    "</tr>" +
                    
                    "<tr>"+
                    "<th style=\"text-align: left;padding: 3px;\">Betalingsmetode:</th>"+
                    $"<td>{paymentMethod}</td>"+
                    "</tr>"+
                    
                    "<tr>"+
                    "<th style=\"text-align: left; padding: 3px;\">Betalingsreferanse:</th>"+
                    $"<td>{paymentRef}</td>"+
                    "</tr>"+
                    
                    "<tr>"+
                    "<th style=\"text-align: left;padding: 3px;\">Beløp:</th>"+
                    $"<td>{Format.NumberFormat(payment.Amount)},- kr</td>"+
                    "</tr>"+
                    
                    "</table>" +
                    "</div>"+
                    $"<p>{coverString}</p>"+
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    "<div style=\"position: absolute; bottom: 0px; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                    "<tr>"+
                    $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                    "</tr>"+
                    "</table>"+
                    "</div>"+
    
    
                "</div>";
            return htmlString;
        }

        private string AboutSchoolHtmlString()
        {
            
            var str=
                    
                "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 12px; min-height:1748px;\">"+
    
                    "<div style=\"width: 200px; left: 10px;\">"+
                    "<img src=\"https://matterix.no/Images/LogoHomePage.png\" width=\"200\"/>"+
                    "<table style=\"width: 100%; text-align: center\">"+
                        "<tr>"+
                            $"<td colspan=\"2\" style=\"font-size: 14px;\">{StaticInformation.SecondName}</td>"+
                        "</tr>"+
                        "<tr>"+
                            "<td colspan=\"2\" style=\"font-size: 10px;\">Nettskole</td>"+
                        "</tr>"+

                        "<tr>"+
                            $"<td colspan=\"2\">{StaticInformation.Address}</td>"+
                        "</tr>"+
                        "<tr>"+
                             $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>"+
                        "</tr>"+
                        "<tr>"+
                            $"<td colspan=\"2\">{StaticInformation.Website}</td>"+
                        "</tr>"+
                     "</table>"+
                "</div>"+
                
                
                
//                "<div style=\"margin-top: 180px; margin-left: 40px;font-size: 10px;\">"+
//                    "<div>Dette dokumentet er vedlagt sammen med en Matterix Plus påmeldingssøknad til å opplyse litt om Matterix skole.</div>"+
//                    $"<div>Hvis du er allerede kjent med Matterix, vennligst ignorer dette dokumentet.</div>"+
//                "</div>"+
                
    
    
                
                    
                    
                "<div style=\"text-align: center;\">"+
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 16px; margin-bottom:10px; margin-top:50px;\">Litt om Matterix Skole</div>"+
                
                    "<div style=\"margin-top: 30px; margin-left: 40px; text-align: justify\">"+
                
                        "<p>Matterix er en nettskole som startet opp i 2017, som underviser norske fag på videregående (og andre) nivåer, i tillegg til noen grunnkurs i ulike emner, på det arabiske språket (med å ta hensyn til det norske språket) for arabisktalende som bor i Norge.</p>"+
                        "<p>Undervisningen skjer direkte (live online) via en profesjonell plattform; det vil si at studentene har mulighet til å stille spørsmål og diskutere med lærerne underveis i leksjonene.</p>"+
                        "<p>Læreren viser en digital tavle i leksjonene, som alle studenter kan delta med å skrive på mens læreren forklarer. Studentene kan stille spørsmål med direkte chatt i det digitale klasserommet, eller med å bruke mikrofonen for de som ønsker.</p>"+
                        "<p>Alle våre kurs foregår direkte på nett på kveldstid, dermed kan alle studenter få hjelpen de trenger mens de sitter hjemme.</p>"+
                        "<p>Det er obligatorisk at studenter skal møte opp på leksjonene til bestemte tidspunkter, men om man mister noe, er alle leksjonene tatt opp og kan re-kjøres igjen når som helst.</p>"+
                        "<p>Det er også mulig at studenten kan melde seg på noen kurs fra forrige semestre som er allerede fullførte. Dermed kan studenten følge opp med leksjonene som ble tatt opp av kurset og vil få tilgang til alle resurser av kurset.</p>"+
                        "<p>Det er også såkalt kurs chatt hvor studentene kan møtes, samarbeide på oppgaver, eller få hjelp av læreren utenfor leksjonstider.</p>"+
                        "<p>Vi dekker hele pensum i de fleste fag. Dermed kan en student ved å følge våre kurs bli klar til å ta en eksamen, men samtidig kan man bruke kursene bare som en ekstra hjelp.</p>"+
                        "<p>Vi følger opp studentene med innleveringer i hele kursperiode, og gir karakter og tilbakemeldinger som hjelper studenten å forbedre seg selv.</p>"+
                        "<p>Vi setter søkelys på eksamensoppgaver og eksempler slik at vi sørger for at studenten er 100% klar til å gå opp til eksamenen.</p>"+
                        "<p>Vi gir mulighet til alle studenter å avbryte sine påmeldinger 14 dager fra startdato etter lovverk tilknyttet «Angrerett» uten noen kostnader.</p>"+
                        
                    "</div>"+
        
                
        
                
                    
                    "<div style=\"position: absolute; bottom: 0px; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                    "<tr>"+
                    $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                    "</tr>"+
                    "</table>"+
                    "</div>"+
    
    
                "</div>";
            return str;

        }

        private string ApprovalHtmlString(string applicationId)
        {
            var application = _context.PlusApplications.Where(x => x.Id == applicationId).Include(x => x.Student)
                .SingleOrDefault();

            if (application == null || string.IsNullOrEmpty(application.CoursesIds))
                return string.Empty;

            var studentName = string.IsNullOrEmpty(application.Student.MiddleName)? $"{application.Student.FirstName} {application.Student.LastName}" : $"{application.Student.FirstName} {application.Student.MiddleName} {application.Student.LastName}";
            var studentPhone = $"{application.Student.PhoneCode} - {application.Student.PhoneNumber}";
            var birthDate = Format.DateFormat(application.Student.BirthDate);
            var applierName = application.Applier == "Student" ? studentName : application.ContactPersonName;

            var courses = new List<Course>();
            var coursesString = "";

            var courseIds = application.CoursesIds?.Split(",");
            if (courseIds == null || courseIds.Length == 0)
                return string.Empty;

            
            
            var coursesTable =
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5;\">"+
                "<tr>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">#</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Kursnavn / Kode</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Status</th>"+
                "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Pris</th>"+
                "</tr>";



            var totalAmount = 0;
            var courseCount = 1;
            foreach (var courseId in courseIds)
            {
                var course = _context.Courses.Find(courseId);
                if(course == null)
                    continue;
                courses.Add(course);
                coursesString += $"<span style=\"margin-left:15px;\">({courseCount}) {course.Subject}.</span>";
                totalAmount += Format.GetPlusPrice(course.Price);
                
                
                
                
                
                var days = (int) Math.Round(course.StartDate.Subtract(DateTime.Now).TotalDays + 0.4);
                var startedAt = days > 0 ? "Starter om" : "begynte for";
                var ago = days > 0 ? "" : "siden";
                days = Math.Abs(days);
                var months = 0;
                while (days > 30)
                {
                    months++;
                    days -= 30;
                }

                var daysString = days == 0 ? "" : days == 1 ? $"{days} dag" : $"{days} dager";
                var monthsString = months == 0 ? "" : months == 1 ? $"{days} måned" : $"{months} måneder";

                var and = "og";
    
                if (days + months == 0)
                {
                    startedAt = "starter i dag";
                    daysString = and = monthsString = "";
        
                }else if (days * months == 0)
                {
                    and = "";
                }


                var status = course.Ended ? "Fullført" : $"{startedAt} {monthsString} {and} {daysString} {ago}";
                
                
                
                
                
                

                coursesTable += "<tr>" +
                                $"<td style=\"padding:5px;\">{courseCount}</td>" +
                                $"<td style=\"padding:5px;\">{course.Subject} / {course.Code}</td>" +
                                $"<td style=\"padding:5px;\">{status}</td>" +
                                $"<td style=\"padding:5px;\">{Format.NumberFormat(Format.GetPlusPrice(course.Price))},- kr</td>" +
                                "</tr>";
                courseCount++;
            }

            coursesTable += "</table>";


            
            


            var str =

                    "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 11px;\">" +

                    "<div style=\"width: 200px;\">" +
                    "<img src=\"https://matterix.no/Images/LogoPlus.png\" width=\"200\"/>" +
                    "<table style=\"width: 100%; text-align: center\">" +
                    "<tr>" +
                    $"<td colspan=\"2\" style=\"font-size: 13px;\">{StaticInformation.SecondName}</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td colspan=\"2\" style=\"font-size: 9px;\">Nettskole</td>" +
                    "</tr>" +

                    "<tr>" +
                    $"<td colspan=\"2\">{StaticInformation.Address}</td>" +
                    "</tr>" +
                    "<tr>" +
                    $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>" +
                    "</tr>" +
                    "<tr>" +
                    $"<td colspan=\"2\">{StaticInformation.Website}</td>" +
                    "</tr>" +
                    "</table>" +
                    "</div>" +



                    
                    $"<div style=\"margin-top: 10px; margin-left: 570px; font-size: 9px;\">Dato: {Format.DateFormat(application.ApplyDate)}</div>" +
                    






                    "<div style=\"text-align: center;\">" +
                        "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 15px; margin-bottom:10px; margin-top:20px;font-weight: bold;\">Påmeldingssøknad hos Matterix skole</div>" +
                        $"<div style=\"font-family: 'Noto Sans', sans-serif; margin-bottom:10px;\">Til godkjenning av {application.Organization}</div>" +
                    "</div>"+

                    "<div style=\"margin-top: 25px; margin-left: 20px; text-align: justify\">" +

                    $"<div style=\"margin-bottom: 7px;\">Vi har fått en søknad fra {studentName} med fødselsdato: {birthDate} om å delta på kurs ved vår nettskole. Søkeren ønsker å få kursavgiften dekket av: {application.Organization}</div>" +
                    
                    $"<div style=\"margin-bottom: 7px;\">Søkeren ønsker følgende kurs: {coursesString}</div>"+
                    
                    
                    $"<div style=\"margin-bottom: 7px;\">Dermed trenger vi {application.Organization}s godkjenning med signatur på dette dokumentet før vi kan behandle søknaden.</div>" +
                    
                    "<div style=\"font-size: 10px;>Les mer om dette på www.matterix.no/plus</div>"+

                    "</div>" +



                    "<div style=\"margin-left: 20px; text-align: justify;\">" +

                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Dokumenter knyttet til søknaden:</div>" +
                    "<div style=\"margin-left: 20px;\">" +
                        "<div style=\"margin-bottom: 7px;\">-	Litt om Matterix skole.pdf</div>" +
                        "<div style=\"margin-bottom: 7px;\">-	Kursbeskrivelse.pdf</div>" +
                        "<div style=\"margin-bottom: 7px;\">-	Godkjenningsdokument.pdf (dette dokumentet)</div>" +
                    "</div>" +
                    "<p style=\"font-size: 9px;\">Dette er sendt via epost til både deltakeren og kontaktpersonen. Dokumentene kan også hentes via søknadstilgangsinfo.</p>" +




                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Søknadsinfo:</div>" +
                    $"<div style=\"margin-bottom: 7px;\">Sendt inn: {Format.DateFormat(application.ApplyDate)} av {applierName}</div>"+
                    "<div style=\"margin-bottom: 7px;\">Søknadstilgangslenke: https://matterix.no/plus/application</div>"+
                    $"<div style=\"margin-bottom: 7px;\"><span>Søknadsnummer: {application.Reference}</span><span style=\"margin-left: 25px;\">Passord: {application.PassCode}</span></div>"+
                    "<div style=\"font-size:9px;\">Bruk søknadstilgangsinfo til å hente søknadsfiler eller til å laste opp godkjenningsdokumenter</div>"+
                    
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Deltakersopplysninger (student):</div>" +
                    $"<div style=\"margin-bottom: 7px;\"><span>Navn: {studentName}</span><span style=\"margin-left: 25px;\">Fødselsdato: {birthDate}</span><span style=\"margin-left: 25px;\">Telefon: {studentPhone}</span></div>"+
                    $"<div style=\"margin-bottom: 7px;\">Epost: {application.Student.Email}</div>"+
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Kontaktpersonsopplysninger (Saksbehandler hos dere):</div>" +
                    $"<div style=\"margin-bottom: 7px;\"><span>Navn: {application.ContactPersonName}</span><span style=\"margin-left: 25px;\">Organisasjon: {application.Organization}</span><span style=\"margin-left: 25px;\">Kvalifiseringsprogram: {application.Program}</span></div>"+
                    $"<div style=\"margin-bottom: 7px;\"><span>Telefon: {application.ContactPersonPhone}</span><span style=\"margin-left: 25px;\">Epost: {application.ContactPersonEmail}</span></div>"+
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Kurs som denne søknaden gjelder:</div>" +
                    coursesTable+
                    "<div style=\"margin-left: 20px;margin-bottom: 7px;\">Mer info om kurs finner du i Kursbeskrivelse dokumentet.</div>"+
                    
                    
//                    <table style=\"margin-bottom: 7px;\"><tr><td></td><td></td></tr></table>
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Ved godkjenning av søknad:</div>" +
                    "<div style=\"margin-left: 20px;\">"+
                        "<div style=\"margin-bottom: 7px;\">-	Om dere godkjenner søknaden må dette dokumentet signeres av dere.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Etter signering kan filen lastes opp direkte til vår portal (bruk søknadstilgangsinfo) eller sendes via epost.</div>"+
                        $"<div style=\"margin-bottom: 7px;\">-	Søknaden vil bli behandlet av oss så raskt som mulig og en faktura på {totalAmount},- kr vil bli sendt til dere.</div>"+    
                        "<div style=\"margin-bottom: 7px;\">-	Studenten er ikke pliktig til å betale noen kostnader.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Studenten vil bli registrert og påmeldingen vil bli aktiv for alle kurs som søknaden gjelder.</div>"+
                    "</div>"+
                    
                    
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Angrerett etter søknadsgodkjenning:</div>" +
                    "<div style=\"margin-left: 20px;\">"+
                        "<div style=\"margin-bottom: 7px;\">-	Angreretten kan benyttes til å avbryte påmeldingen i ett eller flere kurs som søknaden gjelder.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Angreretten kan kun benyttes innen 14 dager fra søknadsbehandlingsdato eller fra kursstartdato hvis søknaden ble behandlet før kurs har startet.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Angreretten kan benyttes av deltakeren (studenten) eller saksbehandleren/kontaktpersonen hos dere.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Ved bruk av angreretten må vi få skriftlig beskjed av dere (organisasjonen eller saksbehandleren).</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Om beløpet allerede er betalt og angreretten benyttes, vil hele beløpet for det/de avbrutte kurs bli refundert innen 15 dager til den bankkontoen det opprinnelig ble betalt fra.</div>"+
                    "</div>"+
                    
                    
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Ved avvisning av søknad:</div>" +
                    "<div style=\"margin-left: 20px;\">"+
                        "<div style=\"margin-bottom: 7px;\">-	Påmeldingsforespørsel vil bli kansellert hos oss.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Studenten er ikke pliktig til å betale noen kostnader.</div>"+
                        "<div style=\"margin-bottom: 7px;\">-	Om studenten vil fortsette med påmeldingen likevel og dekke skolepenger selv, vil studentrabatt bli beregnet.</div>"+    
                    "</div>"+
                    
                    
                    
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Organisasjonen og Saksbehandler:</div>" +
                    "<div style=\"margin-bottom: 7px;\">Om opplysninger er det samme som står ved Kontaktpersonsopplysninger kan du slippe å fille ut dette skjemaet.</div>"+
                    "<div style=\"margin-bottom: 7px;\"><table style=\"width: 100%;\"><tr><td style=\"padding: 5px;\">Organisasjonsnavn: ……………………………………..</td><td style=\"padding: 5px;\">Kvalifiseringsprogram: ……………………………………..</td></tr>  <tr><td style=\"padding: 5px;\">Saksbehandlernavn: ……………………………………..</td><td style=\"padding: 5px;\">Epost: ……………………………………..................</td></tr></table></div>"+
                  
                    
                    
                    
                    
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px;font-weight: bold;\">Godkjenning av søknad:</div>" +
                    "<div style=\"margin-bottom: 30px;\"><table><tr><td><input type=\"checkbox\"/></td><td>Jeg har lest gjennom dokumentene knyttet til søknaden og jeg samtykker i innholdet.</td></tr></table></div>"+
                    "<div style=\"margin-bottom: 15px;\"><table style=\"width: 100%;\"><tr><td>Sted / Dato: ……………………………………..</td><td>Signatur: ……………………………………..</td></tr></table></div>"+
                    
                    
                
                

                    
                
                
                
                
                
                    "</div>"+
                    
                
                    
                    
                
                    
        
                
        
                
                    
                    "<div style=\"margin-top:120px; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                    "<tr>"+
                    $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                    "</tr>"+
                    "</table>"+
                    "</div>"+
    
                "</div>";
            return str;
        }

        private string CourseDescriptionHtmlString(string applicationId)
        {
            
            var application = _context.PlusApplications.Where(x => x.Id == applicationId).Include(x => x.Student)
                .SingleOrDefault();

            if (application == null || string.IsNullOrEmpty(application.CoursesIds))
                return string.Empty;
            
            var courses = new List<Course>();
            var courseTable = "";
            var courseString = "<div>"; //ToDo :: Add style

            var courseIds = application.CoursesIds?.Split(",");
            if (courseIds == null || courseIds.Length == 0)
                return string.Empty;
            
            var courseCount = 1;
            
            foreach (var courseId in courseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course == null)
                    continue;
                
                courses.Add(course);

                var schedules = _context.Schedules.Where(x => x.CourseId == courseId).ToList();

                var status = course.Ended ? "Fullført" : "Direkte";
                var lecturesWeek = course.Ended? "-" : schedules.Count.ToString();
                var language = course.Language == EnumList.Language.Arabic ? "arabiske" :
                    course.Language == EnumList.Language.English ? "engelske" : "norske";
                
                courseTable +=
                    "<tr>" +
                        $"<td style=\"text-align: center\">{courseCount}</td>"+
                        $"<td>{course.Subject} / {course.Code}</td>"+
                        $"<td style=\"text-align: center\">{status}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.StartDate)}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.EndDate)}</td>"+
                        $"<td style=\"text-align: center\">{lecturesWeek}</td>"+
                        $"<td style=\"text-align: center\">{Math.Round(_course.ExpectedTotalHours(courseId), 1)}</td>"+
                    "</tr>"
                    ;

                var courseDiv = "<div style=\"margin-bottom: 15px\">";


                if (!course.Ended)
                {
                    var start = course.StartDate >= Format.NorwayDateNow() ? "Det begynner den" : "Det begynte den ";
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                            $"{courseCount}- Kurset, {course.Subject}, undervises på det {language} språket. " +
                            $"{start} {Format.DateFormat(course.StartDate)} og skal foregå direkte frem til den {Format.DateFormat(course.EndDate)} med {schedules.Count} leksjoner i uken etter følgende timeplan:"+
                        "</div>";

                    foreach (var schedule in schedules)
                    {
                        courseDiv +=
                            $"<div style=\"margin-bottom: 5px\">{Format.TranslateDay(schedule.Day, EnumList.Language.Norwegian)}: fra {Format.TimeFormat(schedule.From)} til {Format.TimeFormat(schedule.To)}</div>";

                    }

                    

                    


                }
                else
                {
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                        $"{courseCount}- Kurset, {course.Subject}, underviste på det {language} språket. Det er allerede fullført, og det ble gjort opptak av alle leksjonene. Dermed kan studenten sette opp sin egen timeplan etter egne ønsker om varighet av hver økt og nyte resurser av kurset."+
                        "</div>";
                }
                
                
                
                
                if (string.IsNullOrEmpty(course.Goal))
                {
                    courseDiv+= "<div style=\"margin-bottom: 5px\">Målet med kurset er å lære hele pensumet, og sørge for at studenten blir 100% klar til å gå opp til eksamen i faget.</div>";
                }
                else
                {
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">{course.Goal}</div>";
                }
                    
                if(course.Language == EnumList.Language.English){
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">En arabisk studentassistent er med på alle leksjonene ved siden av en amerikansk lærer.</div>";
                }
                
                
                
                
                
                
                
                courseDiv += "</div>";



                courseString += courseDiv;
                
                
                

                courseCount++;
            }





            var str =

                //main div
                "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 11px;min-height:1748px\">" +
                
                //header
                "<div style=\"width: 200px;\">" +
                    "<img src=\"https://matterix.no/Images/LogoPlus.png\" width=\"200\"/>" +
                    "<table style=\"width: 100%; text-align: center\">" +
                        "<tr>" +
                            $"<td colspan=\"2\" style=\"font-size: 13px;\">{StaticInformation.SecondName}</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td colspan=\"2\" style=\"font-size: 9px;\">Nettskole</td>" +
                        "</tr>" +

                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Address}</td>" +
                        "</tr>" +
                
                        "<tr>" +
                            $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>" +
                        "</tr>" +
                        
                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Website}</td>" +
                        "</tr>" +
                    "</table>" +
                "</div>" +
                //End of header
                
                
                //Date
                $"<div style=\"margin-top: 10px; margin-left: 570px; font-size: 9px;\">Dato: {Format.DateFormat(application.ApplyDate)}</div>" +
                
                
                //Title
                "<div style=\"text-align: center;\">" +
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 15px; margin-bottom:10px; margin-top:20px;font-weight: bold;\">Kursbeskrivelse</div>" +
                    $"<div style=\"font-family: 'Noto Sans', sans-serif; margin-bottom:10px;\">Gjelder søknadsnummer: {application.Reference}</div>" +

                    "<div style=\"margin-top: 25px;text-align: left\">" +

                        $"<div style=\"margin-bottom: 7px;\">Dette dokumentet opplyser rundt kursene som søknaden gjelder.</div>" +
                    
                    "</div>"+

                "</div>" +
                //End of title
                
                
                //Body parts
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Søknadsinfo:</div>" +
                "<div style=\"margin-bottom: 7px;\">Søknadstilgangslenk: https://matterix.no/plus/application</div>"+
                $"<div style=\"margin-bottom: 7px;\"><span>Søknadsnummer: {application.Reference}</span><span style=\"margin-left: 25px;\">Passord: {application.PassCode}</span></div>"+
                "<div style=\"font-size:9px;\">Mer info om søknaden finner du i filen Godkjenningsdokument.pdf</div>"+
                
                
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Kurs:</div>" +
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5;\">"+
                    "<tr>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">#</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Kursnavn / Kode</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Status</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Startdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Sluttdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Leksjoner i uke</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Tot. antall timer</th>"+
                        
                    "</tr>"+
                
                    courseTable+
                    
                "</table>"+
                
                courseString+
                
                
                
                


                //Footer
                "<div style=\"position:absolute; bottom: 0; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                        "<tr>"+
                            $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                        "</tr>"+
                    "</table>"+
                "</div>"+
                
                
                
                
                
                
                
                //end of main div
                "</div>";
            
            
            
            return str;
        }

        private string RegistrationConfirmationHtmlString(List<string> coursesIds, string studentId)
        {

            var registrations = new List<Registration>();
            var student = _context.Users.Find(studentId);

            foreach (var courseId in coursesIds)
            {
                var registration = _context.Registrations.Where(x=>x.StudentId == studentId).Where(x=>x.CourseId==courseId).Include(x=>x.Course).SingleOrDefault();
                if(registration == null)
                    continue;
                registrations.Add(registration);

            }

            registrations = registrations.OrderBy(x => x.RegisterDate).ToList();
            

            if (student == null || registrations.Count == 0)
                return string.Empty;

            var studentName = string.IsNullOrEmpty(student.MiddleName)? $"{student.FirstName} {student.LastName}" : $"{student.FirstName} {student.MiddleName} {student.LastName}";
            var genderRef = student.Gender == EnumList.Gender.Male ? "Han" : "Hun";
            
            

            var courseTable = "";
            var courseString = "";
            var registrationTable = "";
            var courseCount = 1;
            foreach (var reg in registrations)
            {
                var course = reg.Course;
                var schedules = _context.Schedules.Where(x => x.CourseId == reg.CourseId).ToList();
                var status = course.Ended ? "Fullført" : "Direkte";
                var lecturesWeek = course.Ended? "-" : schedules.Count.ToString();
                var language = course.Language == EnumList.Language.Arabic ? "Arabisk" :
                    reg.Course.Language == EnumList.Language.English ? "Engelsk" : "Norsk";
                var payer = string.IsNullOrEmpty(reg.ApplicationId)
                    ? "Student"
                    : _context.PlusApplications.Find(reg.ApplicationId)?.Organization;
                
                courseTable +=
                    "<tr>" +
                        $"<td style=\"text-align: center\">{courseCount}</td>"+
                        $"<td>{course.Subject} / {course.Code}</td>"+
                        $"<td style=\"text-align: center\">{language}</td>"+
                        $"<td style=\"text-align: center\">{status}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.StartDate)}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.EndDate)}</td>"+
                        $"<td style=\"text-align: center\">{lecturesWeek}</td>"+
                        $"<td style=\"text-align: center\">{Math.Round(_course.ExpectedTotalHours(reg.CourseId), 1)}</td>"+
                    "</tr>"
                    ;
                
                registrationTable +=
                    "<tr>" +
                        $"<td style=\"text-align: center\">{courseCount}</td>"+
                        $"<td>{course.Code}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(reg.RegisterDate)}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(reg.ExpireDate)}</td>"+
                        $"<td style=\"text-align: center\">{Format.NumberFormat(reg.Price)},- kr</td>"+
                        $"<td style=\"text-align: center\">{payer}</td>"+
                    "</tr>"
                    ;
                
                
                
                
                var courseDiv = "<div style=\"margin-bottom: 15px\">";


                if (!course.Ended)
                {
                    var start = course.StartDate >= Format.NorwayDateNow() ? "Det begynner den" : "Det begynte den";
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                            $"{courseCount}- Kurset, {course.Subject}, undervises på det {language.ToLower()}e språket. " +
                            $"{start} {Format.DateFormat(course.StartDate)} og skal foregå direkte frem til den {Format.DateFormat(course.EndDate)} med {schedules.Count} leksjoner i uken etter timeplanen:"+
                        "</div>";

                    foreach (var schedule in schedules)
                    {
                        courseDiv +=
                            $"<div style=\"margin-bottom: 5px\">{Format.TranslateDay(schedule.Day, EnumList.Language.Norwegian)}: fra {Format.TimeFormat(schedule.From)} til {Format.TimeFormat(schedule.To)}</div>";

                    }

                    

                    


                }
                else
                {
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                        $"{courseCount}- Kurset, {course.Subject}, underviste på det {language.ToLower()}e språket. Det er allerede fullført, og det ble gjort opptak av alle leksjonene. Dermed kan studenten sette opp sin egen timeplan etter egne ønsker om varighet av hver økt og nyte resurser av kurset."+
                        "</div>";
                }
                
                
                
                
                if (string.IsNullOrEmpty(course.Goal))
                {
                    courseDiv+= "<div style=\"margin-bottom: 5px\">Målet av kurset er å lære hele pensumet og sørge for at studenten blir 100% klar til å gå opp til eksamenen i faget.</div>";
                }
                else
                {
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">{course.Goal}</div>";
                }
                    
                if(course.Language == EnumList.Language.English){
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">En arabisk studentassistent er med på alle leksjonene ved siden av en amerikansk lærer.</div>";
                }
                
                
                
                
                
                
                
                courseDiv += "</div>";



                courseString += courseDiv;
                
                
                
                courseCount++;
            }
            
            
            
            
            var str =

                //main div
                "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 11px; min-height:1748px;\">" +
                
                //header
                "<div style=\"width: 200px;\">" +
                    "<img src=\"https://matterix.no/Images/LogoHomePage.png\" width=\"200\"/>" +
                    "<table style=\"width: 100%; text-align: center\">" +
                        "<tr>" +
                            $"<td colspan=\"2\" style=\"font-size: 13px;\">{StaticInformation.SecondName}</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td colspan=\"2\" style=\"font-size: 9px;\">Nettskole</td>" +
                        "</tr>" +

                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Address}</td>" +
                        "</tr>" +
                
                        "<tr>" +
                            $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>" +
                        "</tr>" +
                        
                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Website}</td>" +
                        "</tr>" +
                    "</table>" +
                "</div>" +
                //End of header
                
                
                //Date
                $"<div style=\"margin-top: 10px; margin-left: 550px; font-size: 9px;\">Dato generert: {Format.DateFormat(Format.NorwayDateNow())}</div>" +
                
                
                //Title
                "<div style=\"text-align: center;\">" +
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 15px; margin-bottom:10px; margin-top:20px;font-weight: bold;\">Påmeldingsbekreftelse</div>" +
                    
                    "<div style=\"margin-top: 25px;text-align: left\">" +

                        $"<div style=\"margin-bottom: 7px;\">Matterix nettskole bekrefter herved at {studentName} ({Format.DateFormat(student.BirthDate)}) er registrert som student hos oss. {genderRef} tar følgende fag:</div>" +
                    
                    "</div>"+

                "</div>" +
                //End of title
                
                
                //Body parts
                
                //Course table
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5;\">"+
                    "<tr>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">#</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Kursnavn / Kode</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Språk</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Status</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Startdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Sluttdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Leksjoner i uke</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Tot. antall timer</th>"+
                        
                    "</tr>"+
                
                    courseTable+
                    
                "</table>"+
                
                
                //Course info and schedule
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Kursinfo:</div>" +
                courseString+
                
                
                //Registration info
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Påmeldingsinfo:</div>" +
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5;\">"+
                    "<tr>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">#</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Kurs</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Påmeldingsdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Aktiv til</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Kostnad</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Dekkes av</th>"+
                        
                    "</tr>"+
                
                    registrationTable+
                    
                "</table>"+
                

                
                
                
                


                //Footer
                "<div style=\"position: absolute; bottom: 0; margin-top:50px; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                        "<tr>"+
                            $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                        "</tr>"+
                    "</table>"+
                "</div>"+
                
                
                
                
                
                
                
                //end of main div
                "</div>";
            
            
            
            return str;



        }
        
        
        private string CourseDescriptionWithNoApplicationHtmlString(List<string> courseIds)
        {
            
            if (courseIds.Count < 1)
                return string.Empty;
            
            var courses = new List<Course>();
            var courseTable = "";
            var courseString = "<div>"; //ToDo :: Add style

            
            
            var courseCount = 1;
            
            foreach (var courseId in courseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course == null)
                    continue;
                
                courses.Add(course);

                var schedules = _context.Schedules.Where(x => x.CourseId == courseId).ToList();

                var status = course.Ended ? "Fullført" : "Direkte";
                var lecturesWeek = course.Ended? "-" : schedules.Count.ToString();
                var language = course.Language == EnumList.Language.Arabic ? "arabiske" :
                    course.Language == EnumList.Language.English ? "engelske" : "norske";
                
                courseTable +=
                    "<tr>" +
                        $"<td style=\"text-align: center\">{courseCount}</td>"+
                        $"<td>{course.Subject} / {course.Code}</td>"+
                        $"<td style=\"text-align: center\">{status}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.StartDate)}</td>"+
                        $"<td style=\"text-align: center\">{Format.DateFormat(course.EndDate)}</td>"+
                        $"<td style=\"text-align: center\">{lecturesWeek}</td>"+
                        $"<td style=\"text-align: center\">{Math.Round(_course.ExpectedTotalHours(courseId), 1)}</td>"+
                    $"<td style=\"text-align: center\">{Format.GetPlusPrice(course.Price)},- kr</td>"+
                    "</tr>"
                    ;

                var courseDiv = "<div style=\"margin-bottom: 15px\">";


                if (!course.Ended)
                {
                    var start = course.StartDate >= Format.NorwayDateNow() ? "Det begynner den" : "Det begynte den ";
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                            $"{courseCount}- Kurset, {course.Subject}, undervises på det {language} språket. " +
                            $"{start} {Format.DateFormat(course.StartDate)} og skal foregå direkte frem til den {Format.DateFormat(course.EndDate)} med {schedules.Count} leksjoner i uken etter følgende timeplan:"+
                        "</div>";

                    foreach (var schedule in schedules)
                    {
                        courseDiv +=
                            $"<div style=\"margin-bottom: 5px\">{Format.TranslateDay(schedule.Day, EnumList.Language.Norwegian)}: fra {Format.TimeFormat(schedule.From)} til {Format.TimeFormat(schedule.To)}</div>";

                    }

                    

                    


                }
                else
                {
                    courseDiv +=
                        "<div style=\"margin-bottom: 5px\">" +
                        $"{courseCount}- Kurset, {course.Subject}, underviste på det {language} språket. Det er allerede fullført, og det ble gjort opptak av alle leksjonene. Dermed kan studenten sette opp sin egen timeplan etter egne ønsker om varighet av hver økt og nyte resurser av kurset."+
                        "</div>";
                }
                
                
                
                
                if (string.IsNullOrEmpty(course.Goal))
                {
                    courseDiv+= "<div style=\"margin-bottom: 5px\">Målet med kurset er å lære hele pensumet, og sørge for at studenten blir 100% klar til å gå opp til eksamen i faget.</div>";
                }
                else
                {
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">{course.Goal}</div>";
                }
                    
                if(course.Language == EnumList.Language.English){
                    courseDiv+= $"<div style=\"margin-bottom: 5px\">En arabisk studentassistent er med på alle leksjonene ved siden av en amerikansk lærer.</div>";
                }
                
                
                
                
                
                
                
                courseDiv += "</div>";



                courseString += courseDiv;
                
                
                

                courseCount++;
            }





            var str =

                //main div
                "<div style=\"padding: 16px; position: relative; font-family: 'Noto Sans', sans-serif; font-size: 11px;min-height:1748px\">" +
                
                //header
                "<div style=\"width: 200px;\">" +
                    "<img src=\"https://matterix.no/Images/LogoPlus.png\" width=\"200\"/>" +
                    "<table style=\"width: 100%; text-align: center\">" +
                        "<tr>" +
                            $"<td colspan=\"2\" style=\"font-size: 13px;\">{StaticInformation.SecondName}</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td colspan=\"2\" style=\"font-size: 9px;\">Nettskole</td>" +
                        "</tr>" +

                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Address}</td>" +
                        "</tr>" +
                
                        "<tr>" +
                            $"<td colspan=\"2\">Org. nr:  {StaticInformation.OrgNumber}</td>" +
                        "</tr>" +
                        
                        "<tr>" +
                            $"<td colspan=\"2\">{StaticInformation.Website}</td>" +
                        "</tr>" +
                    "</table>" +
                "</div>" +
                //End of header
                
                
                //Date
                $"<div style=\"margin-top: 10px; margin-left: 550px; font-size: 9px;\">Dato generert: {Format.DateFormat(Format.NorwayDateNow())}</div>" +
                
                
                //Title
                "<div style=\"text-align: center;\">" +
                    "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 15px; margin-bottom:10px; margin-top:20px;font-weight: bold;\">Kursbeskrivelse</div>" +
//                    $"<div style=\"font-family: 'Noto Sans', sans-serif; margin-bottom:10px;\">Gjelder søknadsnummer: {application.Reference}</div>" +

                    "<div style=\"margin-top: 25px;text-align: left\">" +

                        $"<div style=\"margin-bottom: 7px;\">Dette dokumentet gjelder forespørsel gjennom Matterix Plus-programmet og opplyser rundt kursene. Les mer eller send inn en påmeldings-søknad ved www.matterix.no/plus</div>" +
                    
                    "</div>"+

                "</div>" +
                //End of title
                
                
                //Body parts
                
                
                "<div style=\"font-family: 'Noto Sans', sans-serif; font-size: 13px; margin-bottom:10px; margin-top:25px; font-weight: bold;\">Kurs:</div>" +
                "<table style=\"width: 100% ;font-size:9px; margin-bottom:25px;background-color: #f5f5f5;\">"+
                    "<tr>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">#</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: left\">Kursnavn / Kode</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Status</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Startdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Sluttdato</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Leksjoner i uke</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Tot. antall timer</th>"+
                        "<th style=\"border-bottom: 0.01rem solid #000000;padding:5px;text-align: center\">Pris</th>"+
                        
                    "</tr>"+
                
                    courseTable+
                    
                "</table>"+
                
                courseString+
                
                
                
                


                //Footer
                "<div style=\"position:absolute; bottom: 0; padding: 15px; border-top: 0.02rem solid #2D2D2D; text-align: center; width: 100%;\">"+
                    "<table style=\"width: 100%; font-size: 8px;\">"+
                        "<tr>"+
                            $"<td>{StaticInformation.SecondName} - {StaticInformation.FirstName} / Nettbasert utdanning</td><td>Org. nr: {StaticInformation.OrgNumber}</td><td>Telefon: {StaticInformation.ContactNumber}</td><td>E-post: {StaticInformation.ContactEmail}</td>"+
                        "</tr>"+
                    "</table>"+
                "</div>"+
                
                
                
                
                
                
                
                //end of main div
                "</div>";
            
            
            
            return str;
        }
        
        
        //END OF Html strings can be generated
        
        
        
        
        
        
        
        
        //Generate pdf file as memory stream ...
        //This is used to get memory stream of a file that can be used later as downloadable file or attachment
        private MemoryStream GeneratePdfFile(string htmlString)
        {
            if (string.IsNullOrEmpty(htmlString))
                htmlString = "<p>Error! Contact us. </p><p><a href=\"https://matterix.no/Home/ContactUs\">www.matterix.no</a></p>";
            
            var memoryStream = new MemoryStream();
            
            HtmlConverter.ConvertToPdf(htmlString, memoryStream);
            var file = memoryStream.ToArray();
            var ms = new MemoryStream();
            ms.Write(file, 0, file.Length);
            ms.Position = 0;
            return ms;
        }
    }
}