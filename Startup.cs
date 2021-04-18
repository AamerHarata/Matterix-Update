using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Matterix.Data;
using Matterix.Models;
using Matterix.Models.Admin;
using Matterix.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Stripe;
using Twilio;

namespace Matterix
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;   
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            if (Environment.IsDevelopment())
            {
                if (StaticInformation.AdvancedDevelopment && !StaticInformation.AdvancedLive)
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(
                            Configuration.GetConnectionString("DefaultConnectionAdvanced")));
                    Console.WriteLine("Advanced, Postgres as test used ----------------------------------------------------");
                }
                else if (StaticInformation.AdvancedDevelopment && StaticInformation.AdvancedLive)
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(
                            Configuration.GetConnectionString("DefaultConnectionLive")));
                    Console.WriteLine("DANGER YOU ARE LIVE BE AWARE, Postgres LIVE used ----------------------------------------------------");
                }
                else
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlite(
                            Configuration.GetConnectionString("DefaultConnection")));
                    Console.WriteLine("Development, Sqlite used ----------------------------------------------------");
                }
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
                
                Console.WriteLine("Production, Postgres used ----------------------------------------------------");
            }



//            var client = new SmtpClient
//            {
//                Credentials = new NetworkCredential(StaticInformation.EmailSender, StaticInformation.EmailSenderPassword),
//                Host = "smtp-mail.outlook.com",
//                EnableSsl = true,
//                Port = 25
//            };
//
//            services
//                .AddFluentEmail(StaticInformation.EmailSender)
//                .AddRazorRenderer()
//                .AddSmtpSender(client);
            
            
            //Not in use
            var client = new SmtpClient
            {
                Credentials = new NetworkCredential(StaticInformation.EmailSender, StaticInformation.EmailSenderPassword),
                Host = "mail.uniweb.no",
                EnableSsl = false,
                Port = 587        
            };
            
            

            services
                .AddFluentEmail(StaticInformation.EmailSender)
                .AddRazorRenderer()
                .AddSmtpSender("mail.uniweb.no", 587  , StaticInformation.EmailSender, StaticInformation.EmailSenderPassword);


            services.AddDefaultIdentity<ApplicationUser>(
                    x =>
                    {
                        x.Password.RequiredLength = 6;
                        x.Password.RequireDigit = false;
                        x.Password.RequireUppercase = true;
                        x.Password.RequireLowercase = true;
                        x.Password.RequireNonAlphanumeric = false;
                    }
                    )
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            
            //Test hangfire
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();


            services.AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            

            //Register Services
            services.AddTransient<CourseService>();
            services.AddTransient<InformationService>();
            services.AddTransient<AccessService>();
            services.AddTransient<FilesService>();
            services.AddTransient<LectureService>();
            services.AddTransient<PaymentService>();
            services.AddTransient<AdminService>();
            services.AddTransient<EmailService>();
            services.AddTransient<NotificationsService>();
            services.AddTransient<SmsService>();
            services.AddTransient<PdfService>();
            
            
            
            
            
            
            
            
            // Special authorization for pages only admins can access // ToDo :: Check those policies first, then implement them inside all controllers like that [Authorize(Policy = "EditCourse")]
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
//                options.AddPolicy("EditCourse", policy => policy.RequireClaim("Role", "Admin"));
//                options.AddPolicy("EditCourse", policy => policy.RequireClaim("Role", "Teacher"));
                options.AddPolicy("AdminOrTeacher", policy => policy.RequireAssertion(context => context.User.HasClaim(c =>
                    c.Value == "Teacher" || c.Value == "Admin")));

            });
            
            
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.DataProtectionProvider = DataProtectionProvider.Create(Directory.CreateDirectory(Path.Combine(Environment.ContentRootPath, "wwwroot", "SystemFiles", "DataProtection")));
            });
            
            //Add redis on production to prevent users from logging out when project updates (All keys will be copied to redis server)
//            if (!Environment.IsDevelopment())
//            {
//                var redisHost = Configuration.GetValue<string>("Redis:Host");
//                var redisPort = Configuration.GetValue<int>("Redis:Port");
//                var redisIpAddress = Dns.GetHostEntryAsync(redisHost).Result.AddressList.Last();
//                var redis = ConnectionMultiplexer.Connect($"{redisIpAddress}:{redisPort}");
//                services.AddDataProtection()
//                                    .PersistKeysToStackExchangeRedis(redis, "DataProtection-Keys")
//                                    .SetApplicationName("Matterix-DataProtection")
//                                    .SetDefaultKeyLifetime(new TimeSpan(7, 0, 0, 0))
//                                    .AddKeyManagementOptions(x =>
//                                    {
//                                        x.NewKeyLifetime = new TimeSpan(7, 0, 0, 0);
//                                    });
//            }



//            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(Environment.ContentRootPath, "DataProtection")));
            
            
            //Hangfire test
//            services.AddHangfire(configuration => configuration
//                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//                .UseSimpleAssemblyNameTypeSerializer()
//                .UseRecommendedSerializerSettings()
//                .UsePostgreSqlStorage(Configuration.GetConnectionString("HangfireConnection")));
            
            //This is to sign out the blocked user immediately
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;   
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //ToDo :: Un comment this to try IP Address from server side on production --> See the next to do.
            // app.UseForwardedHeaders(new ForwardedHeadersOptions
            // {
            //     ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            // }); 
            
            //ToDo :: After you uncomment the previous. You have to copy next line in the place (Controller) where you want to get the IP from
            // var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseAuthentication();
            
            
            //Twilio configurations (Sending SMS)
            var accountSid = Configuration["Twilio:AccountSID"];
            var authToken = Configuration["Twilio:AuthToken"];
            TwilioClient.Init(accountSid, authToken);


            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            
            app.UseHangfireDashboard(
                pathMatch: "/Hangfire/Dashboard",
                options: new DashboardOptions() {
                    Authorization = new IDashboardAuthorizationFilter[] {
                        new HangfireAuthorizationFilter("Admin")
                    }
                });
            
            
            //Configure Payments
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
        }
    }
}
