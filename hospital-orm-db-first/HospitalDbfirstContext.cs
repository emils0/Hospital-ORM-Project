using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Project_DB_First;

public partial class HospitalDbfirstContext : DbContext
{
    public HospitalDbfirstContext()
    {
    }

    public HospitalDbfirstContext(DbContextOptions<HospitalDbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<MedicalStaff> MedicalStaffs { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=HospitalDBFirst;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.0.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.DoctorId, "DoctorId");

            entity.HasIndex(e => e.PatientId, "PatientId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnType("int(11)");
            entity.Property(e => e.PatientId).HasColumnType("int(11)");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("appointments_ibfk_1");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("appointments_ibfk_2");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Specialty).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctors_ibfk_1");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.PatientId, "PatientId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Details).HasColumnType("text");
            entity.Property(e => e.PatientId).HasColumnType("int(11)");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("medicalrecords_ibfk_1");
        });

        modelBuilder.Entity<MedicalStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("MedicalStaff");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Discriminator).HasMaxLength(50);
            entity.Property(e => e.Experience).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Qualification).HasMaxLength(255);
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Department).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Nurse)
                .HasForeignKey<Nurse>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("nurses_ibfk_1");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
