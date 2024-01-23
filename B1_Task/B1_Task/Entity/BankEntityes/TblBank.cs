namespace B1_Task.Entity.BankEntityes
{
    public class TblBank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TblSheet> Sheets { get; set;}
    }
}
