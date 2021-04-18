using System;
using System.ComponentModel.DataAnnotations;
using Matterix.Services;
using Microsoft.AspNetCore.Identity;

namespace Matterix.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        
        public string PhoneCode { get; set; }

        public bool ShowFullName { get; set; } = true;
        
        public string CurrentPassword { get; set; }
        
        public string ProfileUserName { get; set; }
        public EnumList.Language Language { get; set; }
        public string PersonalNumber { get; set; }
        public EnumList.Gender Gender { get; set; }
        
        //ToDo :: Delete Role if not needed
        public EnumList.Role Role { get; set; } = EnumList.Role.Student;

        public string ProfilePicture { get; set; } = "";
//        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
//        [DataType(DataType.Date)]
        public DateTime SignUpDate { get; set; } = Format.NorwayDateTimeNow();
        
        public bool Discountable { get; set; }
        
        public bool SignedStudentAgreement { get; set; }
        public DateTime SignedStudentAgreementAt { get; set; }
        
        public string StatusMessage { get; set; }
        
        public bool Blocked { get; set; }
        [DataType(DataType.Date)]
        public DateTime BlockDate { get; set; }= Format.NorwayDateTimeNow();
        public EnumList.Block BlockType { get; set; }
        public string BlockDescription { get; set; }
    }
}