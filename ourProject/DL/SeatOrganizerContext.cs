using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ourProject.Models
{
    public partial class SeatOrganizerContext : DbContext
    {
        public SeatOrganizerContext()
        {
        }

        public SeatOrganizerContext(DbContextOptions<SeatOrganizerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryPerEvent> CategoryPerEvents { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventPerUser> EventPerUsers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Placement> Placements { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TypeEvent> TypeEvents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7SLGQOB;Database=SeatOrganizer;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Category_Event");
            });

            modelBuilder.Entity<CategoryPerEvent>(entity =>
            {
                entity.ToTable("categoryPerEvent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryPerEvents)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_categoryPerEvent_Category");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CategoryPerEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_categoryPerEvent_Event");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateToSendEmail)
                    .HasColumnType("date")
                    .HasColumnName("date_to_send_email");

                entity.Property(e => e.InvitationImage)
                    .HasColumnType("image")
                    .HasColumnName("invitation_image");

                entity.Property(e => e.NumChairsFemale).HasColumnName("num_chairs_female");

                entity.Property(e => e.NumChairsMale).HasColumnName("num_chairs_male");

                entity.Property(e => e.NumSpecialTableChairsFemale).HasColumnName("num_special_table_chairs_female");

                entity.Property(e => e.NumSpecialTableChairsMale).HasColumnName("num_special_table_chairs_male");

                entity.Property(e => e.NumTabelsMale).HasColumnName("num_tabels_male");

                entity.Property(e => e.NumTablesFemale).HasColumnName("num_tables_female");

                entity.Property(e => e.SeperatedSeats).HasColumnName("seperated_seats");
            });

            modelBuilder.Entity<EventPerUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EventPerUser");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Event)
                    .WithMany()
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPerUser_Event");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventPerUser_User");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Female).HasColumnName("female");

                entity.Property(e => e.Male).HasColumnName("male");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.ToTable("Guest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdentifyImage)
                    .HasColumnType("image")
                    .HasColumnName("identify_image");

                entity.Property(e => e.IdentifyName)
                    .HasMaxLength(50)
                    .HasColumnName("identify_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.NumFamilyMembersFemale).HasColumnName("num_family_members_female");

                entity.Property(e => e.NumFamilyMembersMale).HasColumnName("num_family_members_male");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .HasColumnName("phone")
                    .IsFixedLength(true);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_Category");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_Event");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_User");
            });

            modelBuilder.Entity<Placement>(entity =>
            {
                entity.ToTable("Placement");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GuestId).HasColumnName("guest_id");

                entity.Property(e => e.TableId).HasColumnName("table_id");

                entity.HasOne(d => d.Guest)
                    .WithMany(p => p.Placements)
                    .HasForeignKey(d => d.GuestId)
                    .HasConstraintName("FK_Placement_Guest");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Placements)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Placement_Table");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("host");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("method")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("path");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("record_date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("referer");

                entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.IsSpecial).HasColumnName("is_special");

                entity.Property(e => e.NumChair).HasColumnName("num_chair");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_Event");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Table_Gender");
            });

            modelBuilder.Entity<TypeEvent>(entity =>
            {
                entity.ToTable("TypeEvent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("user_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
