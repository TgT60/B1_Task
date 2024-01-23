using B1_Task.Entity.BankEntities;

namespace B1_Task.Entity.BankEntityes
{
    public class TblSheetClass
    {
        public int Id { get; set; }
        public decimal SumOpenActiveBalance { get; set; }
        public decimal SumOpenPassiveBalance { get; set; }
        public decimal SumTurnoversDebit { get; set; }
        public decimal SumTurnoversCredit { get; set; }
        public decimal SumCloseActiveBalance { get; set; }
        public decimal SumClosePassiveBalance { get; set; }
        public ICollection<TblAccount> Account { get; set; }
        public ICollection<TblOpeningBalance> OpeningBalances { get; set; }
        public ICollection<TblClosedBalance> ClosedBalances { get; set; }
        public ICollection<TblTurnover> Turnovers { get; set; }
        public int TblSheetId { get; set; }
        public TblSheet TblSheet { get; set; }
    }
}
