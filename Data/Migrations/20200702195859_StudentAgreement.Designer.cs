﻿// <auto-generated />
using System;
using Matterix.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Matterix.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200702195859_StudentAgreement")]
    partial class StudentAgreement
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Matterix.Models.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Street");

                    b.Property<string>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Matterix.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("BlockDate");

                    b.Property<string>("BlockDescription");

                    b.Property<int>("BlockType");

                    b.Property<bool>("Blocked");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CurrentPassword");

                    b.Property<bool>("Discountable");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<int>("Language");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PersonalNumber");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePicture");

                    b.Property<string>("ProfileUserName");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("ShowFullName");

                    b.Property<DateTime>("SignUpDate");

                    b.Property<bool>("SignedStudentAgreement");

                    b.Property<DateTime>("SignedStudentAgreementAt");

                    b.Property<string>("StatusMessage");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Matterix.Models.ContactMessage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthCookies");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Email");

                    b.Property<string>("FileGetPath");

                    b.Property<string>("FileName");

                    b.Property<string>("FileRootPath");

                    b.Property<string>("Ip");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("Processed");

                    b.Property<int>("Reason");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ContactMessages");
                });

            modelBuilder.Entity("Matterix.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassUrl");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("Ended");

                    b.Property<string>("ExtraDescription");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("InstallmentAvailable");

                    b.Property<int>("Language");

                    b.Property<int>("MaxStudents");

                    b.Property<string>("MeetingId");

                    b.Property<string>("MeetingPass");

                    b.Property<string>("Picture");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("TeacherId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Matterix.Models.CourseFeedback", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseFeedback");
                });

            modelBuilder.Entity("Matterix.Models.CourseRating", b =>
                {
                    b.Property<string>("CourseId");

                    b.Property<string>("UserId");

                    b.Property<int>("Rating");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Matterix.Models.DiscordLink", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("DiscordLink");
                });

            modelBuilder.Entity("Matterix.Models.Homework", b =>
                {
                    b.Property<string>("LectureFileName");

                    b.Property<string>("LectureFileLectureId");

                    b.Property<string>("StudentId");

                    b.Property<int>("Mark");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("RootPath");

                    b.HasKey("LectureFileName", "LectureFileLectureId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Homework");
                });

            modelBuilder.Entity("Matterix.Models.InvoiceIncrement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvoiceNumber");

                    b.Property<DateTime>("NewDeadline");

                    b.Property<DateTime>("NewDueDate");

                    b.Property<int>("Reason");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceNumber");

                    b.ToTable("Increments");
                });

            modelBuilder.Entity("Matterix.Models.Lecture", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Day");

                    b.Property<string>("Description");

                    b.Property<bool>("Free");

                    b.Property<TimeSpan>("From");

                    b.Property<bool>("Introduction");

                    b.Property<int>("Number");

                    b.Property<string>("Preparation");

                    b.Property<string>("Title");

                    b.Property<TimeSpan>("To");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("Matterix.Models.LectureFile", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("LectureId");

                    b.Property<DateTime>("DeadLine");

                    b.Property<bool>("IsHomeWork");

                    b.Property<string>("Path");

                    b.Property<string>("RootPath");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("Name", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Matterix.Models.LectureVideo", b =>
                {
                    b.Property<int>("VideoNumber");

                    b.Property<string>("LectureId");

                    b.Property<string>("Name");

                    b.Property<string>("UniqueCode");

                    b.Property<string>("Url");

                    b.HasKey("VideoNumber", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Matterix.Models.MatterixInvoice", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CIDNumber");

                    b.Property<bool>("Canceled");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime>("Deadline");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("ExtraDescription");

                    b.Property<int>("InvoiceType");

                    b.Property<bool>("Moved");

                    b.Property<string>("MovedTo");

                    b.Property<bool>("Paid");

                    b.Property<string>("PaymentId");

                    b.Property<int>("Reason");

                    b.Property<string>("UserId");

                    b.HasKey("Number");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Matterix.Models.MatterixPayment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("CourseId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("ExtraDescription");

                    b.Property<int>("InvoiceNumber");

                    b.Property<int>("Method");

                    b.Property<string>("PaymentServiceRef");

                    b.Property<int>("Reason");

                    b.Property<bool>("Refunded");

                    b.Property<DateTime>("RefundedAt");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InvoiceNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Matterix.Models.NoNotification", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("NotificationType");

                    b.HasKey("UserId", "NotificationType");

                    b.ToTable("NoNotifications");
                });

            modelBuilder.Entity("Matterix.Models.OpenLecture", b =>
                {
                    b.Property<string>("LectureId");

                    b.Property<string>("StudentId");

                    b.Property<DateTime>("ExpireDate");

                    b.HasKey("LectureId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("OpenLectures");
                });

            modelBuilder.Entity("Matterix.Models.Registration", b =>
                {
                    b.Property<string>("StudentId");

                    b.Property<string>("CourseId");

                    b.Property<string>("AdminComment");

                    b.Property<string>("AuthCookies");

                    b.Property<bool>("Canceled");

                    b.Property<string>("DiscountCard");

                    b.Property<bool>("Expire");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<string>("IpAddress");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("Matterix.Models.Schedule", b =>
                {
                    b.Property<string>("CourseId");

                    b.Property<int>("Number");

                    b.Property<int>("Day");

                    b.Property<TimeSpan>("From");

                    b.Property<TimeSpan>("To");

                    b.HasKey("CourseId", "Number");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Matterix.Models.UsedPassword", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Password");

                    b.Property<string>("PlaceCreated");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsedPasswords");
                });

            modelBuilder.Entity("Matterix.Models.UserDevice", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Activity");

                    b.Property<string>("AuthCookies");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("DeviceType");

                    b.Property<int>("GroupNumber");

                    b.Property<string>("Ip");

                    b.Property<bool>("New");

                    b.Property<int>("OperatingSystem");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserDevices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Matterix.Models.Address", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.ContactMessage", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.Course", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.CourseFeedback", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.CourseRating", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.Homework", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.LectureFile", "LectureFile")
                        .WithMany()
                        .HasForeignKey("LectureFileName", "LectureFileLectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.InvoiceIncrement", b =>
                {
                    b.HasOne("Matterix.Models.MatterixInvoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceNumber")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.Lecture", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Matterix.Models.LectureFile", b =>
                {
                    b.HasOne("Matterix.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.LectureVideo", b =>
                {
                    b.HasOne("Matterix.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.MatterixInvoice", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.MatterixPayment", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("Matterix.Models.MatterixInvoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceNumber")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.NoNotification", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.OpenLecture", b =>
                {
                    b.HasOne("Matterix.Models.Lecture", "Lecture")
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.Registration", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.ApplicationUser", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.Schedule", b =>
                {
                    b.HasOne("Matterix.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Matterix.Models.UsedPassword", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Matterix.Models.UserDevice", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Matterix.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Matterix.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
