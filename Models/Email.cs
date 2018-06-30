
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SfmcRestApiDemo.Models
{
    public class Email
    {
        public Email()
        {
        }
    
        [Key]
        public int MessageKey { get; set; }
    
        public int MID { get; set; }
        
        [ForeignKey("MID")]
        public BusinessUnit BusinessUnit { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
    }
}