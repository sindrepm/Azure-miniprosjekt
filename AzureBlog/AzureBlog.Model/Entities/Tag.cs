﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AzureBlog.Model.Entities
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
