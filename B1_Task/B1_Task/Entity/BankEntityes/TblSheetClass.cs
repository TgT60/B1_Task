namespace B1_Task.Entity.BankEntityes
{
    public class TblSheetClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SheetId { get; set; }
        public TblSheet TblSheet { get; set; }
    }
}
