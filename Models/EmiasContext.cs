using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace A2test.Models;

public partial class EmiasContext : DbContext
{
    public EmiasContext()
    {
    }

    public EmiasContext(DbContextOptions<EmiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminTable> AdminTables { get; set; }

    public virtual DbSet<AnalysDocumentTable> AnalysDocumentTables { get; set; }

    public virtual DbSet<AppointmentDocumentTable> AppointmentDocumentTables { get; set; }

    public virtual DbSet<AppointmentsTable> AppointmentsTables { get; set; }

    public virtual DbSet<DirectionsTable> DirectionsTables { get; set; }

    public virtual DbSet<DoctorTable> DoctorTables { get; set; }

    public virtual DbSet<PatientTable> PatientTables { get; set; }

    public virtual DbSet<ResearchDocumentTable> ResearchDocumentTables { get; set; }

    public virtual DbSet<SpecialitiesTable> SpecialitiesTables { get; set; }

    public virtual DbSet<StatusTable> StatusTables { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MOZG\\SQLEXPRESS;Initial Catalog=EMIAS;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminTab__3214EC27C14D787C");

            entity.ToTable("AdminTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocumentTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnalysDo__3214EC277002FD25");

            entity.ToTable("AnalysDocumentTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

    //        entity.HasOne(d => d.Appointment).WithMany(p => p.AnalysDocumentTables)
    //            .HasForeignKey(d => d.AppointmentId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__AnalysDoc__Appoi__4D94879B");
        });

        modelBuilder.Entity<AppointmentDocumentTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC27CAE58AA6");

            entity.ToTable("AppointmentDocumentTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
    //
    //        entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDocumentTables)
    //            .HasForeignKey(d => d.AppointmentId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__Appointme__Appoi__4AB81AF0");
        });

        modelBuilder.Entity<AppointmentsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC270161B35D");

            entity.ToTable("AppointmentsTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.OmsId).HasColumnName("OMS_ID");
            entity.Property(e => e.StatusId).HasColumnName("Status_ID");

     //       entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentsTables)
     //           .HasForeignKey(d => d.DoctorId)
     //           .OnDelete(DeleteBehavior.ClientSetNull)
     //           .HasConstraintName("FK__Appointme__Docto__46E78A0C");
     //
     //       entity.HasOne(d => d.Oms).WithMany(p => p.AppointmentsTables)
     //           .HasForeignKey(d => d.OmsId)
     //           .OnDelete(DeleteBehavior.ClientSetNull)
     //           .HasConstraintName("FK__Appointme__OMS_I__45F365D3");
     //
     //       entity.HasOne(d => d.Status).WithMany(p => p.AppointmentsTables)
     //           .HasForeignKey(d => d.StatusId)
     //           .OnDelete(DeleteBehavior.ClientSetNull)
     //           .HasConstraintName("FK__Appointme__Statu__47DBAE45");
        });

        modelBuilder.Entity<DirectionsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Directio__3214EC27C353199F");

            entity.ToTable("DirectionsTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.OmsId).HasColumnName("OMS_ID");
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");

    //        entity.HasOne(d => d.Oms).WithMany(p => p.DirectionsTables)
    //            .HasForeignKey(d => d.OmsId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__Direction__OMS_I__403A8C7D");
    //
    //        entity.HasOne(d => d.Speciality).WithMany(p => p.DirectionsTables)
    //            .HasForeignKey(d => d.SpecialityId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__Direction__Speci__3F466844");
        });

        modelBuilder.Entity<DoctorTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DoctorTa__3214EC271C8ABA0C");

            entity.ToTable("DoctorTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnterPassword).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.WorkAddress).HasMaxLength(50);

    //        entity.HasOne(d => d.Speciality).WithMany(p => p.DoctorTables)
    //            .HasForeignKey(d => d.SpecialityId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("FK__DoctorTab__Speci__4316F928");
        });

        modelBuilder.Entity<PatientTable>(entity =>
        {
            entity.HasKey(e => e.Oms).HasName("PK__PatientT__CB396B8B839E9000");

            entity.ToTable("PatientTable");

            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LivingAddress).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Nickname).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(18);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocumentTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Research__3214EC277B1C928E");

            entity.ToTable("ResearchDocumentTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(1)
                .IsFixedLength();

     //       entity.HasOne(d => d.Appointment).WithMany(p => p.ResearchDocumentTables)
     //           .HasForeignKey(d => d.AppointmentId)
     //           .OnDelete(DeleteBehavior.ClientSetNull)
     //           .HasConstraintName("FK__ResearchD__Appoi__5070F446");
        });

        modelBuilder.Entity<SpecialitiesTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Speciali__3214EC2785E0C91E");

            entity.ToTable("SpecialitiesTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusTa__3214EC27ECBEB826");

            entity.ToTable("StatusTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
public class User
{
    public int Id { get; set; }
    public string Polis { get; set; }
}
