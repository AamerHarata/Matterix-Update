using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Matterix.Models;
using Matterix.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Matterix.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, bool isDevelop)
        {
            if (!isDevelop || StaticInformation.AdvancedDevelopment)
            {
                context.Database.Migrate();
                return;
            }

            Console.WriteLine("Development Initializer run --------------------------------------------");
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges();
            
            
            //Test Area
            
            //*** Users ***//
            var admin1 = new ApplicationUser()
            {
                UserName = "Aamer.Harata@hotmail.com",
                Email = "Aamer.Harata@hotmail.com",
                Role = EnumList.Role.Admin,
                CurrentPassword = "Mmmm4444",
                FirstName = "Aamer",
                PhoneNumber = "45525288",
                LastName = "Harata",
                Gender = EnumList.Gender.Male,
                BirthDate = new DateTime(1989, 5, 30),
                Language = EnumList.Language.Arabic,
                SignUpDate = DateTime.Now,
                SecurityStamp = "SecurityStamp1231231sadasda21e123dasdasda"
            };
            
            admin1.ProfileUserName = admin1.FirstName + "." + admin1.LastName + admin1.BirthDate.Year;
            userManager.CreateAsync(admin1, "Mmmm4444").Wait();
            context.SaveChanges();
            
            userManager.AddClaimAsync(admin1, new Claim("Role", "Admin"));
            var myAddress1 = new Address()
            {
                User = admin1, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
            };
            context.Add(myAddress1);
            context.SaveChanges();
            
            
            var student1 = new ApplicationUser()
            {
                UserName = "aamerh17@uia.no",
                Email = "aamerh17@uia.no",
                CurrentPassword = "Mmmm4444",
                Role = EnumList.Role.Student,
                FirstName = "Aamer",
                PhoneNumber = "45525288",
                LastName = "Student",
                Gender = EnumList.Gender.Male,
                BirthDate = new DateTime(1989, 5, 30),
                Language = EnumList.Language.English

            };
            student1.ProfileUserName = student1.FirstName + "." + student1.LastName + student1.BirthDate.Year;
            userManager.CreateAsync(student1, "Mmmm4444").Wait();

            var teacher1 = new ApplicationUser()
            {
                UserName = "teacher@aa.com",
                CurrentPassword = "Mmmm4444",
                Email = "teacher@aa.com",
                Role = EnumList.Role.Teacher,
                FirstName = "Aamer",
                PhoneNumber = "45525288",
                LastName = "Teacher",
                BirthDate = new DateTime(1989, 5, 30),
                Gender = EnumList.Gender.Male,
                Language = EnumList.Language.English

            };
            
            teacher1.ProfileUserName = teacher1.FirstName + "." + teacher1.LastName + teacher1.BirthDate.Year;
            userManager.CreateAsync(teacher1, "Mmmm4444").Wait();
            context.SaveChanges();
            userManager.AddClaimAsync(teacher1, new Claim("Role", "Teacher"));
            
            
            var admin2 = new ApplicationUser()
            {
                UserName = "admin@aa.com",
                Email = "admin@aa.com",
                CurrentPassword = "Mmmm4444",
                Role = EnumList.Role.Admin,
                PhoneNumber = "45525288",
                FirstName = "Aamer",
                LastName = "Admin",
                BirthDate = new DateTime(1989, 5, 30),
                Gender = EnumList.Gender.Female,
                Language = EnumList.Language.English

            };
            
            admin2.ProfileUserName = admin2.FirstName + "." + admin2.LastName + admin2.BirthDate.Year;
            userManager.CreateAsync(admin2, "Mmmm4444").Wait();
            context.SaveChanges();
            userManager.AddClaimAsync(admin2, new Claim("Role", "Admin"));
            
            
            var address = new Address()
            {
                User = teacher1, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
            };
            
            var address1 = new Address()
            {
                User = student1, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
            };
            
            var address2 = new Address()
            {
                User = admin2, Street = "Krossmyrveien 4a", ZipCode = "4640", City = "Søgne"
            };

            context.Add(address);
            context.Add(address1);
            context.Add(address2);
            context.SaveChanges();
            
            //*** END OF USERS ***//
            
            
            
            //*** Courses ***//
            var courseR1 = new Course()
            {
                Subject = "Math R1", Language = EnumList.Language.English, Price = 2100, StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3), Teacher = teacher1, Code = "Matte-R1-H2019",
                ExtraDescription = "hei#%bye"
            };
            context.Add(courseR1);
            context.SaveChanges();
            var scheduleR11 = new Schedule()
            {
                Number = 1, Course = courseR1, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var scheduleR12 = new Schedule()
            {
                Number = 2, Course = courseR1, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(scheduleR11);
            context.Add(scheduleR12);
            context.SaveChanges();
            CreateLectures(courseR1.Id, new List<Schedule>(){scheduleR11, scheduleR12});
            
            
            
            var courseF1 = new Course()
            {
                Subject = "Fysikk F1", Language = EnumList.Language.English, Price = 0, StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4), Teacher = admin2, Code = "F1-H2019"
            };
            context.Add(courseF1);
            context.SaveChanges();
            
            
            var scheduleF11 = new Schedule()
            {
                Number = 1, Course = courseF1, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var scheduleF12 = new Schedule()
            {
                Number = 2, Course = courseF1, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(scheduleF11);
            context.Add(scheduleF12);
            context.SaveChanges();
            CreateLectures(courseF1.Id, new List<Schedule>(){scheduleF11, scheduleF12});
            
            
            
            var courseK1 = new Course()
            {
                Subject = "Kjemi K1", Language = EnumList.Language.English, Price = 2100, StartDate = new DateTime(2019, 3, 30),
                EndDate = new DateTime(2019, 6, 20), Teacher = admin1, Code = "K1-H2019"
            };
            context.Add(courseK1);
            context.SaveChanges();
            
            
            var scheduleK11 = new Schedule()
            {
                Number = 1, Course = courseK1, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var scheduleK12 = new Schedule()
            {
                Number = 2, Course = courseK1, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(scheduleK11);
            context.Add(scheduleK12);
            context.SaveChanges();
            CreateLectures(courseK1.Id, new List<Schedule>(){scheduleK11, scheduleK12});
            
            
            
            
            
            
            var course1P = new Course()
            {
                Subject = "Matte 1P", Language = EnumList.Language.English, Price = 2100, StartDate = new DateTime(2019, 3, 30),
                EndDate = new DateTime(2019, 6, 20), Teacher = admin1, Code = "1P-H2019"
            };
            context.Add(course1P);
            context.SaveChanges();
            
            
            var schedule1P1 = new Schedule()
            {
                Number = 1, Course = course1P, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var schedule1P2 = new Schedule()
            {
                Number = 2, Course = course1P, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(schedule1P1);
            context.Add(schedule1P2);
            context.SaveChanges();
            CreateLectures(course1P.Id, new List<Schedule>(){schedule1P1, schedule1P2});
            
            
            
            var courseNOR3 = new Course()
            {
                Subject = "Matte NOR3", Language = EnumList.Language.English, Price = 2100, StartDate = new DateTime(2019, 3, 30),
                EndDate = new DateTime(2019, 6, 20), Teacher = admin1, Code = "NOR3-H2019"
            };
            context.Add(courseNOR3);
            context.SaveChanges();
            
            
            var scheduleNOR31 = new Schedule()
            {
                Number = 1, Course = courseNOR3, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var scheduleNOR32 = new Schedule()
            {
                Number = 2, Course = courseNOR3, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(scheduleNOR31);
            context.Add(scheduleNOR32);
            context.SaveChanges();
            CreateLectures(courseNOR3.Id, new List<Schedule>(){scheduleNOR31, scheduleNOR32});
            
            
            
            var courseENG1 = new Course()
            {
                Subject = "Matte ENG1", Language = EnumList.Language.English, Price = 2100, StartDate = new DateTime(2019, 3, 30),
                EndDate = new DateTime(2019, 6, 20), Teacher = admin1, Code = "ENG1-H2019"
            };
            context.Add(courseENG1);
            context.SaveChanges();
            
            
            var scheduleENG11 = new Schedule()
            {
                Number = 1, Course = courseENG1, Day = EnumList.Days.Thursday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };
            var scheduleENG12 = new Schedule()
            {
                Number = 2, Course = courseENG1, Day = EnumList.Days.Friday, From = new TimeSpan(10, 5,0), To = new TimeSpan(11,5,0)
            };

            context.Add(scheduleENG11);
            context.Add(scheduleENG12);
            context.SaveChanges();
            CreateLectures(courseENG1.Id, new List<Schedule>(){scheduleENG11, scheduleENG12});
            
            
            
            
            
            
            
            

            

            
//            CreateLectures(context, course2, schedule20, schedule21);
            
            var registration = new Registration()
            {
                Student = student1, Course = courseR1, Price = courseR1.Price, RegisterDate = DateTime.Now.AddYears(-1), AdminComment = "This student is me", AuthCookies = "1234567891011121314151617181920", IpAddress = "192.168.2.1", ExpireDate = DateTime.Now, Expire = true
            };
            context.Add(registration);
            context.SaveChanges();
            
            var registration1 = new Registration()
            {
                Student = student1, Course = courseK1, Price = courseK1.Price, RegisterDate = DateTime.Now, AdminComment = "This student is me", AuthCookies = "1234567891011121314151617181920", IpAddress = "192.168.2.1", ExpireDate = DateTime.Now.AddYears(1),
            };
            context.Add(registration1);
            context.SaveChanges();
            
 
            
            var registration10 = new Registration()
            {
                Student = teacher1, Course = courseF1, Price = courseF1.Price, RegisterDate = DateTime.Now, AdminComment = "This student is teacher", AuthCookies = "1234567891011121314151617181920", IpAddress = "192.168.2.1", ExpireDate = DateTime.Now.AddYears(1)
            };
            context.Add(registration10);
            context.SaveChanges();
            
            
            var registration2 = new Registration()
            {
                Student = teacher1, Course = courseENG1, Price = courseF1.Price, RegisterDate = DateTime.Now, AdminComment = "This student is teacher", AuthCookies = "1234567891011121314151617181920", IpAddress = "192.168.2.1", ExpireDate = DateTime.Now
            };
            context.Add(registration2);
            context.SaveChanges();
            
            
            
            var invoice1 = new MatterixInvoice()
            {
                User = student1, Course = courseK1, Amount = 600, OriginalDueDate = DateTime.Now.AddDays(-1), OriginalDeadline = DateTime.Now.AddDays(15), Reason = EnumList.InvoiceReason.MonthlyPayment,
                CurrentAmount = 600, CurrentDeadline = DateTime.Now.AddDays(15), CurrentDueDate = DateTime.Now.AddDays(-1)
            };
            
            context.Add(invoice1);
            context.SaveChanges();
            
            var invoice2 = new MatterixInvoice()
            {
                User = student1, Course = courseK1, Amount = 800, OriginalDueDate = DateTime.Now.AddDays(-15), OriginalDeadline = DateTime.Now.AddDays(-1), Reason = EnumList.InvoiceReason.MonthlyPayment,
                CurrentAmount = 600, CurrentDeadline = DateTime.Now.AddDays(-1), CurrentDueDate = DateTime.Now.AddDays(-15)
            };
            
            context.Add(invoice2);
            context.SaveChanges();
            
            
            
            


            void CreateLectures(string courseId, List<Schedule> schedules)
            {
                var coursee = context.Courses.Find(courseId);
                if(coursee == null)
                    return;

                //Order schedules by number
                schedules = schedules.OrderBy(x => x.Number).ToList();
                var count = schedules.Count;


                var lectureDate = coursee.StartDate;
                var lectures = new List<Lecture>();
                var lectureNumber = 1;

                while (lectureDate <= coursee.EndDate)
                {
                    foreach (var schedule in schedules)
                    {
                    
                        if (string.Compare( schedule.Day.ToString(), lectureDate.DayOfWeek.ToString(), StringComparison.CurrentCultureIgnoreCase) == 0)
                        {
                            var lecture = new Lecture()
                            {
                                Course = coursee, Number = lectureNumber, Day = schedule.Day, From = schedule.From,
                                To = schedule.To, Date = lectureDate
                            };

                            context.Add(lecture);
                            context.SaveChanges();
                            lectureNumber++;
                        }
                    }

                    lectureDate = lectureDate.AddDays(1);
                }
            }
            
            
            
            
        }
    }
}