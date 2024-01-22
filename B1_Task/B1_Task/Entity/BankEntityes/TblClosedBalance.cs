namespace B1_Task.Entity.BankEntityes
{
    public class TblClosedBalance
    {
        public int Id { get; set; }
        public decimal ActiveBalance { get; set; }
        public decimal PassiveBalance { get; set; }
        public int TblSheetId { get; set; }
        public TblSheet TblSheet { get; set; }
    }
}
