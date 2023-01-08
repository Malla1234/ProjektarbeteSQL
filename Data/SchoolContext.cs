using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjektarbeteSQL.Models;

namespace ProjektarbeteSQL.Data
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<EmploAdmin> EmploAdmins { get; set; } = null!;
        public virtual DbSet<EmploOther> EmploOthers { get; set; } = null!;
        public virtual DbSet<EmploTeacher> EmploTeachers { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D4HUDUG; Initial Catalog=SchoolRegister;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).ValueGeneratedNever();

                entity.Property(e => e.Class1)
                    .HasMaxLength(3)
                    .HasColumnName("Class");
            });

            modelBuilder.Entity<EmploAdmin>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("EmploAdmin");

                entity.Property(e => e.AdminId).ValueGeneratedNever();

                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");

                entity.Property(e => e.Fname).HasMaxLength(30);

                entity.Property(e => e.Lname).HasMaxLength(30);

                entity.Property(e => e.Position).HasMaxLength(30);
            });

            modelBuilder.Entity<EmploOther>(entity =>
            {
                entity.HasKey(e => e.EmploId);

                entity.ToTable("EmploOther");

                entity.Property(e => e.EmploId).ValueGeneratedNever();

                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");

                entity.Property(e => e.Fname).HasMaxLength(30);

                entity.Property(e => e.Lname).HasMaxLength(30);

                entity.Property(e => e.Position).HasMaxLength(30);
            });

            modelBuilder.Entity<EmploTeacher>(entity =>
            {
                entity.HasKey(e => e.TeacherId);

                entity.ToTable("EmploTeacher");

                entity.Property(e => e.TeacherId).ValueGeneratedNever();

                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");

                entity.Property(e => e.Fname).HasMaxLength(30);

                entity.Property(e => e.Lname).HasMaxLength(30);

                entity.Property(e => e.Subject).HasMaxLength(30);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FkStudId).HasColumnName("FK_StudId");

                entity.Property(e => e.FkTeacherId).HasColumnName("FK_TeacherId");

                entity.Property(e => e.Grade1).HasColumnName("Grade");

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.HasOne(d => d.FkTeacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FkTeacherId)
                    .HasConstraintName("FK_Grade_EmploTeacher");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudId);

                entity.ToTable("Student");

                entity.Property(e => e.StudId).ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FkClassId).HasColumnName("FK_ClassId");

                entity.Property(e => e.Fname).HasMaxLength(50);

                entity.Property(e => e.Lname).HasMaxLength(50);

                entity.Property(e => e.Ssn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SSN");

                entity.HasOne(d => d.FkClass)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FkClassId)
                    .HasConstraintName("FK_Student_Class");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.Property(e => e.StudentGradeId).ValueGeneratedNever();

                entity.Property(e => e.FkGradeId).HasColumnName("FK_GradeId");

                entity.Property(e => e.FkStudId).HasColumnName("FK_StudId");

                entity.HasOne(d => d.FkGrade)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkGradeId)
                    .HasConstraintName("FK_StudentGrades_Grade");

                entity.HasOne(d => d.FkStud)
                    .WithMany(p => p.StudentGrades)
                    .HasForeignKey(d => d.FkStudId)
                    .HasConstraintName("FK_StudentGrades_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
