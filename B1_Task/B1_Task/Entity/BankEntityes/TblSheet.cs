using B1_Task.Entity.BankEntities;

namespace B1_Task.Entity.BankEntityes
{
    public class TblSheet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal TotalSumOpenActiveBalance { get; set; }
        public decimal TotalSumOpenPassiveBalance { get; set; }
        public decimal TotalSumTurnoversDebit { get; set; }
        public decimal TotalSumTurnoversCredit { get; set; }
        public decimal TotalSumCloseActiveBalance { get; set; }
        public decimal TotalSumClosePassiveBalance { get; set; }
        public ICollection<TblSheetClass> SheetClasses { get; set; }
        public int TblBankId { get; set; }
        public TblBank Bank { get; set; }
    }
}
