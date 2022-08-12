namespace TechnicalAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AssetsModel : DbContext
    {
        public AssetsModel()
            : base("name=AssetsModel")
        {
        }

        public virtual DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
