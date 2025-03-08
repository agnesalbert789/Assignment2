using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeorgianCollege.Models
{
  
    
        public class Status
        {
            [Key]
            public int StatusId { get; set; }

            [Required]
            [StringLength(50)]
            public string Name { get; set; }

            [StringLength(200)]
            public string Description { get; set; }

            public ICollection<Ticket> Tickets { get; set; }
        }
    }
