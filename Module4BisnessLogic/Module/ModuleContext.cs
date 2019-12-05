using ModuleDal.Models;
using System.Data.Entity;

namespace ModuleDal
{
    public class ModuleContext : DbContext
    {
        public ModuleContext() : base(@"Server=.; DataBase=Module;Initial Catalog=Task;Trusted_Connection=True;")
        {
        
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
