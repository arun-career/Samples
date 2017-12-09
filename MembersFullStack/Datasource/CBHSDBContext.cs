namespace CBHS.Datasource
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CBHSDBContext : DbContext
    {
        public CBHSDBContext()
            : base("name=CBHSDBContext")
        {
        }

        public virtual DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.DateOfBirth)
                .IsUnicode(false);
        }
    }
}
