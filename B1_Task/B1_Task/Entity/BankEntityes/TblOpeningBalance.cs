using B1_Task.Entity.BankEntityes;

namespace B1_Task.Entity.BankEntities
{
    public class TblOpeningBalance
    {
        public int Id { get; set; }
        public decimal ActiveBalance { get; set;}
        public decimal PassiveBalance { get; set;}
        public int TblSheetClassId { get; set; }
        public TblSheetClass TblSheetClass { get; set; }
    }
}
