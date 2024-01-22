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
    }
}
