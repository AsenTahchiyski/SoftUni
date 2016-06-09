namespace DataLayer
{
    using System.Data.Entity;
    using Migrations;
    using Models;
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<ResourceLicense> Licenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(x =>
                {
                    x.MapLeftKey("StudentId");
                    x.MapRightKey("CourseId");
                    x.ToTable("StudentsCourses");
                });

            modelBuilder.Entity<Resource>()
                .HasMany(r => r.Licenses)
                .WithMany()
                .Map(l =>
                {
                    l.MapLeftKey("ResourceId");
                    l.MapRightKey("LicenseId");
                    l.ToTable("ResourcesLicenses");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}