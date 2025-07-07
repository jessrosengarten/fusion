namespace TicketStatusAPI.Models
{
    public class Lookup
    {
        public int LookupID { get; set; }   // Primary Key - lookupID
        public string Class { get; set; }   // Class column
        public string Value { get; set; }   // Value of the lookup - from tStatus


    }
}
