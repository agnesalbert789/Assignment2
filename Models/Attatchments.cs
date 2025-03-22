using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;




namespace GeorgianCollege.Models
{ 

    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }

        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        [Required]
        [StringLength(50)]
        public string FileType { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        public DateTime UploadedAt { get; set; }
    }
}



