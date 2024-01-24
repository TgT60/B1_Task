using B1_Task.Entity.BankEntityes;

namespace B1_Task.Models
{
    public class ExcelViewModel
    {
        public List<TblBank> Banks { get; set; }
        public List<TblSheet> Sheets { get; set; }
        public List<TblSheetClass> SheetClasses { get; set; }
    }
}
