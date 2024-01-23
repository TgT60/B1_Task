using B1_Task.Entity.BankEntities;

namespace B1_Task.Entity.BankEntityes
{
    public class TblAccount
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public int TblSheetClassId { get; set; }
        public TblSheetClass TblSheetClass { get; set; }

    }
}
