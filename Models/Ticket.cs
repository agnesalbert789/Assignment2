using GeorgianCollege.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int? StatusId { get; set; }
    public Status Status { get; set; }

    public ICollection<Attachment> Attachments { get; set; } 
}
