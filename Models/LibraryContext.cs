using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace NTR20Z.Models
{
  public class LibraryContext : DbContext
  {
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Subject> Subject {get;set;}
    public DbSet<Classgroup> Classgroup {get;set;}
    public DbSet<Room> Room {get;set;}
    public DbSet<Slot> Slot {get;set;}
    public DbSet<ActivityBis> ActivityBis {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySQL("server=localhost;database=NTR2020Z;user=root;password=Kaloryfer1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Teacher>(entity =>
      {
        entity.HasKey(e => e.teacherID);
        entity.Property(e => e.name).IsRequired();
        entity.Property(e => e.comment).IsRequired();
        entity.Property(e => e.TimeStamp);
      });

      modelBuilder.Entity<Subject>(entity =>
      {
        entity.HasKey(e => e.subjectID);
        entity.Property(e => e.name).IsRequired();
        entity.Property(e => e.comment).IsRequired();
        entity.Property(e => e.TimeStamp);
      });

      modelBuilder.Entity<Classgroup>(entity =>
      {
        entity.HasKey(e => e.classgroupID);
        entity.Property(e => e.name).IsRequired();
        entity.Property(e => e.comment).IsRequired();
        entity.Property(e => e.TimeStamp);
      });

      modelBuilder.Entity<Room>(entity =>
      {
        entity.HasKey(e => e.roomID);
        entity.Property(e => e.name).IsRequired();
        entity.Property(e => e.comment).IsRequired();
        entity.Property(e => e.TimeStamp);
      });

      modelBuilder.Entity<Slot>(entity =>
      {
        entity.HasKey(e => e.slotID);
        entity.Property(e => e.name).IsRequired();
        entity.Property(e => e.comment).IsRequired();
        entity.Property(e => e.TimeStamp);
      });

      modelBuilder.Entity<ActivityBis>(entity =>
      {
        entity.HasKey(e => e.activityID);
        entity.HasOne(d => d.Teacher)
          .WithMany(p => p.Activities);
        entity.HasOne(d => d.Subject)
          .WithMany(p => p.Activities);
        entity.HasOne(d => d.Classgroup)
          .WithMany(p => p.Activities);
        entity.HasOne(d => d.Room)
          .WithMany(p => p.Activities);
        entity.HasOne(d => d.Slot)
          .WithMany(p => p.Activities);
        entity.Property(e => e.TimeStamp);
      });
    }
  }
}