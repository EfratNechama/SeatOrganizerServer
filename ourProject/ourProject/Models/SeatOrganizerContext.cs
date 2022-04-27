//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace ourProject.Models
//{
//    public partial class SeatOrganizerContext : DbContext
//    {
//        public SeatOrganizerContext()
//        {
//        }

//        public SeatOrganizerContext(DbContextOptions<SeatOrganizerContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<EventPerUser> EventPerUsers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=srv2\\PUPILS;Database=SeatOrganizer;Trusted_Connection=True;");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

//            modelBuilder.Entity<EventPerUser>(entity =>
//            {
//                entity.ToTable("EventPerUser");

//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.EventId).HasColumnName("event_id");

//                entity.Property(e => e.UserId).HasColumnName("user_id");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
