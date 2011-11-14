using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AzureBlog.Model.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Navn må være utfylt")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Epost må være utfylt")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kommentar må være utfylt.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public virtual BlogPost Post { get; set; }
    }
}