namespace Matterix.Services
{
    public class EnumList
    {
        //Add New Countries
        public enum Language
        {
            Norwegian, English, Arabic,Swedish,German
        }

        public enum Days
        {
            Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday
        }

        public enum Gender
        {
            Male=0, Female, Other
        }

        public enum Role
        {
            Student, Teacher, Admin
        }

        public enum PaymentReason
        {
            Empty, Register, Invoice, Donate, Other
        }
        public enum InvoiceType
        {
            Other, Invoice, Purring, Inkassovarsel, Inkasso  
        }


        public enum PaymentMethod
        {
            Other, Vipps, Stripe, Admin, BankCID
        }
        
        public enum PaymentResult
        {
            Failed, Error, Success
        }

        public enum InvoiceReason
        {
            Other, Registration, MonthlyPayment, PlusRegistration
        }

        public enum IncrementType
        {
            Fixed, Percent
        }

        public enum IncrementReason
        {
            Latency, Discount, PaperInvoice, Delay
        }
        public enum Block
        {
            NotBlocked, SharedAccount, Misused, FakeAccount, WrongInfo, UnPaid, Other
        }

        public enum Notifications
        {
            LectureStart, CourseUpdate, ImportantUpdate, OfferAndOther, Admin, InvoiceReminder, InvoiceReceipt, PlusApplicationReceivedUser, PlusApplicationReceivedOrg, PlusApplicationAccepted, CourseRegisterConfirmation, PlusApplicationInvoices
        }
        
        public enum NotifyMethod
        {
            Email, SMS, InSite
        }
        
        public enum OperatingSystem
        {
            Windows, Android, MacOS, Linux, UNIX,
        }
        public enum DeviceType
        {
            Computer, Mobile, iPad, MobileIPhone
        }

        public enum Activity
        {
            AccountRegister, LoginActivity, Payment, PasswordChange, CourseRegister, SigningAgreement, PhoneVerification
        }

        public enum Contact
        {
            GeneralQuestion, ErrorReport, Complaint, CancelCourseRegistration, InvoiceQuestion,  HavePreviousEnrollment, ReportWrongTranslation, HelpRequest, OtherCases, AdminMessage
            
        }

        public enum CourseStatus
        {
            Hidden, StartsSoon, Live, Ended, Archived
        }

        public enum VippsPaymentStatus
        {
            INVALID, RESERVE, CAPTURE, REFUND, INITIATE, SALE, REGISTER, VOID, FAILED, REJECTED, CANCEL
        }

        public enum ApplicationStatus
        {
            PendingCoursesChoosing, PendingDocuments, UnderProcessing, Accepted, Declined
        }

        public enum MatterixFileType
        {
            ProfilePicture, CoursePicture, CourseBackground, LectureFile, Homework, JobApplicationCv, MatterixPlusApproval
        }

        public enum MatterixPlusRegDocument
        {
            AboutSchool, CoursesDescription, Approval
        }

        public enum MatterixDocument
        {
            RegConfirmation
        }

        public enum OrderStatus
        {
            Initiated, Completed, Failed, Canceled, ActionRequired
        }

        //Add New Countries
        public enum Country
        {
            Norway,Sweden, Germany
        }

    }
}