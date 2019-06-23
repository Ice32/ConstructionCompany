using ConstructionCompanyDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConstructionCompanyDataLayer
{
    public class ConstructionCompanyContext: DbContext
    {
        public ConstructionCompanyContext(DbContextOptions<ConstructionCompanyContext> options) : base(options)
        {
        }
        public ConstructionCompanyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GradjevinskiDnevnik;Trusted_Connection=true;MultipleActiveResultSets=true;User ID=;Password=");
        }

        public DbSet<ConstructionSite> ConstructionSites { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Worksheet> Worksheets { get; set; }
        public DbSet<ConstructionSiteManager> ConstructionSiteManagers { get; set; }
        public DbSet<WorksheetMaterial> WorksheetMaterial { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<WorkerTask> WorkerTask { get; set; }
        public DbSet<WorksheetEquipment> WorksheetEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkerTask>()
                .HasKey(wt => new { wt.WorkerId, wt.TaskId });

            modelBuilder.Entity<WorkerTask>()
                .HasOne(wt => wt.Worker)
                .WithMany(w => w.WorkerTasks)
                .HasForeignKey(wt => wt.WorkerId);

            modelBuilder.Entity<WorkerTask>()
                .HasOne(wt => wt.Task)
                .WithMany(t => t.WorkerTasks)
                .HasForeignKey(wt => wt.TaskId);

            modelBuilder.Entity<WorksheetMaterial>()
                .HasKey(wm => new { wm.WorksheetId, wm.MaterialId });

            modelBuilder.Entity<WorksheetMaterial>()
                .HasOne(wm => wm.Worksheet)
                .WithMany(w => w.WorksheetMaterials)
                .HasForeignKey(wm => wm.WorksheetId);

            modelBuilder.Entity<WorksheetMaterial>()
                .HasOne(wm => wm.Material)
                .WithMany(m => m.WorksheetMaterials)
                .HasForeignKey(wm => wm.MaterialId);


            modelBuilder.Entity<WorksheetEquipment>()
               .HasKey(wm => new { wm.WorksheetId, wm.EquipmentId });

            modelBuilder.Entity<WorksheetEquipment>()
                .HasOne(wm => wm.Worksheet)
                .WithMany(w => w.WorksheetEquipment)
                .HasForeignKey(wm => wm.WorksheetId);

            modelBuilder.Entity<WorksheetEquipment>()
                .HasOne(wm => wm.Equipment)
                .WithMany(m => m.WorksheetEquipment)
                .HasForeignKey(wm => wm.EquipmentId);

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasKey(cssm => new { cssm.ConstructionSiteId, cssm.ConstructionSiteManagerId });

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasOne(cssm => cssm.ConstructionSite)
                .WithMany(cs => cs.ConstructionSiteManagers)
                .HasForeignKey(cssm => cssm.ConstructionSiteId);

            modelBuilder.Entity<ConstructionSiteSiteManager>()
                .HasOne(cssm => cssm.ConstructionSiteManager)
                .WithMany(csm => csm.ConstructionSites)
                .HasForeignKey(cssm => cssm.ConstructionSiteManagerId);
            
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId});
            
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
        }
    }
}
