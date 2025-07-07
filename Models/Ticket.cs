namespace TicketStatusAPI.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }   //Primary Key
        public int? tStatus { get; set; }   // Foreign Key
    }
}
