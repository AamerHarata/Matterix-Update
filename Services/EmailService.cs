using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matterix.Controllers;
using Matterix.Data;
using Matterix.Models;
using Microsoft.EntityFrameworkCore;


namespace Matterix.Services
{
    public class EmailService
    {
        private readonly ApplicationDbContext _context;
        private readonly CourseService _courseService;

        public EmailService(ApplicationDbContext context, CourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }



        //*** Emails can be sent ***//
        
        //Done styling
        public async Task RegisterGreetingEmail(string userId, string confirmLink)
        {
            var user = GetUser(userId);
            if(user == null)
                return;



            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    subject = "Konten Opprett - Bekreft Eposten Din";

                    //ToDo :: Add some instruction at the end of the body
                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           
                           Div("Takk for at du har blitt en av vår familie") +
                           
                           Div($"Venligst bekreft eposten din med å trykke på {Link("denne lenken", confirmLink)}") +
                           
                           Div($"Du har kanskje lyst til å begynne å sjekke kursene? {Link("Trykk her", $"{StaticInformation.FullWebsite}/Course/Search")} til å finne noen kurs.")
                           
                        ;

                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Account Created - Confirm your Email";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           
                           Div("Thank you for being a member of our family!") +
                           
                           Div($"Please verify your E-mail by clicking {Link("this link", confirmLink)}") +
                           
                           Div($"You may would like to start looking for courses? {Link("Click here", $"{StaticInformation.FullWebsite}/Course/Search")} to find some courses.")
                           

                    ;

                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    var want = "ترغب";
                    var click = "اضغط";
                    var find = "لتجد";

                    if (user.Gender == EnumList.Gender.Female){
                        want = "ترغبين";
                        click = "اضغطي";
                        find = "لتجدي";
                    }

                    
                    subject = "تم إنشاء الحساب - يرجى تأكيد بريدك الالكتروني";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           
                           Div("شكراً لكونك فرداً من عائلتنا") +
                           
                           Div($"يرجى تأكيد بريدك الالكتروني عن طريق الضغط على  {Link("هذا الرابط", confirmLink)}") +
                           
                           Div($"قد {want} أيضاً بالبحث عن دورات جديدة؟ {Link($"{click} هنا", $"{StaticInformation.FullWebsite}/Course/Search")} {find} بعض الدورات.")      
                    ;
                    
                    break;
                default:
                    return;
            }



            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.Admin, $"Greeting {user.FirstName} {user.LastName}");


        }
        
        
        //Done styling
        public async Task FollowPaymentLink(string userId, string paymentLink)
        {
            var user = GetUser(userId);
            if(user == null)
                return;



            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    subject = "Betaling med Vipps Startet";


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div($"Hvis du har avbryt Vipps betalingen midt i prosessen kan du fortsette med å trykke på {Link("denne lenken", paymentLink)}") +
                           Div("Hvis din betaling er allerede utført, vennligst ignorer denne eposten") +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Vipps Payment Started";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div($"If you have stopped the Vipps payment process you can complete it by clicking on {Link("this link", paymentLink)}") +
                           Div("If your payment has already been completed, please ignore this email")+
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    
                    subject = "بداية دفعة عن طريق الفيبس";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) + 
                           Div($"إذا كانت عملية الدفع عن طريق فيبس لم تكتمل بعد، يرجى الضغط على {Link("هذا الرابط", paymentLink)}") +
                           Div("إذا كانت عملية الدفع قد تمت بنجاح، يرجى تجاهل هذه الرسالة.")+
                           Div("نتمنى لك يوماً سعيداً!");
                    
                    break;
                default:
                    return;
            }
            
            
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.Admin, paymentLink);
            

        }

        //Done styling
        public async Task EmailVerificationEmail(string userId, string confirmLink)
        {
            var user = GetUser(userId);
            if(user == null || string.IsNullOrEmpty(confirmLink))
                return;


            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    subject = "Bekreft Eposten Din";


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div("Du har spurt om denne eposten!") +
                           Div($"Du kan gjerne bekrefte eposten din med å trykke på {Link("denne lenken", confirmLink)}") +
                           Div($"Var det ikke deg som spurte om dette? {Link("kontakt oss", $"{StaticInformation.FullWebsite}/Home/ContactUs")}") +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Confirm your Email";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div("You have asked for this email!") +
                           Div($"You can verify your E-mail by clicking {Link("this link", confirmLink)}") +
                           Div($"If you did not requested this, please {Link("contact us", $"{StaticInformation.FullWebsite}/Home/ContactUs")}")+
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    var asked = "طلبت";
                    var can = "تستطيع";
                    var be = "تكن";

                    if (user.Gender == EnumList.Gender.Female){
                        asked = "طلبتي";
                        can = "تستطيعين";
                        be = "تكوني";
                    }

                    
                    subject = "تأكيد بريدك الالكتروني";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div($"لقد {asked} هذا البريد") +
                           Div($"{can} تأكيد بريدك الالكتروني {Link("بالضغط هنا", confirmLink)}") +
                           Div($"إذا لم {be} أنت من طلب هذا، يرجى {Link("الاتصال بنا", $"{StaticInformation.FullWebsite}/Home/ContactUs")}") +
                           Div("نتمنى لك يوماً سعيداً!");
                    break;
                default:
                    return;
            }
            
            
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.Admin, $"Verify Email {userId}");

        }

        //Done styling
        public async Task ResetPasswordEmail(string userId, string token)
        {
            var user = GetUser(userId);
            if(user == null)
                return;


            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    subject = "Endre ditt Passord";


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div("Du har spurt om denne eposten.") +
                           Div($"Du kan endre passordet ditt med å trykke på {Link("denne lenken", token)}") +
                           Div($"Var det ikke deg som spurte om dette? {Link("kontakt oss", $"{StaticInformation.FullWebsite}/Home/ContactUs")}") +
                           Div("Ha en fin dag!");
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Change your Password";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div("You have asked for this e-mail.") +
                           Div($"You can change your password by clicking {Link("this link", token)}") +
                           Div($"If you did not requested this, please {Link("contact us", $"{StaticInformation.FullWebsite}/Home/ContactUs")}") +
                           Div("Have a nice day!")

                    ;
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    var asked = "طلبت";
                    var can = "تستطيع";
                    var be = "تكن";

                    if (user.Gender == EnumList.Gender.Female){
                        asked = "طلبتي";
                        can = "تستطيعين";
                        be = "تكوني";
                    }

                    
                    subject = "تغيير كلمة السر";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div($"لقد {asked} هذا البريد") +
                           Div($"{can} تغيير كلمة السر الخاصة بك {Link("بالضغط هنا", token)}") +
                           Div($"إذا لم {be} أنت من طلب هذا، يرجى {Link("الاتصال بنا", $"{StaticInformation.FullWebsite}/Home/ContactUs")}") +
                           Div("نتمنى لك يوماً سعيداً!")

                    ;
                    break;
                default:
                    return;
            }
            
            
            
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.Admin, $"Reset Password {userId}");

        }

        
        //Done styling
        public async Task LectureReminderEmail(List<string> userIds, string lectureId)
        {
            
            var lecture = _context.Lectures.Include(x => x.Course).SingleOrDefault(x => x.Id == lectureId);
            if(lecture == null)
                return;
            
            var minutes = (int) lecture.From.Subtract(Format.NorwayTimeNow()).TotalMinutes;
            
            
            foreach (var userId in userIds)
            {
                var user = GetUser(userId);
                
                if(user == null || !AcceptNotification(userId, EnumList.Notifications.LectureStart))
                    continue;
                
                
                var subject = "";
                var body = "";
                var title = "";
                var description = "";
                var name = $"{user.FirstName} {user.LastName}";
                var lectureNumber = lecture.Number > 0 ? lecture.Number : 0;

                switch (user.Language)
                {
                    case EnumList.Language.Norwegian:
                        title = lecture.IsIntro()? "Leksjonstittel: Introduksjonsleksjonen" : string.IsNullOrEmpty(lecture.Title)? "": Div($"Leksjonstittel: {lecture.Title}");
                        description = string.IsNullOrEmpty(lecture.Description)? "": Div($"Leksjonsbeskrivelse:{Br()}{lecture.Description.Replace("\n", Br()).Trim()}");
                        

                        subject = $"Leksjon Påminnelse - {lecture.Course.Subject}";


                        body = Div($"Hei {name}!", true) +
                               
                               Div($"Leksjonen nummer {lectureNumber} av kurset {lecture.Course.Subject} begynner om {minutes} minutter") +
                               title +
                               description +
                               Br() +
                               Div($"Om du kan ikke møte opp på tida, skal leksjonen tas opp likevel, og videoen vil være tilgjengelig på nettstedet innen 24 timer etter leksjonen er ferdig.")+
                               Div("Lykke til!")

                        ;




                        break;
                    case EnumList.Language.English:
                        title = lecture.IsIntro()? "Lecture title: Introduction Lecture": string.IsNullOrEmpty(lecture.Title)? "": Div($"Lecture title: {lecture.Title}");
                        description = string.IsNullOrEmpty(lecture.Description)? "": Div($"Lecture description:{Br()}{lecture.Description.Replace("\n", Br()).Trim()}");


                        subject = $"Lecture Reminder - {lecture.Course.Subject}";

                        body = Div($"Hi {name}!", true) +
                               Div($"The lecture number {lectureNumber} of the course {lecture.Course.Subject} will start in about {minutes} minutes") +
                               title +
                               description +
                               Br() +
                               Div($"If you cannot attend at the time, the lecture will be recorded anyway, and the video will be available on the website within 24 after the lecture is finished.") +
                               Div("Good luck!")

                        ;



                        break;
                    case EnumList.Language.Arabic:
                        title = lecture.IsIntro()? "عنوان المحاضرة: المحاضرة التعريفية" :string.IsNullOrEmpty(lecture.Title)? "": Div($"عنوان المحاضرة: {lecture.Title}");
                        description = string.IsNullOrEmpty(lecture.Description)? "": Div($"وصف المحاضرة:{Br()}{lecture.Description.Replace("\n", Br()).Trim()}");
                        
                        var can = "تستطيع";


                        if (user.Gender == EnumList.Gender.Female)
                        {
                            can = "تستطيعين";
                        }


                        subject = $"تذكير بالمحاضرة - {lecture.Course.Subject}";


                        body = Div($"مرحباً {name}!", true) +

                               Div(
                                   $"المحاضرة رقم {lectureNumber} من الدورة {lecture.Course.Subject} ستبدأ خلال {minutes} دقيقة") +

                               title +
                               description +
                               Br() +
                               Div($"إن كنت لا {can} الحضور على الوقت، هذه المحاضرة ستكون مسجلة بكل الأحوال وسيصبح الفيديو الخاص بها متاحاً خلال 24 ساعة بعد انتهاء المحاضرة.") +
                               Div("بالتوفيق والنجاح!");

                        
                        break;
                    default:
                        continue;
                }
                
                

                await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.LectureStart, lectureId);
                
            }



        }
        
        //ToDo :: To be changed according to phase
        public async Task InvoiceReminderEmail(int invoiceNumber)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceNumber);
            if(invoice == null || !invoice.ActiveInvoice())
                return;

            var courseName = _context.Courses.SingleOrDefault(x => x.Id == invoice.CourseId)?.Subject;
            
            var increments = await _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber).ToListAsync();
            
            var user = GetUser(invoice.UserId);
            if(user == null)
                return;

            var amount = invoice.CurrentAmount;

            var subject = "";
            var body = "";
            var description = "";
            var footer = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    switch (invoice.InvoiceType)
                    {
                        
                        case EnumList.InvoiceType.Invoice:
                            subject = "Faktura Påminnelse";
                            description = "Vi minner deg på at du har en forfalt faktura til betaling";
                            footer = "Forsinkelse med betalingen kan utsette fakturaen for gebyr eller renter";
                            break;
                        case EnumList.InvoiceType.Purring:
                            subject = "Faktura Purring";
                            description = "Du har fått en purring for en ubetalt faktura! Vennligst betal fakturaen før betalingsfrist utløper";
                            footer = "Purregebyr ble satt og forsinkelse renter på 8.5% vil bli beregnet ut fra i dag";
                            break;
                        case EnumList.InvoiceType.Inkassovarsel:
                            
                            if (increments.Count(x => x.InvoicePhase == EnumList.InvoiceType.Inkassovarsel) <= 1)
                            {
                                subject = "Inkassovarsel";
                                description = "Du har fått en Inkassovarsel! Vennligst betal fakturaen før betalingsfrist utløper";
                                footer = "Purregebyr og forsinkelse renter på 8.5% ble allerede satt! Fakturaen vil bli sendt til Inkasso om den ble ikke betalt før betalingsfrist";
                            }
                            else
                            {
                                subject = "Inkassovarsel / Siste varsel";
                                description = "Du har fått en inkassovarsel! Du kan fortsatt unngå Inkasso med å betale faktoraen innen 14 dager senist";
                                footer = "Purregebyr og forsinkelse renter på 8.5% ble allerede satt! Fakturaen vil bli sendt til Inkasso om den ble ikke betalt før betalingsfrist";
                            }
                            
                            break;
                        case EnumList.InvoiceType.Inkasso:
                        case EnumList.InvoiceType.Other:
                        default:
                            return;
                    }
                    
                    
                    
                    
                    


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div(description) +
                           Br() +
                           Div($"Gjelder kurset: {courseName}") +
                           Div($"Beløp: {Format.NumberFormat(amount)}") +
                           Div($"Fakturanummer: {invoice.Number}") +
                           Div($"Kidnummer: {invoice.CIDNumber}") +
                           Div($"Forfalsdato: {Format.DateFormat(invoice.CurrentDueDate)}") +
                           Div($"Kontonummer: {StaticInformation.AccountNumber}") +
                           Br() +
                           Div($"Du kan vise, utskrive, eller betale fakturaen direkte med å bruke vår betalingsportal med å trykke på {Link("denne lenken", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div("Du må logge inn til å kunne vise lenken.") +
                           Div(footer) +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    switch (invoice.InvoiceType)
                    {
                        
                        case EnumList.InvoiceType.Invoice:
                            subject = "Invoice Reminder";
                            description = "We would like to remind you that you have an unpaid invoice";
                            footer = "Latency in payment can expose it for fees or interest";
                            break;
                        case EnumList.InvoiceType.Purring:
                            subject = "Invoice Latency Reminder";
                            description = "This is a latency reminder for an unpaid invoice! Please pay the invoice before the deadline expires";
                            footer = "Latency fees were already applied and latency interest of 8.5% will be calculated our from today";
                            break;
                        case EnumList.InvoiceType.Inkassovarsel:
                            
                            if (increments.Count(x => x.InvoicePhase == EnumList.InvoiceType.Inkassovarsel) <= 1)
                            {
                                subject = "Inkassovarsel";
                                description = "You have got Inkassovarsel which is warning before sending the invoice to the Norwegian dept collection service! Please pay the invoice before the deadline expires";
                                footer = "Latency fees and latency interest of 8.5% were already applied! The invoice will be sent to the collection service if it did not been paid before the deadline";
                            }
                            else
                            {
                                subject = "Inkassovarsel / Siste varsel";
                                description = "You have got Inkassovarsel which is warning before sending the invoice to the Norwegian dept collection service! You can still avoid the Inkasso by paying the invoice within 14 days maximum";
                                footer = "Latency fees and latency interest of 8.5% were already applied! The invoice will be sent to the collection service if it did not been paid before the deadline";
                            }
                            
                            break;
                        case EnumList.InvoiceType.Inkasso:
                        case EnumList.InvoiceType.Other:
                        default:
                            return;
                    }
                    
                    

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div(description) +
                           Br() +
                           Div($"Applied to course: {courseName}") +
                           Div($"Amount: {Format.NumberFormat(amount)}") +
                           Div($"Invoice number: {invoice.Number}") +
                           Div($"CID number: {invoice.CIDNumber}") +
                           Div($"Payment due date: {Format.DateFormat(invoice.CurrentDueDate)}") +
                           Div($"Account number: {StaticInformation.AccountNumber}") +
                           Br() +
                           Div($"You can view, print, or pay the invoice directly using our payment portal by clicking {Link("this link", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div("You have to log in to be able to access the mentioned link") +
                           Div(footer) +
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    switch (invoice.InvoiceType)
                    {
                        
                        case EnumList.InvoiceType.Invoice:
                            subject = "تذكير بدفع فاتورة";
                            description = "نرغب بتذكيرك بموعد استحقاق فاتورة للدفع";
                            footer = "إن التأخر عن موعد الدفع قد يعرض الفاتورة لرسوم تأخير أو فوائد";
                            break;
                        case EnumList.InvoiceType.Purring:
                            subject = "إشعار تأخير دفع";
                            description = "نرغب بإرسال إشعار تأخير لك بسبب فاتورة متأخرة غير مدفوعة! يرجى تسديد الفاتورة خلال الموعد المحدد";
                            footer = "تم إضافة رسوم تأخير وسيتم بدء احتساب فوائد 8.5% اعتباراً من اليوم";
                            break;
                        case EnumList.InvoiceType.Inkassovarsel:
                            
                            if (increments.Count(x => x.InvoicePhase == EnumList.InvoiceType.Inkassovarsel) <= 1)
                            {
                                subject = "إشعار Inkassovarsel";
                                description = "نرغب بإرسال إشعار Inkassovarsel لك، والذي يعني تنبيه قبل إرسال الفاتورة لدائرة تحصيل الديون النرويجية! يرجى تسديد الفاتورة خلال الموعد المحدد";
                                footer = "تم إضافة رسوم تأخير وفوائد 8.5%! سيتم تحويل هذه الفاتورة لدائرة تحصيل الديون Inkasso في حال لم يتم تسديدها قبل الموعد المحدد";
                            }
                            else
                            {
                                subject = "إشعار Inkassovarsel / الإشعار الأخير";
                                description = "نرغب بإرسال إشعار Inkassovarsel لك، والذي يعني تنبيه قبل إرسال الفاتورة لدائرة تحصيل الديون النرويجية! مازال بإمكانك تجنب الـ Inkasso بدفع الفاتورة خلال 14 يوم كحد أقصى";
                                footer = "تم إضافة رسوم تأخير وفوائد 8.5%! سيتم تحويل هذه الفاتورة لدائرة تحصيل الديون Inkasso في حال لم يتم تسديدها قبل الموعد المحدد";
                            }
                            
                            break;
                        case EnumList.InvoiceType.Inkasso:
                        case EnumList.InvoiceType.Other:
                        default:
                            return;
                    }
                    
                    
                    var can = "تستطيع";
                    var be = "تكون";
                    var toCould = "لتستطيع";
                    var logged = "مسجل";

                    if (user.Gender == EnumList.Gender.Female){
                        
                        can = "تستطيعين";
                        be = "تكوني";
                        toCould = "لتستطيعي";
                        logged = "مسجلة";
                    }

                    
                    

                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div(description) +
                           Br() +
                           Div($"المبلغ: {Format.NumberFormat(amount)}") +
                           Div($"رقم الفاتورة: {invoice.Number}") +
                           Div($"رقم الـ KID (تحتاجه إذا أردت الدفع بواسطة تحويل بنك): {invoice.CIDNumber}") +
                           Div($"رقم الحساب: {StaticInformation.AccountNumber}") +
                           Div($"تاريخ الاستحقاق: {Format.DateFormat(invoice.CurrentDueDate)}") +
                           Br() +
                           Div($"{can} عرض، طباعة، أو دفع الفاتورة مباشرةً على الموقع بواسطة الضغط على {Link("هذا الرابط", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div($"يجب أن {be} {logged} دخولك {toCould} الوصول إلى الرابط المذكور") +
                           Div(footer) +
                           Div("نتمنى لك يوماً سعيداً")

                    ;
                    
                    break;
                default:
                    return;
            }
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.InvoiceReminder, invoiceNumber.ToString());
            invoice.LastNotification = Format.NorwayDateTimeNow();
            _context.Update(invoice);
            await _context.SaveChangesAsync();
        }


        //Done styling
        public async Task InvoicePaidEmail(int invoiceNumber)
        {
            
            var invoice = await _context.Invoices.FindAsync(invoiceNumber);
            
            if(invoice == null)
                return;

            var payment = _context.Payments.SingleOrDefault(x => x.InvoiceNumber == invoiceNumber);
            if(payment == null)
                return;
            
            var paymentId = payment.Id;
            
            var user = GetUser(invoice.UserId);
            
            if(user == null)
                return;
            
            var amount = invoice.CurrentAmount;
            var paymentRef = paymentId.Split("-");
            paymentId = paymentRef.Any() ? paymentRef[0] : "00000000";



            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:

                    subject = "Betalings Bekreftelse";


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div("Fakturaen er nå betalt! Takk skal du ha") +
                           Br() +
                           Div($"Beløp: {Format.NumberFormat(amount)}") +
                           Div($"Fakturanummer: {invoice.Number}") +
                           Div($"Betalings ID: {paymentId}") +
                           Br() +
                           Div($"Du kan vise eller utskrive kvitteringen med å trykke på {Link("denne lenken", $"{StaticInformation.FullWebsite}/Receipt/{invoiceNumber}")}") +
                           Div("Du må logge inn til å kunne vise nevnte lenken") +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Payment Confirmation";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div("The invoice is now paid! Thank you") +
                           Br() +
                           Div($"Amount: {Format.NumberFormat(amount)}") +
                           Div($"Invoice Number: {invoice.Number}") +
                           Div($"Payment ID: {paymentId}") +
                           Br() +
                           Div($"You can view or print the receipt by clicking {Link("this link", $"{StaticInformation.FullWebsite}/Receipt/{invoiceNumber}")}") +
                           Div("You have to log in to be able to access the mentioned link") +
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    var can = "تستطيع";
                    var be = "تكون";
                    var toCould = "لتستطيع";
                    var logged = "مسجل";

                    if (user.Gender == EnumList.Gender.Female){
                       
                        can = "تستطيعين";
                        be = "تكوني";
                        toCould = "لتستطيعي";
                        logged = "مسجلة";
                    }

                    
                    subject = "تأكيد دفع";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div("تم دفع الفاتورة بنجاح! شكراً لك") +
                           Br()+
                           Div($"المبلغ: {Format.NumberFormat(amount)}")+
                           Div($"رقم الفاتورة: {invoice.Number}")+
                           Div($"معرف الدفعة: {paymentId}")+
                           Br()+
                           Div($"{can} عرض أو طباعة إيصال الدفع عن طريق الضغط على {Link("هذا الرابط", $"{StaticInformation.FullWebsite}/Receipt/{invoiceNumber}")}") +
                           Div($"يجب أن {be} {logged} دخولك {toCould} الوصول إلى الرابط المذكور")+
                           Div("نتمنى لك يوماً سعيداً!")

                    ;
                    
                    break;
                default:
                    return;
            }
            
            
            
            
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.InvoiceReceipt, $"{invoiceNumber}");
        }


        //Done styling
        public async Task CourseRegisterCompletedEmail(string userId, string courseId, DateTime expireDate)
        {
            var user = GetUser(userId);
            var course = _courseService.GetCourse(courseId);
            if(user == null || course == null)
                return;

            var schedule = _courseService.GetCourseSchedule(courseId);



            var subject = "";
            var body = "";
            var liveTemplate = "";
            var completedTemplate = "";
            var finalTemplate = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:


                    liveTemplate = Div("Kurs timeplan er: (legg merke til at timeplanen kan endres seinere)") +
                                   GenerateSchedule(schedule, EnumList.Language.Norwegian) +
                                   Br();
                    liveTemplate += Div($"Dette kurset er direkte, om du tranger hjelp med hvordan kan du komme deg inn på klasserommet til å møte opp, les denne instruksjonsiden veldig nøye.. {Link("Hjelp om direkte kurs", LiveCourseHelpLink())}");
                    liveTemplate += Div($"Du kan også vise kurset med å trykke på {Link("denne lenken", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}");

                    completedTemplate =
                        $"Dette kurset er fullført, derfor kan du se på leksjonene / vidoene nå det passer med deg, besøk kurset med å trykke på {Link("denne lenken", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}";


                    finalTemplate = course.Ended ? completedTemplate : liveTemplate;


                    subject = "Kurs Påmelding Bekreftelse";


                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div($"Du er nå meldt deg på kurset {course.Subject}") +
                           Br() +
                           Div($"Fagkode: {course.Code}") +
                           Div($"Faglærer: {course.Teacher.FirstName} {course.Teacher.LastName}") +
                           Div($"Din påmelding er gyldig frem til: {Format.DateFormat(expireDate)}") +
                           Br() +
                           finalTemplate +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    

                    liveTemplate = Div("The course schedule is: (notice that it could be changed later)") +
                                   GenerateSchedule(schedule, EnumList.Language.English) +
                                   Br();
                    liveTemplate += Div($"This course is live, if you need help about how you can join to the class room to attend the lecture, read this instructions page very carefully.. {Link("Help about live courses", LiveCourseHelpLink())}");
                    liveTemplate += Div($"You can also show the course page by clicking {Link("this link", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}");

                    completedTemplate =
                        $"This course is completed. Therefore, you can watch the lectures / videos according to your own schedule, visit the course by clicking {Link("this link", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}";


                    finalTemplate = course.Ended ? completedTemplate : liveTemplate;
                    
                    
                    subject = "Course Enrollment Confirmation";

                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div($"You are now enrolled to the course {course.Subject}") +
                           Br() +
                           Div($"Course Code: {course.Code}") +
                           Div($"Teacher: {course.Teacher.FirstName} {course.Teacher.LastName}") +
                           Div($"Your enrollment will be valid until: {Format.DateFormat(expireDate)}") +
                           Br() +
                           finalTemplate +
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    var can = "تستطيع";
                    var up = "قم";

                    if (user.Gender == EnumList.Gender.Female){
                        can = "تستطيعين";
                        up = "قومي";
                    }
                    
                    

                    liveTemplate = Div("برنامج الدورة: (يرجى الانتباه أنه قد يتغير لاحقاً)") +
                                   GenerateSchedule(schedule, EnumList.Language.Arabic) +
                                   Br();
                    liveTemplate += Div($"هذه الدورة مباشرة، إذا كنت بحاجة للمساعدة حول كيفية الدخول إلى قاعة المحاضرات من أجل حضور المحاضرة مباشر، يرجى قراءة هذه التعليمات بعناية.. {Link("مساعدة للدورات المباشرة", $"{LiveCourseHelpLink()}")}");
                    liveTemplate += Div($"{can} أيضاً عرض صفحة الدورة بالنقر على {Link("هذا الرابط", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}");

                    completedTemplate =
                        $"هذه الدورة مسجلة، ولهذا يمكنك مشاهدة المحاضرات / الفيديوهات، حسب وقتك المتاح، {up} بزيارة صفحة الدورة عن طريق الضغط على {Link("هذا الرابط", $"{StaticInformation.FullWebsite}/Course/Area/{courseId}")}";


                    finalTemplate = course.Ended ? completedTemplate : liveTemplate;
                    
                    

                    
                    subject = "تأكيد التسجيل في الدورة";


                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div($"لقد تم تسجيلك في الدورة بنجاح {course.Subject}") +
                           Br() +
                           Div($"رمز الدورة: {course.Code}") +
                           Div($"المدرس: {course.Teacher.FirstName} {course.Teacher.LastName}") +
                           Div($"تسجيلك صالح حتى تاريخ: {Format.DateFormat(expireDate)}") +
                           Br() +
                           finalTemplate +
                           Div("نتمنى لك يوماً سعيداً!");
                    
                    break;
                default:
                    return;
            }
            
            
            
            
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.CourseRegisterConfirmation, $"{courseId},{userId}");
        }

        //Done styling
        public async Task CustomAdminEmail(string userId, string subject, string template, EnumList.Language language)
        {
            var user = GetUser(userId);
            if(user == null)
                return;

            var body = "";
            var lines = template.Split("\n");
            
            foreach (var line in lines)
                body += Div(line);
            
            switch (language)
            {
                case EnumList.Language.Norwegian:
                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                            body;


                    break;
                case EnumList.Language.English:


                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           body;

                    break;
                case EnumList.Language.Arabic:
                default:
                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           body;

                    break;
                    
            }


            await SaveNotification(user, subject, body, language, EnumList.Notifications.Admin, $"Admin to user: {user.FirstName} {user.LastName}");
            


        }
         
        public async Task CourseGroupEmail(List<string> userIds, string subject, string template, EnumList.Language language)
        {
            
            
            var body = "";
            var lines = template.Split("\n");
            template = "";
            
            foreach (var line in lines)
                template += Div(line);
            
            foreach (var userId in userIds)
            {
                var user = GetUser(userId);
                if(user == null)
                    continue;

                
                switch (language)
                {
                    case EnumList.Language.Norwegian:
                        body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                               template;


                        break;
                    case EnumList.Language.English:


                        body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                               template;


                        break;
                    case EnumList.Language.Arabic:


                        body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                               template;


                        break;
                    default:
                        continue;
                }
                
                
                await SaveNotification(user, subject, body, language, EnumList.Notifications.Admin, $"Admin to group: {subject}");
                
            }
            
            
        }
        
        public async Task FileAddedNotification(List<string> userIds, string lectureId, string fileName)
        {
            
            var fileString = "";

            var lectureFile = _context.Files.Include(x => x.Lecture).Where(x => x.LectureId == lectureId)
                .SingleOrDefault(x => x.Name == fileName);
            
            var lecture = _context.Lectures.Include(x => x.Course).SingleOrDefault(x => x.Id == lectureId);
                
            
            if (lectureFile == null || lecture == null)
                return;
            
            

            foreach (var userId in userIds)
            {
                var user = GetUser(userId);
                if(user == null)
                    continue;


                
            
                if(!AcceptNotification(userId, EnumList.Notifications.CourseUpdate))
                    continue;
                
                
                var subject = "";
                var body = "";
                
                switch (user.Language)
            {
                case EnumList.Language.Norwegian:
                    
                    
                    if (lectureFile.IsHomeWork){
                        subject = $"Ny Innlevering - {lecture.Course.Subject}";
                        fileString =
                            Div($"En ny innlevering fil er legget til, i forhold til leksjonen nr: {lecture.Number} av kurset: {lecture.Course.Subject}")
                            + Div($"Filnavn: {lectureFile.Name}")
                            + Div($"Innleveringsfrist: {Format.TimeFormat(lectureFile.DeadLine)}", true);
                    }
                    else {
                        subject = $"Ny Fil - {lecture.Course.Subject}";
                        fileString =
                            Div($"En ny fil er legget til, i forhold til leksjonen nr: {lecture.Number} av kurset: {lecture.Course.Subject}")
                            + Div($"Filnavn: {lectureFile.Name}");
                        
                    }



                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           fileString +
                           Div($"Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    if (lectureFile.IsHomeWork){
                        subject = $"New Homework - {lecture.Course.Subject}";
                        fileString =
                            Div($"A new homework file is added, related to the lecture number: {lecture.Number} of the course: {lecture.Course.Subject}")
                            + Div($"File Name: {lectureFile.Name}")
                            + Div($"Deliver deadline: {Format.DateFormat(lectureFile.DeadLine)}", true);
                    }
                    else {
                        subject = $"New File - {lecture.Course.Subject}";
                        fileString =
                            Div($"A new file is added, related to the lecture number: {lecture.Number} of the course: {lecture.Course.Subject}")
                            + Div($"File Name: {lectureFile.Name}");
                        
                    }



                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           fileString +
                           Div($"Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    if (lectureFile.IsHomeWork){
                        subject = $"وظيفة جديدة - {lecture.Course.Subject}";
                        fileString =
                            Div($"تم إضافة وظيفة جديدة، متعلقة بالمحاضرة رقم: {lecture.Number} من الدورة: {lecture.Course.Subject}")
                            + Div($"اسم الملف: {lectureFile.Name}")
                            + Div($"آخر موعد للتسليم: {Format.DateFormat(lectureFile.DeadLine)}", true);
                    }
                    else {
                        subject = $"ملف جديد - {lecture.Course.Subject}";
                        fileString =
                            Div($"تم إضافة ملف جديد، متعلق بالمحاضرة رقم: {lecture.Number} من الدورة: {lecture.Course.Subject}")
                            + Div($"اسم الملف: {lectureFile.Name}");
                        
                    }



                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           fileString +
                           Div("نتمنى لك يوماً سعيداً");
                    
                   
                    break;
                default:
                    continue;
            }


                await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.CourseUpdate, $"File added: {lecture.Course.Subject}");
                
            }


            
        }

        public async Task MarkAddedNotification(string userId, string homeworkDeliveryFileName, int mark, string teacherComment)
        {

            var user = await _context.Users.FindAsync(userId);
            if(user == null || !AcceptNotification(userId, EnumList.Notifications.CourseUpdate))
                return;
            
            
            var subject = "";
            var body = "";
            
            teacherComment = string.IsNullOrEmpty(teacherComment) ? "" : teacherComment.Replace("\n", "<br/>");
            
                
                switch (user.Language)
            {
                case EnumList.Language.Norwegian:
                    
                    subject = "Karakter på Innlevering";

                    teacherComment = string.IsNullOrEmpty(teacherComment) ? "" : Div($"Lærer kommentar:<br/>{teacherComment}");

                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div($"Du har levert filen: {homeworkDeliveryFileName}") +
                           Div($"Karakter du har fått: {mark}", true) +
                           teacherComment +
                           Div($"Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    subject = "Homework Graded";
                    
                    teacherComment = string.IsNullOrEmpty(teacherComment) ? "" : Div($"Teacher comment:<br/>{teacherComment}");



                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div($"You have delivered the file: {homeworkDeliveryFileName}") +
                           Div($"The mark you got: {mark}", true) +
                           teacherComment +
                           Div($"Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    subject = "علامة الوظيفة";
                    
                    teacherComment = string.IsNullOrEmpty(teacherComment) ? "" : Div($"تعليق المدرس:<br/>{teacherComment}");

                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div($"لقد قمت بتسليم الملف: {homeworkDeliveryFileName}") +
                           Div($"العلامة التي حصلت عليها: {mark}", true) +
                           teacherComment +
                           Div($"نتمنى لك يوماً سعيداً!");
                    
                    break;
                default:
                    return;
            }

                await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.CourseUpdate, $"Grade: {homeworkDeliveryFileName}");


        }

        public async Task NotifyAdminForInvoice(int invoiceNumber)
        {

            var admin = _context.Users.ToList().SingleOrDefault(x => string.Equals(x.UserName, "Aamer.harata@hotmail.com", StringComparison.OrdinalIgnoreCase));
            var invoice = await _context.Invoices.FindAsync(invoiceNumber);
            var user = await _context.Users.FindAsync(invoice?.UserId);
            
            if(admin == null || invoice == null || invoice.Paid)
                return;
            
            var student = await _context.Users.FindAsync(invoice.UserId);
            
            if(student == null)
                return;

            var address = await _context.Addresses.SingleOrDefaultAsync(x => x.UserId == invoice.UserId);
            
            var subject = invoice.InvoiceType == EnumList.InvoiceType.Inkassovarsel? "Inkassovarsel Action" : "Inkasso sending Action";
            var toSend = invoice.InvoiceType == EnumList.InvoiceType.Inkassovarsel? "Inkassovarsel" : "to Inkasso Lindorff";
            
            var body = Div($"Please send {toSend}") +
                       Div($"User: {user.FirstName} {user.MiddleName} {user.LastName}") +
                       Div($"Phone: {user.PhoneCode} {user.PhoneNumber}") +
                       Div($"Address: {address.Street}, {address.ZipCode} {address.City}") +
                       Div($"Invoice: {invoiceNumber} - {invoice.InvoiceType}") +
                       Div($"KID: {invoice.CIDNumber}") +
                       Div($"Amount: {invoice.CurrentAmount}") +
                       Div($"Due date: {invoice.CurrentDueDate}") +
                       Div($"Deadline: {invoice.CurrentDeadline}")

                ;

            if (invoice.InvoiceType != EnumList.InvoiceType.Inkassovarsel && invoice.InvoiceType != EnumList.InvoiceType.Inkasso )
            {
                subject = "Something Went Wrong";
            }
            
            
            
            await SaveNotification(admin, subject, body, EnumList.Language.English, EnumList.Notifications.Admin, $"From Admin to Admin");
        }

        public async Task JobApplicationReceived(string applicationId)
        {
            var application = await _context.JobApplications.FindAsync(applicationId);
            if(application == null)
                return;
            var user = await _context.Users.FindAsync(application.UserId);
            if(user == null)
                return;

            var extraMessage = string.IsNullOrEmpty(application.ExtraMessage) ? "" : Div($"مزيد من المعلومات: {application.ExtraMessage}");
            
            var subject = "تلقينا طلب التوظيف";


            var body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                   Div("لقد تلقينا طلب التوظيف بنجاح! شكراً لك ..") +
                   Br()+
                   Div("سنقوم بمعالجة طلبك بأسرع وقت ممكن، وقد نقوم بتحديد موعد للمقابلة في حال تم قبول الطلب")+
                   Div("يمكنك متابعة حالة الطلب الخاصة بك بالدخول إلى طلبات التوظيف ثم الضغط على الطلبات السابقة")+
                   Br()+
                   Div($"المواد: {application.CourseName}")+
                   Div($"رابط الفيديو: {Link(application.VideoLink, application.VideoLink)}")+
                   extraMessage +
                   Div($"السيرة الذاتية: {Link("عرض", $"{StaticInformation.FullWebsite}/{application.CvWebPath.Replace("~", "")}")}")+
                   Br()+
                   Div("نتمنى لك يوماً سعيداً!")
                ;
            
            await SaveNotification(user, subject, body, EnumList.Language.Arabic, EnumList.Notifications.Admin, applicationId);
            
            
        }

        public async Task InvoiceDelay(int invoiceNumber, int days)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceNumber);
            if(invoice == null || !invoice.ActiveInvoice())
                return;

            var courseName = _context.Courses.SingleOrDefault(x => x.Id == invoice.CourseId)?.Subject;
            
            var increments = await _context.Increments.Where(x => x.InvoiceNumber == invoiceNumber).ToListAsync();
            
            var user = GetUser(invoice.UserId);
            if(user == null)
                return;

            var amount = invoice.CurrentAmount;

            var subject = "";
            var body = "";


            switch (user.Language)
            {
                case EnumList.Language.Norwegian:
                    subject = "Faktura utsettelse";

                    body = Div($"Hei {user.FirstName} {user.LastName}!", true) +
                           Div($"Vi har utsettet fakturaen for {days} nye dager") +
                           Br() +
                           Div($"Gjelder kurset: {courseName}") +
                           Div($"Beløp: {Format.NumberFormat(amount)}") +
                           Div($"Fakturanummer: {invoice.Number}") +
                           Div($"Kidnummer: {invoice.CIDNumber}") +
                           Div($"Nye betalingsfrist: {Format.DateFormat(invoice.CurrentDeadline)}", true) +
                           Div($"Kontonummer: {StaticInformation.AccountNumber}") +
                           Br() +
                           Div("Vennligst betal fakturaen før fristen utløper")+
                           Div($"Du kan vise, utskrive, eller betale fakturaen direkte med å bruke vår betalingsportal med å trykke på {Link("denne lenken", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div("Du må logge inn til å kunne vise lenken.") +
                           Div("Ha en fin dag!");
                    
                    
                    
                    
                    break;
                case EnumList.Language.English:
                    
                    
                    subject = "Invoice postponement";
                    body = Div($"Hi {user.FirstName} {user.LastName}!", true) +
                           Div($"We have postponed the invoice for {days} new days for you") +
                           Br() +
                           Div($"Applied to course: {courseName}") +
                           Div($"Amount: {Format.NumberFormat(amount)}") +
                           Div($"Invoice number: {invoice.Number}") +
                           Div($"CID number: {invoice.CIDNumber}") +
                           Div($"New deadline: {Format.DateFormat(invoice.CurrentDeadline)}", true) +
                           Div($"Account number: {StaticInformation.AccountNumber}") +
                           Br() +
                           Div("Please pay the invoice before the deadline passes")+
                           Div($"You can view, print, or pay the invoice directly using our payment portal by clicking {Link("this link", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div("You have to log in to be able to access the mentioned link") +
                           Div("Have a nice day!");
                    
                    
                    
                    break;
                case EnumList.Language.Arabic:
                    
                    
                    
                    var can = "تستطيع";
                    var be = "تكون";
                    var toCould = "لتستطيع";
                    var logged = "مسجل";
                    var daysString = days == 1 || days >= 11 ? "يوم" : "أيام";

                    if (user.Gender == EnumList.Gender.Female){
                        
                        can = "تستطيعين";
                        be = "تكوني";
                        toCould = "لتستطيعي";
                        logged = "مسجلة";
                    }

                    
                    
                    subject = "تأجيل الفاتورة";
                    body = Div($"مرحباً {user.FirstName} {user.LastName}!", true) +
                           Div($"لقد قمنا بتأجيل الفاتورة بإضافة  {days} {daysString} على الموعد النهائي للدفع") +
                           Br() +
                           Div($"المبلغ: {Format.NumberFormat(amount)}") +
                           Div($"رقم الفاتورة: {invoice.Number}") +
                           Div($"رقم الـ KID (تحتاجه إذا أردت الدفع بواسطة تحويل بنك): {invoice.CIDNumber}") +
                           Div($"رقم الحساب: {StaticInformation.AccountNumber}") +
                           Div($"الموعد النهائي الجديد: {Format.DateFormat(invoice.CurrentDeadline)}", true) +
                           Br() +
                           Div("يرجى تسديد الفاتورة قبل الموعد النهائي للدفع")+
                           Div($"{can} عرض، طباعة، أو دفع الفاتورة مباشرةً على الموقع بواسطة الضغط على {Link("هذا الرابط", $"{StaticInformation.FullWebsite}/Invoice/{invoiceNumber}")}") +
                           Div($"يجب أن {be} {logged} دخولك {toCould} الوصول إلى الرابط المذكور") +
                           Div("نتمنى لك يوماً سعيداً")

                    ;
                    
                    break;
                default:
                    return;
            }
            
            await SaveNotification(user, subject, body, user.Language, EnumList.Notifications.InvoiceReminder, invoiceNumber.ToString());
        }
        
        public async Task PlusApplicationReceivedUser(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if(application == null)
                return;
            
            var user = GetUser(application.StudentId);
            if(user == null)
                return;
            
            var name = $"{user.FirstName} {user.LastName}";
            

            var subject = "Vi har mottatt din Matterix Plus søknad";

            var body =
                Div($"Hei {name}!", true) +
                Div($"Matterix Plus søknad nr: {application.Reference} er nå mottatt!")+
                Div($"Alle dokumenter er nå sendt til din saksbehandler hos {application.Organization} for godkjenning")+
                Div($"Vi venter på Opptaksdokumentet å bli ferdi signert / godkjent av din saksbehandler / kontaktperson slik at vi kan behandle søknaden videre.")+
                Br() +
                Div($"Du kan alltid sjekke status på din søknad ved {Link("lenken", $"{StaticInformation.FullWebsite}/plus/application/{applicationId}?passCode={application.PassCode}")}") +
                Div("Lykke til!");
            
            
            


            await SaveNotification(user, subject, body, EnumList.Language.Norwegian, EnumList.Notifications.PlusApplicationReceivedUser, $"{applicationId}");
            


        }
        
        public async Task PlusApplicationReceivedOrg(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if(application == null)
                return;
            
            var user = GetUser(application.StudentId);
            if(user == null)
                return;


            var studentName = $"{user.FirstName} {user.LastName}";
            
            var subject = $"Matterix Plus Søknad Ref: {application.Reference}";

            var body =
                Div("Hei!") +
                Div("Denne eposten er fra Matterix skole på vegne av søkeren!") +
                Div($"Vi har fått en påmeldingssøknad fra {studentName} med referanse til dere som kontaktperson. Dermed trenger vi deres godkjenning slik at vi kan behandle søknaden videre!")+
                Div($"Detaljert opplysninger om søknaden finner dere i de vedlagte filene.")+
                Br() +
                Div($"Status på søknad kan sjekkes og filene kan hentes ved {Link("lenken", $"{StaticInformation.FullWebsite}/plus/application/{applicationId}?passCode={application.PassCode}")}") +
                Div("Med vennlig hilsen!");
            
            
            


            await SaveNotification(user, subject, body, EnumList.Language.Norwegian, EnumList.Notifications.PlusApplicationReceivedOrg, $"{applicationId}", application.ContactPersonEmail);
            


        }
        
        public async Task PlusApplicationAccepted(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if(application == null)
                return;
            
            var user = GetUser(application.StudentId);
            if(user == null)
                return;
            
            var name = $"{user.FirstName} {user.LastName}";
            

            var subject = "Din Søknad er nå Godkjent";

            var body =
                Div($"Hei {name}!", true) +
                Div($"Matterix Plus-søknad nummer: {application.Reference} er nå godkjent!")+
                Div($"Du vil få snart påmeldingsbekreftelse på alle kurs din søknad gjelder.")+
                Div($"Faktura er nå sendt til {application.Organization}")+
                Br() +
                Div($"Du kan alltid sjekke status på din søknad ved {Link("lenken", $"{StaticInformation.FullWebsite}/plus/application/{applicationId}?passCode={application.PassCode}")}") +
                Div("Lykke til!");
            
            
            


            await SaveNotification(user, subject, body, EnumList.Language.Norwegian, EnumList.Notifications.PlusApplicationAccepted, $"{applicationId}");
            


        }

        public async Task SendPlusApplicationInvoices(string applicationId)
        {
            var application = await _context.PlusApplications.FindAsync(applicationId);
            if(application == null)
                return;
            
            var user = GetUser(application.StudentId);
            if(user == null)
                return;

            var invoices = await _context.Invoices.Where(x => x.ApplicationId == applicationId).Where(x => !x.Paid)
                .ToListAsync();
            if(invoices.Count == 0)
                return;

            var invoiceString = "Fakturaen ble";
//            var manyInvoiceString =
//                    Par($"Fakturanummer: {invoices[0].Number}") + Par($"Kidnummer: {invoices[0].CIDNumber}") + 
//                Par($"Beløp: {Format.NumberFormat(invoices.Sum(x=>x.CurrentAmount))},- kr") + Par($"Forfallsdato: {Format.DateFormat(invoices[0].CurrentDueDate)}")+
//                Par($"Kontonummer: {StaticInformation.AccountNumber}")
//                ;

            var table =
                "<table style=\"background-color: #f5f5f5;\">" +
                    "<tr>"+
                        $"<td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Fakturanummer:</td><td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">{invoices[0].Number}</td>"+
                    "</tr>"+
                    "<tr>"+
                        $"<td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Forfallsdato: </td><td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">{Format.DateFormat(invoices[0].CurrentDueDate)}</td>"+
                    "</tr>"+
                    "<tr>"+
                        $"<td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Beløp:</td><td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">{Format.NumberFormat(invoices.Sum(x=>x.CurrentAmount))},- kr</td>"+
                    "</tr>"+
                    "<tr>"+
                        $"<td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Kontonummer: </td><td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">{StaticInformation.AccountNumber}</td>"+
                    "</tr>"+
                    "<tr>"+
                        $"<td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">Kid-nummer:</td><td style=\"border-bottom: 0.01rem solid #000000; padding:5px;text-align: left\">{invoices[0].CIDNumber}</td>"+
                    "</tr>"+
                "</table>";

            var manyInvoiceString = Div(table);

            if (invoices.Count > 1)
            {
                invoiceString = "Fakturaene ble delt med ett beløp for hvert kurs og";
                manyInvoiceString = "Du kan betale alle fakturaene med en betaling med følgende betalingsinfo:"+manyInvoiceString;
            }
            
            var name = $"{user.FirstName} {user.LastName}";
            

            var subject = "Faktura - Søknad er nå Godkjent";

            var body =
                Div("Hei!") +
                Div($"Matterix Plus-søknad nummer: {application.Reference} er nå godkjent!")+
                Div($"{invoiceString} vedlagt denne eposten.")+
                manyInvoiceString+
                Br()+
                Div($"Du kan alltid sjekke status på søknaden ved {Link("lenken", $"{StaticInformation.FullWebsite}/plus/application/{applicationId}?passCode={application.PassCode}")}") +
                Div("Med vennlig hilsen!");
            
            
            


            await SaveNotification(user, subject, body, EnumList.Language.Norwegian, EnumList.Notifications.PlusApplicationInvoices, $"{applicationId}", application.ContactPersonEmail);
            
        }


        
        
        


        private string LiveCourseHelpLink()
        {
            return $"{StaticInformation.FullWebsite}/Instructions/ShortVideos#JoinLecture";
        }
        private ApplicationUser GetUser(string userId){return _context.Users.Find(userId);}

        private string Signature()
        {
            var sign =
                Div(
                    Div($"{StaticInformation.SecondName} - {StaticInformation.FirstName}") +
                    Div($"Org. Nr. {StaticInformation.OrgNumber}") +
                    Div(StaticInformation.Address),
                    true) +
                Div(
                    $"<div style='text-align: center;'>Website: {Link(StaticInformation.Website, StaticInformation.FullWebsite, true, false)} - E-mail: {Link($"{StaticInformation.ContactEmail}", $"mailto:{StaticInformation.ContactEmail}", true, false)} - Telephone: {Link($"{StaticInformation.ContactNumber}", $"tel:{StaticInformation.ContactNumber}", true, false)} - Facebook: {Link("Like us!", StaticInformation.FacebookPage, true, false)} - Group: {Link("Join us!", StaticInformation.FacebookGroup, true, false)}</div>");
                
            return sign;
        }


        private string TranslateDay(EnumList.Days day, EnumList.Language language)
        {
            switch (day)
            {
                case EnumList.Days.Saturday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Lørdag";
                        case EnumList.Language.English:
                            return "Saturday";
                        case EnumList.Language.Arabic:
                            return "السبت";
                        default:
                            return "";
                    }
                
                
                
                
                
                
                
                
                
                case EnumList.Days.Sunday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Søndag";
                        case EnumList.Language.English:
                            return "Sunday";
                        case EnumList.Language.Arabic:
                            return "الأحد";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Monday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Mandag";
                        case EnumList.Language.English:
                            return "Monday";
                        case EnumList.Language.Arabic:
                            return "الاثنين";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Tuesday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Tirsdag";
                        case EnumList.Language.English:
                            return "Tuesday";
                        case EnumList.Language.Arabic:
                            return "الثلاثاء";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Wednesday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Onsdag";
                        case EnumList.Language.English:
                            return "Wednesday";
                        case EnumList.Language.Arabic:
                            return "الأربعاء";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Thursday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Torsdag";
                        case EnumList.Language.English:
                            return "Thursday";
                        case EnumList.Language.Arabic:
                            return "الخميس";
                        default:
                            return "";
                    }
                    
                    
                    
                    
                    
                    
                case EnumList.Days.Friday:
                    switch (language)
                    {
                        case EnumList.Language.Norwegian:
                            return "Fredag";
                        case EnumList.Language.English:
                            return "Friday";
                        case EnumList.Language.Arabic:
                            return "الجمعة";
                        default:
                            return "";
                    }
                default:
                    return "";
            }
        }


        private string GenerateSchedule(List<Schedule> schedules, EnumList.Language language)
        {
            var result = "";

            switch (language)
            {
                case EnumList.Language.Norwegian:
                    foreach (var schedule in schedules)
                        result += Div(
                            $"{TranslateDay(schedule.Day, language)} - fra {Format.TimeFormat(schedule.From)} til {Format.TimeFormat(schedule.To)}");
                    return result;
                
                
                
                
                case EnumList.Language.English:
                    foreach (var schedule in schedules)
                        result += Div(
                            $"{TranslateDay(schedule.Day, language)} - from {Format.TimeFormat(schedule.From)} to {Format.TimeFormat(schedule.To)}");
                    return result;
                
                
                
                case EnumList.Language.Arabic:
                    foreach (var schedule in schedules)
                        result += Div(
                            $"{TranslateDay(schedule.Day, language)} - من {Format.TimeFormat(schedule.From)} إلى {Format.TimeFormat(schedule.To)}");
                    return result;
                
                    
                default:
                    return result;
            }
            
            
            
            
            
            
            
        }

        private string Div(string text, bool color = false)
        {
            return color ? $"<div style='color: #4e54a4; margin-bottom: 7px;'>{text}</div>" : $"<div style='margin-bottom: 7px;'>{text}</div>";
        }
        
        private string Par(string text, bool color = false)
        {
            return color ? $"<p style='color: #4e54a4;'>{text}</p>" : $"<p>{text}</p>";
        }
        

        private string Br(){return "<br/>";}

        private string Link(string text, string link, bool color = true, bool background = true)
        {
            var colorCss = color ? "color: #4e54a4;" : "";
            var backgroundCss = background ? "background-color: #e2e3f2; padding: 2px 4px; border-radius: 4px;" : "";
            
            
            return $"<a style='text-decoration: none; {colorCss} {backgroundCss}' href='{link}'>{text}</a>";
        }

        
        
        private bool AcceptNotification(string userId, EnumList.Notifications type)
        {
            if (type == EnumList.Notifications.Admin)
                return true;
            
            return !_context.NoNotifications.Where(x => x.UserId == userId)
                .Where(x=>x.Method == EnumList.NotifyMethod.Email)
                .Any(x => x.NotificationType == type);
            
        }

        private async Task SaveNotification(ApplicationUser user, string subject, string body, EnumList.Language language, EnumList.Notifications type, string reference, string email = "")
        {
            body = HtmlTemplate(body, subject, language);

            email = string.IsNullOrEmpty(email) ? user.Email : email;
            
            var notification = new Notification()
            {
                User = user, Subject = subject, Body = body, Email = email, Method = EnumList.NotifyMethod.Email,
                Type = type, Reference = reference
            };
            await _context.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        private string HtmlTemplate(string body, string subject, EnumList.Language language)
        {
            var textDirection = "ltr";
            var textAlign = "left";

            if (language == EnumList.Language.Arabic)
            {
                textDirection = "rtl";
                textAlign = "right";
            }
            
            
            var full =
                "<html>" +

                "<body>"+
                
                "<div style='background-color:#e2e3f2; text-align: center; padding: 8px;'>"+
                    $"<div style='border-radius:3px; background-color: #ffffff; width: 95%; margin: auto; font-size: 14px; color: #323232; padding: 8px;'>"+
                
                        "<div  style='text-align: center;'><img alt='' src='https://matterix.no/Images/MatterixLogoSmall.png' width='250' height='auto'/></div>"+
                        "<hr style=' margin-bottom: 16px; width: 80%;'/>"+
                        $"<div dir='{textDirection}' style='text-align: {textAlign}; padding: 16px;'>"+
                            //Title inside the body
                            $"<p style='font-size: 16px; color: #4e54a4; width: max-content; max-width: 100%; text-align: center; margin: auto auto 8px auto; overflow-wrap: break-word;  padding: 8px; border-radius: 3px; background-color: #e2e3f2;'>{subject}</p>"+
                            
                            $"{body}"+
                
                
                        "</div>"+
                        "<hr style=' margin: 16px auto; width: 80%;'/>"+
                        
                        $"<div dir='ltr' style='text-align: left; font-size: 12px; padding: 16px;'>{Signature()}</div>"+
                        "<p><hr/></p>"+
                        "<p style='font-size: 9px'>Matterix er en nettskole som underviser norske videregående fag, i tillegg til noen andre grunnkurs i flere emner, direkte på nettet, ved hjelp av profesjonelle digitale midler og flinke lærere</p>"+
                
                
                    "</div>"+
                "</div>"+
                
                
                "</body>" +
                "</html>";
            
            
            
            
            return full;
        }
        

    }
}
