namespace B1_Task.Entity.BankEntityes
{
    public class TblBank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string LastDate { get; set; }
        public ICollection<TblSheet> Sheets { get; set;}
    }
}
