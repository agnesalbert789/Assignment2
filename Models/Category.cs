using System.ComponentModel.DataAnnotations;
using System;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace GeorgianCollege.Models
{
  
        public class Category
        {
            [Key]
            public int CategoryId { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [StringLength(200)]
            public string Description { get; set; }

            public ICollection<Ticket> Tickets { get; set; }
       
        }
    }


