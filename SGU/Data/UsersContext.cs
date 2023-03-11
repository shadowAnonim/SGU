using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SGU;

namespace SGU.Data;

public partial class UsersContext : DbContext
{
    public UsersContext()
    {
    }

    public UsersContext(DbContextOptions<UsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CertificateOriginality> CertificateOriginalities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Direction> Directions { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<FormOfStudy> FormOfStudies { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<IndividualAchivment> IndividualAchivments { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\Evgeny\\source\\repos\\SGU\\SGU\\Users.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CertificateOriginality>(entity =>
        {
            entity.ToTable("Certificate_originality");

            entity.HasIndex(e => e.Id, "IX_Certificate_originality_Id").IsUnique();

            entity.HasIndex(e => e.Originality, "IX_Certificate_originality_Originality").IsUnique();

            entity.Property(e => e.Originality).HasColumnType("VARCHAR (3, 15)");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.HasIndex(e => e.Id, "IX_City_Id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_City_Name").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (3, 50)");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.ToTable("Direction");

            entity.HasIndex(e => e.Id, "IX_Direction_Id").IsUnique();

            entity.Property(e => e.FirstExamId).HasColumnName("First_exam_id");
            entity.Property(e => e.SecondExamId).HasColumnName("Second_exam_id");
            entity.Property(e => e.ThirdExamId).HasColumnName("Third_exam_id");

            entity.HasOne(d => d.FirstExam).WithMany(p => p.DirectionFirstExams)
                .HasForeignKey(d => d.FirstExamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SecondExam).WithMany(p => p.DirectionSecondExams)
                .HasForeignKey(d => d.SecondExamId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ThirdExam).WithMany(p => p.DirectionThirdExams)
                .HasForeignKey(d => d.ThirdExamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.ToTable("Exam");

            entity.HasIndex(e => e.Id, "IX_Exam_Id").IsUnique();

            entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FormOfStudy>(entity =>
        {
            entity.ToTable("Form_of_study");

            entity.HasIndex(e => e.From, "IX_Form_of_study_From").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Form_of_study_Id").IsUnique();

            entity.Property(e => e.From).HasColumnType("VARCHAR (5, 20)");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.HasIndex(e => e.Gender1, "IX_Gender_Gender").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Gender_Id").IsUnique();

            entity.Property(e => e.Gender1)
                .HasColumnType("VARCHAR (3, 15)")
                .HasColumnName("Gender");
        });

        modelBuilder.Entity<IndividualAchivment>(entity =>
        {
            entity.ToTable("Individual_achivment");

            entity.HasIndex(e => e.Id, "IX_Individual_achivment_Id").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.IndividualAchivments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.HasIndex(e => e.Id, "IX_Subject_Id").IsUnique();

            entity.HasIndex(e => e.Name, "IX_Subject_Name").IsUnique();

            entity.Property(e => e.Name).HasColumnType("VARCHAR (3, 20)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.HasIndex(e => e.EMail, "IX_User_e-mail").IsUnique();

            entity.HasIndex(e => e.Id, "IX_User_Id").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "IX_User_Phone_number").IsUnique();

            entity.Property(e => e.BornDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Born_date");
            entity.Property(e => e.BornPlace)
                .HasColumnType("VARCHAR (10, 100)")
                .HasColumnName("Born_place");
            entity.Property(e => e.CerificateOriginalityId).HasColumnName("Cerificate_originality_id");
            entity.Property(e => e.CertificateNumber).HasColumnName("Certificate_number");
            entity.Property(e => e.CertificateScan).HasColumnName("Certificate_scan");
            entity.Property(e => e.CityId).HasColumnName("City_id");
            entity.Property(e => e.DirectionId).HasColumnName("Direction_id");
            entity.Property(e => e.DivisionCode).HasColumnName("Division_code");
            entity.Property(e => e.EMail)
                .HasColumnType("VARCHAR (5, 100)")
                .HasColumnName("e-mail");
            entity.Property(e => e.FirstName)
                .HasColumnType("VARCHAR (2, 50)")
                .HasColumnName("First_name");
            entity.Property(e => e.FlatNumber).HasColumnName("Flat_number");
            entity.Property(e => e.FormOfStudyId).HasColumnName("Form_of_study_id");
            entity.Property(e => e.GenderId).HasColumnName("Gender_id");
            entity.Property(e => e.HomeNumber).HasColumnName("Home_number");
            entity.Property(e => e.LastName)
                .HasColumnType("VARCHAR (2, 50)")
                .HasColumnName("Last_name");
            entity.Property(e => e.MiddleName)
                .HasColumnType("VARCHAR (2, 50)")
                .HasColumnName("Middle_name");
            entity.Property(e => e.NeedHostel)
                .HasColumnType("BOOLEAN")
                .HasColumnName("Need_hostel");
            entity.Property(e => e.PassportDate)
                .HasColumnType("DATETIME")
                .HasColumnName("Passport_date");
            entity.Property(e => e.PassportIssued)
                .HasColumnType("VARCHAR (10, 70)")
                .HasColumnName("Passport_issued");
            entity.Property(e => e.PassportNumber).HasColumnName("Passport_number");
            entity.Property(e => e.PassportScan).HasColumnName("Passport_scan");
            entity.Property(e => e.PassportSeries).HasColumnName("Passport_series");
            entity.Property(e => e.Password).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("VARCHAR (11, 15)")
                .HasColumnName("Phone_number");
            entity.Property(e => e.Street).HasColumnType("VARCHAR (3, 30)");

            entity.HasOne(d => d.CerificateOriginality).WithMany(p => p.Users).HasForeignKey(d => d.CerificateOriginalityId);

            entity.HasOne(d => d.City).WithMany(p => p.Users).HasForeignKey(d => d.CityId);

            entity.HasOne(d => d.Direction).WithMany(p => p.Users).HasForeignKey(d => d.DirectionId);

            entity.HasOne(d => d.FormOfStudy).WithMany(p => p.Users).HasForeignKey(d => d.FormOfStudyId);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
