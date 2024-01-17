using System.Reflection.Metadata;

namespace B1_Task.Entity
{
    public class TblContent
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string StringEU { get; set; }
        public string StringRU { get; set; }
        public string PositiveNumber { get; set; }
        public string FolatNumber { get; set; }
        public int TblDocumentId { get; set; }
        public TblDocument Document { get; set; } = null!;
    }
}
 