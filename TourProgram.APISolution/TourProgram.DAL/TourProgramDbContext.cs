using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.DAL.Models;

namespace TourProgram.DAL
{
    public class TourProgramDbContext : IdentityDbContext<ApplicationUser, UserRole, string>
    {
        public TourProgramDbContext(DbContextOptions<TourProgramDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmpProfile> EmpProfiles { get; set; }
        public DbSet<OrgClaimLimit> OrgClaimLimits { get; set; }
        public DbSet<EmpTourPlan> EmpTourPlans { get; set; }
        public DbSet<TentativeTravelPlan> TentativeTravelPlans { get; set; }
        public DbSet<ActualTravelPlan> ActualTravelPlans { get; set; }
        public DbSet<GradeDetail> GradeDetails { get; set; }
        public DbSet<UploadDocument> UploadDocuments { get; set; }
        public DbSet<UploadTypeDetail> UploadTypeDetails { get; set; }
        public DbSet<UploadDocType> UploadDocTypes { get; set; }
        public DbSet<ClaimStatusCategory> ClaimStatusCategorys { get; set; }
        public DbSet<ClaimType> ClaimTypes { get; set; }
        public DbSet<EMPClaimProcessDetail> EMPClaimProcessDetails { get; set; }
        public DbSet<FinanceDetail> FinanceDetails { get; set; }
        public DbSet<TransportationDetail> TransportationDetails { get; set; }
        public DbSet<TransportationUpload> TransportationUploads { get; set; }
        public DbSet<ClaimClarification> ClaimClarifications { get; set; }
        public DbSet<AccomodationDetail> AccomodationDetails { get; set; }
        public DbSet<AccomodationUpload> AccomodationUploads { get; set; }
        public DbSet<DADetail> DADetails { get; set; }
        public DbSet<LeaveDetail> LeaveDetails { get; set; }
        public DbSet<OtpCodeDetails> OtpCodeDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<EmpProfile>().HasOne(e => e.Employee).WithMany()
                .HasForeignKey(e => e.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            modelBuilder.Entity<EMPClaimProcessDetail>().HasOne(e => e.ClaimStatusCategory).WithMany()
                .HasForeignKey(e => e.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            
            SeedData_UploadDocTypeType(modelBuilder);
            SeedData_ClaimType(modelBuilder);
            SeedData_ClaimStatusCategory(modelBuilder);
            SeedData_GradeDetails(modelBuilder);

        }

        public void SeedData_UploadDocTypeType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UploadDocType>().HasData(
                 new UploadDocType { Id = 1, IsBillable = true, Name = "Travel", IsActive = true, CreatedDate = DateTime.Now },
                 new UploadDocType { Id = 2, IsBillable = true, Name = "Accommodation", IsActive = true, CreatedDate = DateTime.Now }
            );
        }

        public void SeedData_ClaimType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimType>().HasData(
                 new ClaimType { Id = 1, Name = "Advance",  IsActive = true, CreatedDate = DateTime.Now },
                 new ClaimType { Id = 2, Name = "Advance Claim",  IsActive = true, CreatedDate = DateTime.Now },
                 new ClaimType { Id = 3, Name = "Claim", IsActive = true, CreatedDate = DateTime.Now }
            );
        }

        public void SeedData_ClaimStatusCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClaimStatusCategory>().HasData(
         new ClaimStatusCategory { Id = 1, Name = "Pending Approval", Description = "Pending Approval",  IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 2, Name = "Approved", Description = "Approved",  IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 3, Name = "Finance Processing", Description = "Finance Processing",  IsActive = true, CreatedDate = DateTime.Now },
         new ClaimStatusCategory { Id = 5, Name = "Rejected", Description = "Rejected",  IsActive = true, CreatedDate = DateTime.Now }
         );
        }

        public void SeedData_GradeDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeDetail>().HasData(
                 new GradeDetail { Id = 1, Lavel = "MD", X = "Ashoka Hotel Suite", Y = "90% of the rate of Ashoka Hotel Suite", Z = "80% of the rate of Ashoka Hotel Suite" },
                 new GradeDetail { Id = 2, Lavel = "Director", X = "Ashoka Hotel Suite", Y = "90% of the rate of Ashoka Hotel Suite", Z = "80% of the rate of Ashoka Hotel Suite" },
                 new GradeDetail { Id = 3, Lavel = "ED", X = "10000", Y = "9000", Z = "7500" },
                 new GradeDetail { Id = 4, Lavel = "GGM", X = "10000", Y = "9000", Z = "7500" },
                 new GradeDetail { Id = 5, Lavel = "GM", X = "10000", Y = "9000", Z = "7500" },
                 new GradeDetail { Id = 6, Lavel = "AGM", X = "75000", Y = "6000", Z = "5000" },
                 new GradeDetail { Id = 7, Lavel = "JGM", X = "75000", Y = "6000", Z = "5000" },
                 new GradeDetail { Id = 8, Lavel = "DGM", X = "6000", Y = "5000", Z = "4000" },
                 new GradeDetail { Id = 9, Lavel = "Jr.Mgr", X = "3000", Y = "2500", Z = "2000" },
                 new GradeDetail { Id = 10, Lavel = "Mgr", X = "3000", Y = "2500", Z = "2000" },
                 new GradeDetail { Id = 11, Lavel = "Sr.Exe", X = "2200", Y = "2000", Z = "1000" },
                 new GradeDetail { Id = 12, Lavel = "Exe", X = "2200", Y = "2000", Z = "1000" },
                 new GradeDetail { Id = 13, Lavel = "N5", X = "1500", Y = " 1300", Z = "800" },
                 new GradeDetail { Id = 14, Lavel = "N6", X = "1500", Y = "1300", Z = "800" },
                 new GradeDetail { Id = 15, Lavel = "N7", X = "1500", Y = "1300", Z = "800" },
                 new GradeDetail { Id = 16, Lavel = "N1", X = "1000", Y = "800", Z = "500" },
                 new GradeDetail { Id = 17, Lavel = "N2", X = "1000", Y = "800", Z = "500" },
                 new GradeDetail { Id = 18, Lavel = "N3", X = "1000", Y = "800", Z = "500" },
                 new GradeDetail { Id = 19, Lavel = "N4", X = "1000", Y = "800", Z = "500" }
            );
        }
    }
}
