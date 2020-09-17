using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorHybridApp.DataAccess.Models
{
    public partial class cugemderdatabaseupdateContext : DbContext
    {
        public cugemderdatabaseupdateContext()
        {
        }

        public cugemderdatabaseupdateContext(DbContextOptions<cugemderdatabaseupdateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<JobTitles> JobTitles { get; set; }
        public virtual DbSet<MeetingPoints> MeetingPoints { get; set; }
        public virtual DbSet<Meetings> Meetings { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Uploads> Uploads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\cugemder; database=cugemderdatabaseupdate; Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.Gender);

                entity.HasIndex(e => e.Group);

                entity.HasIndex(e => e.JobTitle);

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.HasIndex(e => e.Notifications);

                entity.HasIndex(e => e.Points);

                entity.HasIndex(e => e.Position);

                entity.Property(e => e.Company).HasColumnName("company");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Group).HasColumnName("group");

                entity.Property(e => e.JobTitle).HasColumnName("jobTitle");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Notifications).HasColumnName("notifications");

                entity.Property(e => e.OrderInGroup).HasColumnName("orderInGroup");

                entity.Property(e => e.PhoneNo).HasColumnName("phoneNo");

                entity.Property(e => e.PhotoUrl).HasColumnName("photoUrl");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.ReferencedBy).HasColumnName("referencedBy");

                entity.Property(e => e.Speciality)
                    .HasColumnName("speciality")
                    .HasMaxLength(300);

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasColumnType("text");

                entity.Property(e => e.SurName).HasColumnName("surName");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(200);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Gender)
                    .HasConstraintName("FK_AspNetUsers_Genders");

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Group)
                    .HasConstraintName("FK_AspNetUsers_Groups");

                entity.HasOne(d => d.JobTitleNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.JobTitle)
                    .HasConstraintName("FK_AspNetUsers_JobTitles");

                entity.HasOne(d => d.NotificationsNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Notifications)
                    .HasConstraintName("FK_AspNetUsers_Notifications");

                entity.HasOne(d => d.PointsNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Points)
                    .HasConstraintName("FK_AspNetUsers_Points");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_AspNetUsers_Positions");
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AllowedRoles).HasMaxLength(100);

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobTitles>(entity =>
            {
                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<MeetingPoints>(entity =>
            {
                entity.HasIndex(e => e.MeetingId);

                entity.Property(e => e.ReceiverUserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.MeetingPoints)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeetingPoints_Meetings");
            });

            modelBuilder.Entity<Meetings>(entity =>
            {
                entity.HasIndex(e => e.SenderId);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IsApproved).HasColumnName("isApproved");

                entity.Property(e => e.IsResulted).HasColumnName("isResulted");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.ReceiverId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.SenderId).IsRequired();

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Meetings)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meetings_AspNetUsers");
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Points>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.AddedBy).IsRequired();

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Points1)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Points_AspNetUsers");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Uploads>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Uploads)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Uploads_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
