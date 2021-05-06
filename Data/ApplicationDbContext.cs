using Matterix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<CourseRating> Ratings { get; set; }
        public DbSet<CourseFeedback> CourseFeedback { get; set; }
        public DbSet<LectureFile> Files { get; set; }
        public DbSet<LectureVideo> Videos { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<OpenLecture> OpenLectures { get; set; }
        public DbSet<UsedPassword> UsedPasswords { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<NoNotification> NoNotifications { get; set; }
        public DbSet<MatterixInvoice> Invoices { get; set; }
        public DbSet<MatterixPayment> Payments { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<InvoiceIncrement> Increments { get; set; }
        public DbSet<DiscordLink> DiscordLink { get; set; }
        public DbSet<InitiatedOrder> InitiatedOrders { get; set; }
        public DbSet<Notification>  Notifications { get; set; }
        public DbSet<JobApplication>  JobApplications { get; set; }
        
        public DbSet<MatterixPlusApplication>  PlusApplications { get; set; }
        
        public DbSet<MatterixFile> MatterixFiles { get; set; }
        
        public DbSet<PlusApplicationFile> PlusApplicationFiles { get; set; }

        public DbSet<Country> Country { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Auto Generate Ids
            builder.Entity<ApplicationUser>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Address>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<ContactMessage>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Course>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Country>()
                .Property(x => x.IsoCode)
                .ValueGeneratedOnAdd();

            builder.Entity<CourseFeedback>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<DiscordLink>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<InvoiceIncrement>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<JobApplication>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Lecture>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<MatterixFile>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<MatterixPayment>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<MatterixPlusApplication>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<Notification>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<PlusApplicationFile>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<UsedPassword>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<UserDevice>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            
            
            
            
            //Combined keys
            builder.Entity<Schedule>()
                .HasKey(s => new {s.CourseId, s.Number});
            builder.Entity<Registration>()
                .HasKey(s => new {s.StudentId, s.CourseId});
            builder.Entity<CourseRating>()
                .HasKey(s => new {s.CourseId, s.UserId});
            builder.Entity<LectureFile>()
                .HasKey(s => new {s.Name, s.LectureId});
            builder.Entity<LectureVideo>()
                .HasKey(s => new {s.VideoNumber, s.LectureId});
            builder.Entity<Homework>()
                .HasKey(s => new {s.LectureFileName, s.LectureFileLectureId, s.StudentId});
            builder.Entity<OpenLecture>()
                .HasKey(s => new {s.LectureId, s.StudentId});
            builder.Entity<NoNotification>()
                .HasKey(s => new {s.UserId, s.NotificationType, s.Method});
            
            //Other primary keys than Id
            builder.Entity<MatterixInvoice>()
                .HasKey(x => x.Number);
        }
    }
    
    
    
}
