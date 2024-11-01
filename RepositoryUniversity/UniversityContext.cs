using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Models;

namespace RepositoryUniversity
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext()
        {
        }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6GA8JD2\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Credits).HasColumnName("CREDITS");

                entity.Property(e => e.DepartamentId).HasColumnName("DEPARTAMENT_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME")
                    .IsFixedLength();

                entity.HasOne(d => d.Departament)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_DEPARTMENT");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("PROFESSOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentDepartmentId).HasColumnName("DEPARTMENT_DEPARTMENT_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(1000)
                    .HasColumnName("NAME");

                entity.Property(e => e.Salary).HasColumnName("SALARY");

                entity.HasOne(d => d.DepartmentDepartment)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.DepartmentDepartmentId)
                    .HasConstraintName("FK_PROFESSOR_DEPARTAMENT");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SCHEDULE");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.ProfessorId).HasColumnName("PROFESSOR_ID");

                entity.Property(e => e.Semester).HasColumnName("SEMESTER");

                entity.Property(e => e.Year).HasColumnName("YEAR");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCHEDULE_COURSE");

                entity.HasOne(d => d.Professor)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCHEDULE_PROFESSOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
