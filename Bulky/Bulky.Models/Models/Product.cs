﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Models
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string ISBN { get; set; }


        [Required]
        [DisplayName("List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }


        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }


        [Required]
        [DisplayName("Price for 50-100")]
        [Range(1, 1000)]
        public double Price50 { get; set; }


        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
    }
}
