 using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Matterix.Models
{
    public class Country
    {
        //ToDo :: If database needed, IsoCode will be the id
        [Key]
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string DialCode { get; set; }

        //Add New Countries
        public virtual ICollection<Course> Courses { get; set; }
        
    }
}