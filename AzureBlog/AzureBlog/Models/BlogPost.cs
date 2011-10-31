using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AzureBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Tittel må være utfylt")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Tittel må være mellom 3 og 250 tegn.")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}