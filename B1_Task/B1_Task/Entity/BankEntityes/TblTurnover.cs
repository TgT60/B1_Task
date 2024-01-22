namespace B1_Task.Entity.BankEntityes
{
    public class TblTurnover
    {
        public int Id { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int TblSheetId { get; set; }
        public TblSheet TblSheet { get; set; }
    }
}
