using B1_Task.Entity.BankEntities;
using B1_Task.Entity.BankEntityes;
using Microsoft.EntityFrameworkCore;

namespace B1_Task.Entity
{
    public class B1Context : DbContext
    {
        public B1Context(DbContextOptions options) :base(options)
        { }

        public virtual DbSet<TblDocument> TblDocuments { get; set; }
        public virtual DbSet<TblContent> TblContents { get; set; }
        public virtual DbSet<TblProcedureResult> TblProcedureResults { get; set; }
        public virtual DbSet<TblBank> TblBanks { get; set; }
        public virtual DbSet<TblSheet> TblSheets { get; set; }
        public virtual DbSet<TblSheetClass> TblSheetClasses { get; set; }
        public virtual DbSet<TblOpeningBalance> TblOpeningBalances { get; set; }
        public virtual DbSet<TblAccount> TblAccounts { get; set; }
        public virtual DbSet<TblClosedBalance> TblClosedBalances { get; set; }
        public virtual DbSet<TblTurnover> TblTurnovers { get; set; }
    }
}
