using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace fyp.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tblAccCategory> tblAccCategories { get; set; }
        public virtual DbSet<tblAccessory> tblAccessories { get; set; }
        public virtual DbSet<tblAccSubcategory> tblAccSubcategories { get; set; }
        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblFeedback> tblFeedbacks { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        public virtual DbSet<tblOrderDetail> tblOrderDetails { get; set; }
        public virtual DbSet<tblPetCategory> tblPetCategories { get; set; }
        public virtual DbSet<tblPet> tblPets { get; set; }
        public virtual DbSet<tblPetSubcategory> tblPetSubcategories { get; set; }
        public virtual DbSet<tblShelter> tblShelters { get; set; }
        public virtual DbSet<tblShop> tblShops { get; set; }
        public virtual DbSet<tblVet> tblVets { get; set; }
        public virtual DbSet<tblWishlist> tblWishlists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAccCategory>()
                .HasMany(e => e.tblAccSubcategories)
                .WithRequired(e => e.tblAccCategory)
                .HasForeignKey(e => e.A_CategoryFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblAccessory>()
                .HasMany(e => e.tblFeedbacks)
                .WithOptional(e => e.tblAccessory)
                .HasForeignKey(e => e.Accessories_FID);

            modelBuilder.Entity<tblAccessory>()
                .HasMany(e => e.tblOrderDetails)
                .WithOptional(e => e.tblAccessory)
                .HasForeignKey(e => e.Accessories_FID);

            modelBuilder.Entity<tblAccessory>()
                .HasMany(e => e.tblWishlists)
                .WithOptional(e => e.tblAccessory)
                .HasForeignKey(e => e.Accessories_FID);

            modelBuilder.Entity<tblAccSubcategory>()
                .HasMany(e => e.tblAccessories)
                .WithRequired(e => e.tblAccSubcategory)
                .HasForeignKey(e => e.A_SubcategoryFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblAdmin>()
                .HasMany(e => e.tblOrders)
                .WithOptional(e => e.tblAdmin)
                .HasForeignKey(e => e.Admin_FID);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblFeedbacks)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblOrders)
                .WithOptional(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID);

            modelBuilder.Entity<tblCustomer>()
                .HasMany(e => e.tblWishlists)
                .WithRequired(e => e.tblCustomer)
                .HasForeignKey(e => e.Customer_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblOrder>()
                .HasMany(e => e.tblOrderDetails)
                .WithRequired(e => e.tblOrder)
                .HasForeignKey(e => e.Order_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPetCategory>()
                .HasMany(e => e.tblPetSubcategories)
                .WithRequired(e => e.tblPetCategory)
                .HasForeignKey(e => e.P_CategoryFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblPet>()
                .HasMany(e => e.tblFeedbacks)
                .WithOptional(e => e.tblPet)
                .HasForeignKey(e => e.Pets_FID);

            modelBuilder.Entity<tblPet>()
                .HasMany(e => e.tblOrderDetails)
                .WithOptional(e => e.tblPet)
                .HasForeignKey(e => e.Pets_FID);

            modelBuilder.Entity<tblPet>()
                .HasMany(e => e.tblWishlists)
                .WithOptional(e => e.tblPet)
                .HasForeignKey(e => e.Pet_FID);

            modelBuilder.Entity<tblPetSubcategory>()
                .HasMany(e => e.tblPets)
                .WithRequired(e => e.tblPetSubcategory)
                .HasForeignKey(e => e.P_SubcategoryFID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblShop>()
                .HasMany(e => e.tblAccessories)
                .WithRequired(e => e.tblShop)
                .HasForeignKey(e => e.Shop_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblShop>()
                .HasMany(e => e.tblPets)
                .WithRequired(e => e.tblShop)
                .HasForeignKey(e => e.Shop_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
