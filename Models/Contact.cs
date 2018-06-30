
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SfmcRestApiDemo.Models
{
    public class Contact
    {
        public Contact()
        {
        }
    
        [Key]
        public int ContactKey { get; set; }
    
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int MID { get; set; }
        
        [ForeignKey("MID")]
        public BusinessUnit BusinessUnit { get; set; }
    }
}