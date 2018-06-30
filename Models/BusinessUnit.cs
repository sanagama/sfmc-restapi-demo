
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SfmcRestApiDemo.Models
{
    public class BusinessUnit
    {
        public BusinessUnit()
        {
            Contacts = new Collection<Contact>();
            Emails = new Collection<Email>();
        }
    
        [Key]
        public int MID { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}