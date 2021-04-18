using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Matterix.Models.ViewModel
{
    public class JobApplicationViewModel
    {
        public JobApplication Application { get; set; }
        public List<JobApplication> PreviousApplications { get; set; }
    }
}