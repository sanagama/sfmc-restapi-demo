
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SfmcRestApiDemo.Models
{
    public class Content
    {
        public Content()
        {
        }
    
        [Key]
        public int ContentKey { get; set; }
    
        public int MessageKey { get; set; }

        [ForeignKey("MessageKey")]
        public Email Email { get; set; }

        public string HtmlContent { get; set; }

        public string TextContent { get; set; }
    }
}