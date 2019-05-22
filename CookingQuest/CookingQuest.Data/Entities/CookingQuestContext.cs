using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookingQuest.Data.Entities
{
    public partial class CookingQuestContext : DbContext
    {
        public CookingQuestContext()
        {
        }

        public CookingQuestContext(DbContextOptions<CookingQuestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Flavor> Flavor { get; set; }
        public virtual DbSet<FlavorLoot> FlavorLoot { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<LocationLoot> LocationLoot { get; set; }
        public virtual DbSet<Loot> Loot { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerEquipment> PlayerEquipment { get; set; }
        public virtual DbSet<PlayerLocation> PlayerLocation { get; set; }
        public virtual DbSet<PlayerLoot> PlayerLoot { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeLoot> RecipeLoot { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreEquipment> StoreEquipment { get; set; }
        public virtual DbSet<StoreFlavor> StoreFlavor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "cq");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Account__536C85E4E63EF7BA")
                    .IsUnique();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("Equipment", "cq");

                entity.Property(e => e.Modifier).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('Dungeon')");
            });

            modelBuilder.Entity<Flavor>(entity =>
            {
                entity.ToTable("Flavor", "cq");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<FlavorLoot>(entity =>
            {
                entity.ToTable("Flavor_Loot", "cq");

                entity.Property(e => e.FlavorLootId).HasColumnName("Flavor_LootId");

                entity.HasOne(d => d.Flavor)
                    .WithMany(p => p.FlavorLoot)
                    .HasForeignKey(d => d.FlavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flavor_Loot");

                entity.HasOne(d => d.Loot)
                    .WithMany(p => p.FlavorLoot)
                    .HasForeignKey(d => d.LootId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loot_Flavor");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "cq");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LocationLoot>(entity =>
            {
                entity.ToTable("Location_Loot", "cq");

                entity.Property(e => e.LocationLootId).HasColumnName("Location_LootId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationLoot)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Loot");

                entity.HasOne(d => d.Loot)
                    .WithMany(p => p.LocationLoot)
                    .HasForeignKey(d => d.LootId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loot_Location");
            });

            modelBuilder.Entity<Loot>(entity =>
            {
                entity.ToTable("Loot", "cq");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player", "cq");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PlayerEquipment>(entity =>
            {
                entity.ToTable("Player_Equipment", "cq");

                entity.Property(e => e.PlayerEquipmentId).HasColumnName("Player_EquipmentId");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.PlayerEquipment)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentId_PlayerId");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerEquipment)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlayerId_EquipmentId");
            });

            modelBuilder.Entity<PlayerLocation>(entity =>
            {
                entity.HasKey(e => e.PlayerLocation1);

                entity.ToTable("Player_Location", "cq");

                entity.Property(e => e.PlayerLocation1).HasColumnName("Player_Location");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.PlayerLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Player");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerLocation)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Location");
            });

            modelBuilder.Entity<PlayerLoot>(entity =>
            {
                entity.ToTable("Player_Loot", "cq");

                entity.Property(e => e.PlayerLootId).HasColumnName("Player_LootId");

                entity.HasOne(d => d.Loot)
                    .WithMany(p => p.PlayerLoot)
                    .HasForeignKey(d => d.LootId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loot_Player");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerLoot)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_Loot");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe", "cq");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RecipeLoot>(entity =>
            {
                entity.ToTable("Recipe_Loot", "cq");

                entity.Property(e => e.RecipeLootId).HasColumnName("Recipe_LootId");

                entity.HasOne(d => d.Loot)
                    .WithMany(p => p.RecipeLoot)
                    .HasForeignKey(d => d.LootId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loot_Recipe");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeLoot)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Loot");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "cq");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Difficulty).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<StoreEquipment>(entity =>
            {
                entity.ToTable("Store_Equipment", "cq");

                entity.Property(e => e.StoreEquipmentId).HasColumnName("Store_EquipmentId");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.StoreEquipment)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentId_Store");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreEquipment)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Equipment");
            });

            modelBuilder.Entity<StoreFlavor>(entity =>
            {
                entity.ToTable("Store_Flavor", "cq");

                entity.Property(e => e.StoreFlavorId).HasColumnName("Store_FlavorId");

                entity.HasOne(d => d.Flavor)
                    .WithMany(p => p.StoreFlavor)
                    .HasForeignKey(d => d.FlavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Flavor_Store");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreFlavor)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Flavor");
            });
        }
    }
}
