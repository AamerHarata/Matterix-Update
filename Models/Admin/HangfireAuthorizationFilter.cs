using Hangfire.Dashboard;
using Hangfire.PostgreSql.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Matterix.Models.Admin
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter {
        private string policyName;

        public HangfireAuthorizationFilter(string policyName) {
            this.policyName = policyName;
        }

        public bool Authorize([NotNull] DashboardContext context) {
            var httpContext = context.GetHttpContext();
            var authService = httpContext.RequestServices.GetRequiredService<IAuthorizationService>();
            return authService.AuthorizeAsync(httpContext.User, this.policyName).ConfigureAwait(false).GetAwaiter().GetResult().Succeeded;
        }
    }
}