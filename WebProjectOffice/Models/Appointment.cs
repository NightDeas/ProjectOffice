namespace WebProjectOffice.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Text { get; set; }
    }
}
