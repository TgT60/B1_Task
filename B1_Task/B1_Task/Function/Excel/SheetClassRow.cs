namespace B1_Task.Function.Excel
{
    public class SheetClassRow
    {
        public string Account { get; set; }
        public decimal OpenActiveBalance { get; set; }
        public decimal OpenPassiveBalance { get; set; }
        public decimal TurnoversDebit { get; set; }
        public decimal TurnoversCredit { get; set; }
        public decimal CloseActiveBalance { get; set; }
        public decimal ClosePassiveBalance { get; set; }
    }
}