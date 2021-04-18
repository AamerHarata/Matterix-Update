using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;

namespace Matterix.Models
{
    public class OpenLecture
    {
        public string LectureId { get; set; }
        public Lecture Lecture { get; set; }
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        [DataType(DataType.Date)] public DateTime ExpireDate { get; set; } = Format.NorwayDateNow().AddDays(5);

    }
}