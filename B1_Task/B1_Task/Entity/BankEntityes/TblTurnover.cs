﻿namespace B1_Task.Entity.BankEntityes
{
    public class TblTurnover
    {
        public int Id { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int TblSheetClassId { get; set; }
        public TblSheetClass TblSheetClass { get; set; }
    }
}
