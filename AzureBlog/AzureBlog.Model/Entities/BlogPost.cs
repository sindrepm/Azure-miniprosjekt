using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AzureBlog.Model.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Tittel må være utfylt")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Tittel må være mellom 3 og 250 tegn.")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        
        public DateTime LastModifiedDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}