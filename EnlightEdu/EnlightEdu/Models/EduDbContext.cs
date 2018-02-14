using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;

namespace EnlightEdu.Models
{
    public class EduDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<Student>().HasMany(i => i.Subjects).WithRequired().WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>()
                   .HasMany<Subject>(s => s.Subjects)
                   .WithMany(c => c.Students)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("StudentRefId");
                       cs.MapRightKey("CourseRefId");
                       cs.ToTable("StudentCourse");
                   });
        }


    }
}