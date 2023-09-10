using School_version1.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_version1.Models.DTOs
{
    public class ManagementInfo
    {
        public Guid Id { get; set; }
        public string NameManagement { get; set; } = string.Empty;
        public string PhoneManagement  { get; set; } = string.Empty; 
        public string EmailManagement { get; set; } = string.Empty;


    }
}
