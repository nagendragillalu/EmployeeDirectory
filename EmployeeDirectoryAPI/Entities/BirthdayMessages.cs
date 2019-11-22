using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Birthday Greentings messages,
 * Which would be randomly picked to mail body when any one greets through front end.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class BirthdayMessages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [Required]
        [MaxLength(350)]
        public String MessageData { get; set; }

    }
}
