namespace Domain
{
    public class HistEvent
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public ulong Tags { get; set; } // this is just a different way of storing an array
    }
}