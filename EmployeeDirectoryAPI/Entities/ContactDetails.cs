using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Contact details of an Employee,
 * This Entity has one to one relationship with Employee Entity.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class ContactDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(10)]
        public int MobNumberOff { get; set; }

        [Required]
        [MaxLength(10)]
        public int MobNumberPersonal { get; set; }

        [Required]
        [MaxLength(30)]
        public String SkypeID { get; set; }

        public String SlackID { get; set; }
        public String Address { get; set; }
        public String FBLink { get; set; }
        public String TwitterLink { get; set; }
        public String GitHubLink { get; set; }
        public String linkdinLink { get; set; }

        //public Employee Employee { get; set; }

    }
}
