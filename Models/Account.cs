
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SfmcRestApiDemo.Models
{
    public class Account
    {
        public Account()
        {
            BusinessUnits = new Collection<BusinessUnit>();
        }
    
        [Key]
        public int AccountId { get; set; }
    
        [Required]
        public string Name { get; set; }
    
        public virtual ICollection<BusinessUnit> BusinessUnits { get; set; }
    }
}