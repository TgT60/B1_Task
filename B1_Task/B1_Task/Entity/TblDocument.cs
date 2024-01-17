using B1_Task.Function.Document;
using Microsoft.Extensions.Hosting;

namespace B1_Task.Entity
{
    public class TblDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TblContent>  Contents { get; } = new List<TblContent>();

    }
}
