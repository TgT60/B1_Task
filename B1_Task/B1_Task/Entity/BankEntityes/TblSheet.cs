using B1_Task.Entity.BankEntities;

namespace B1_Task.Entity.BankEntityes
{
    public class TblSheet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public ICollection<TblOpeningBalance> OpeningBalances { get; set; }
        public ICollection<TblClosedBalance> ClosedBalances { get; set; }
        public ICollection<TblTurnover> Turnovers { get; set; }
        public ICollection<TblSheetClass> TblSheetClases { get; set; }
        public int TblBankId { get; set; }
        public TblBank Bank { get; set; }
    }
}
