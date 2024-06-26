using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API_EMIAC.Models;

namespace API_EMIAC.Models;

public partial class EmiacContext : DbContext
{
    public EmiacContext(DbContextOptions<EmiacContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.IdAdministrator).HasName("PK__Administ__2160815C71ABFEF6");

            entity.ToTable("Administrator");

            entity.Property(e => e.IdAdministrator).HasColumnName("ID_Administrator");
            entity.Property(e => e.AdminEnterPassword).HasMaxLength(50);
            entity.Property(e => e.AdminMiddleName).HasMaxLength(50);
            entity.Property(e => e.AdminName).HasMaxLength(50);
            entity.Property(e => e.AdminSurname).HasMaxLength(50);
        });

        modelBuilder.Entity<AnalysDocument>(entity =>
        {
            entity.HasKey(e => e.IdAnalysDocument).HasName("PK__AnalysDo__11B9576427E848CB");

            entity.ToTable("AnalysDocument");

            entity.Property(e => e.IdAnalysDocument).HasColumnName("ID_AnalysDocument");
            entity.Property(e => e.ContentAnalysRtf).HasColumnName("ContentAnalysRTF");
            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__CE24CCCC11C44DFC");

            entity.ToTable("Appointment");

            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
            entity.Property(e => e.DoctorId).HasColumnName("Doctor_ID");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.StatusikId).HasColumnName("Statusik_ID");
        });

        modelBuilder.Entity<AppointmentDocument>(entity =>
        {
            entity.HasKey(e => e.IdAppointmentDocument).HasName("PK__Appointm__077DCD836B2086D0");

            entity.ToTable("AppointmentDocument");

            entity.Property(e => e.IdAppointmentDocument).HasColumnName("ID_AppointmentDocument");
            entity.Property(e => e.ContentAppointmentRtf).HasColumnName("ContentAppointmentRTF");
            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
        });

        modelBuilder.Entity<Direction>(entity =>
        {
            entity.HasKey(e => e.IdDirections).HasName("PK__Directio__D19536716F99E3C7");

            entity.ToTable("Direction");

            entity.Property(e => e.IdDirections).HasColumnName("ID_Directions");
            entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.IdDoctor).HasName("PK__Doctor__3246951C8E7185A1");

            entity.ToTable("Doctor");

            entity.Property(e => e.IdDoctor).HasColumnName("ID_Doctor");
            entity.Property(e => e.DoctorEnterPassword).HasMaxLength(50);
            entity.Property(e => e.DoctorMiddleName).HasMaxLength(50);
            entity.Property(e => e.DoctorName).HasMaxLength(50);
            entity.Property(e => e.DoctorSurname).HasMaxLength(50);
            entity.Property(e => e.SpecialityId).HasColumnName("Speciality_ID");
            entity.Property(e => e.WorkAddress).HasMaxLength(50);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.IdPatient).HasName("PK__Patient__EE3EFF681B0DE0BD");

            entity.ToTable("Patient");

            entity.Property(e => e.IdPatient).HasColumnName("ID_Patient");
            entity.Property(e => e.Oms).HasColumnName("OMS");
            entity.Property(e => e.PatientAddress).HasMaxLength(255);
            entity.Property(e => e.PatientEmail).HasMaxLength(50);
            entity.Property(e => e.PatientLivingAddress).HasMaxLength(255);
            entity.Property(e => e.PatientMiddleName).HasMaxLength(50);
            entity.Property(e => e.PatientName).HasMaxLength(50);
            entity.Property(e => e.PatientNickName).HasMaxLength(50);
            entity.Property(e => e.PatientPhoneNumber).HasMaxLength(11);
            entity.Property(e => e.PatientSurname).HasMaxLength(50);
        });

        modelBuilder.Entity<ResearchDocument>(entity =>
        {
            entity.HasKey(e => e.IdResearchDocument).HasName("PK__Research__117811C6D550A653");

            entity.ToTable("ResearchDocument");

            entity.Property(e => e.IdResearchDocument).HasColumnName("ID_ResearchDocument");
            entity.Property(e => e.Attachment)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.ContentResearchRtf).HasColumnName("ContentResearchRTF");
            entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality).HasName("PK__Speciali__8D22304DDE7BA8A1");

            entity.ToTable("Speciality");

            entity.Property(e => e.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(e => e.NameOfSpeciality).HasMaxLength(50);
        });

        modelBuilder.Entity<Statusik>(entity =>
        {
            entity.HasKey(e => e.IdStatusik).HasName("PK__Statusik__DA8FE3213FF73BB8");

            entity.ToTable("Statusik");

            entity.Property(e => e.IdStatusik).HasColumnName("ID_Statusik");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<API_EMIAC.Models.Administrator> Administrator { get; set; } = default!;

public DbSet<API_EMIAC.Models.AnalysDocument> AnalysDocument { get; set; } = default!;

public DbSet<API_EMIAC.Models.Appointment> Appointment { get; set; } = default!;

public DbSet<API_EMIAC.Models.AppointmentDocument> AppointmentDocument { get; set; } = default!;

public DbSet<API_EMIAC.Models.Direction> Direction { get; set; } = default!;

public DbSet<API_EMIAC.Models.Doctor> Doctor { get; set; } = default!;

public DbSet<API_EMIAC.Models.Patient> Patient { get; set; } = default!;

public DbSet<API_EMIAC.Models.ResearchDocument> ResearchDocument { get; set; } = default!;

public DbSet<API_EMIAC.Models.Speciality> Speciality { get; set; } = default!;

public DbSet<API_EMIAC.Models.Statusik> Statusik { get; set; } = default!;
}
