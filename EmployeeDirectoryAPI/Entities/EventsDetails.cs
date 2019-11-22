using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This is Independent Entity with All The Events details.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class EventsDetails
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Venu { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime EventFromTime { get; set; }

        [Required]
        public DateTime EventToTime { get; set; }
        public String EventTimeZone { get; set; }

        [Required]
        [MaxLength(50)]
        public String Organizer { get; set; }

        [Required]
        [MaxLength(20)]
        public String EventName { get; set; }

        [MaxLength(250)]
        public String EvenPhotoURL { get; set; }

        [MaxLength(250)]
        public String EvenDiscription { get; set; }


    }
}
