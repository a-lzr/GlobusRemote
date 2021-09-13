using System;
using GlobusRemote.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GlobusRemote.Data
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TrsaccTemplate> TrsaccTemplates { get; set; }
        public virtual DbSet<TrsaccTemplatesLinksAccess> TrsaccTemplatesLinksAccesses { get; set; }
        public virtual DbSet<TrsaccUser> TrsaccUsers { get; set; }
        public virtual DbSet<TrsaccUsersLinksTemplate> TrsaccUsersLinksTemplates { get; set; }
        public virtual DbSet<TrsappFile> TrsappFiles { get; set; }
        public virtual DbSet<TrsappScenario> TrsappScenarios { get; set; }
        public virtual DbSet<TrsappScenariosAction> TrsappScenariosActions { get; set; }
        public virtual DbSet<TrsappScenariosActionsValue> TrsappScenariosActionsValues { get; set; }
        public virtual DbSet<TrsappScenariosCustom> TrsappScenariosCustoms { get; set; }
        public virtual DbSet<TrsappScenariosGroup> TrsappScenariosGroups { get; set; }
        public virtual DbSet<TrsappScenariosGroupsItem> TrsappScenariosGroupsItems { get; set; }
        public virtual DbSet<TrsappScenariosInstruction> TrsappScenariosInstructions { get; set; }
        public virtual DbSet<TrsappScenariosItem> TrsappScenariosItems { get; set; }
        public virtual DbSet<TrsappScenariosItemsStep> TrsappScenariosItemsSteps { get; set; }
        public virtual DbSet<TrsappTemplate> TrsappTemplates { get; set; }
        public virtual DbSet<TrsappTemplatesLinksAccess> TrsappTemplatesLinksAccesses { get; set; }
        public virtual DbSet<TrsappTemplatesLinksScenariosGroup> TrsappTemplatesLinksScenariosGroups { get; set; }
        public virtual DbSet<TrsappUser> TrsappUsers { get; set; }
        public virtual DbSet<TrsappUsersContact> TrsappUsersContacts { get; set; }
        public virtual DbSet<TrsappUsersMission> TrsappUsersMissions { get; set; }
        public virtual DbSet<TrsappUsersMissionsFile> TrsappUsersMissionsFiles { get; set; }
        public virtual DbSet<TrsappUsersMissionsItem> TrsappUsersMissionsItems { get; set; }
        public virtual DbSet<TrsappUsersMissionsItemsSigned> TrsappUsersMissionsItemsSigneds { get; set; }
        public virtual DbSet<TrsappUsersMsg> TrsappUsersMsgs { get; set; }
        public virtual DbSet<TrsappUsersMsgsItem> TrsappUsersMsgsItems { get; set; }
        public virtual DbSet<TrsappUsersMsgsItemsDatum> TrsappUsersMsgsItemsData { get; set; }
        public virtual DbSet<TrsappUsersMsgsSigned> TrsappUsersMsgsSigneds { get; set; }
        public virtual DbSet<TrsappUsersTemplatesLink> TrsappUsersTemplatesLinks { get; set; }
        public virtual DbSet<TrsdirAccTemplatesAccessGroup> TrsdirAccTemplatesAccessGroups { get; set; }
        public virtual DbSet<TrsdirAccTemplatesAccessType> TrsdirAccTemplatesAccessTypes { get; set; }
        public virtual DbSet<TrsdirAppContact> TrsdirAppContacts { get; set; }
        public virtual DbSet<TrsdirAppContactsLink> TrsdirAppContactsLinks { get; set; }
        public virtual DbSet<TrsdirAppFilesType> TrsdirAppFilesTypes { get; set; }
        public virtual DbSet<TrsdirAppScenariosActionsGroup> TrsdirAppScenariosActionsGroups { get; set; }
        public virtual DbSet<TrsdirAppScenariosActionsType> TrsdirAppScenariosActionsTypes { get; set; }
        public virtual DbSet<TrsdirAppScenariosGroupsType> TrsdirAppScenariosGroupsTypes { get; set; }
        public virtual DbSet<TrsdirAppScenariosItemsType> TrsdirAppScenariosItemsTypes { get; set; }
        public virtual DbSet<TrsdirAppScenariosType> TrsdirAppScenariosTypes { get; set; }
        public virtual DbSet<TrsdirAppTemplatesAccessType> TrsdirAppTemplatesAccessTypes { get; set; }
        public virtual DbSet<TrsdirAppUsersMsgsItemsType> TrsdirAppUsersMsgsItemsTypes { get; set; }
        public virtual DbSet<TrsdirAppUsersMsgsSignedType> TrsdirAppUsersMsgsSignedTypes { get; set; }
        public virtual DbSet<TrsdirAppUsersMsgsSignedTypesLink> TrsdirAppUsersMsgsSignedTypesLinks { get; set; }
        public virtual DbSet<TrsdirAppUsersMsgsType> TrsdirAppUsersMsgsTypes { get; set; }
        public virtual DbSet<TrsdirLanguage> TrsdirLanguages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

//                var connectString = Configuration.GetValue<string>("ConnectString");
//                services.AddDbContext<MainDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(connectString));

//                optionsBuilder.UseSqlServer("Data Source=192.168.12.1;Initial Catalog=SrvService;Integrated Security=True;");
//            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<TrsaccTemplate>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAccTemplates");

                entity.ToTable("TRSAccTemplates", "acs");

                entity.HasIndex(e => e.Fname, "UK_RSAccTemplates_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsaccTemplatesLinksAccess>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkLink })
                    .HasName("PK_RSAccTemplatesLinksAccess");

                entity.ToTable("TRSAccTemplatesLinksAccess", "acs");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsaccTemplatesLinksAccesses)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAccTemplatesLinksAccess_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsaccTemplatesLinksAccesses)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAccTemplatesLinksAccess_Parent");
            });

            modelBuilder.Entity<TrsaccUser>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAccUsers");

                entity.ToTable("TRSAccUsers", "acs");

                entity.HasIndex(e => e.Fname, "UK_RSAccUsers_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateFinish)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateFinish");

                entity.Property(e => e.FdateStart)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateStart")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagAdmin).HasColumnName("FFlagAdmin");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLanguage)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FK_Language")
                    .HasDefaultValueSql("('RU')")
                    .IsFixedLength(true);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("FName");

                entity.Property(e => e.Fpassword)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("FPassword");

                entity.HasOne(d => d.FkLanguageNavigation)
                    .WithMany(p => p.TrsaccUsers)
                    .HasForeignKey(d => d.FkLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAccUsers_Language");
            });

            modelBuilder.Entity<TrsaccUsersLinksTemplate>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkLink })
                    .HasName("PK_RSAccUsersLinksTemplates");

                entity.ToTable("TRSAccUsersLinksTemplates", "acs");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsaccUsersLinksTemplates)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAccUsersLinksTemplates_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsaccUsersLinksTemplates)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAccUsersLinksTemplates_Parent");
            });

            modelBuilder.Entity<TrsappFile>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppFiles");

                entity.ToTable("TRSAppFiles");

                entity.HasIndex(e => new { e.FkType, e.Fname }, "UK_RSAppFiles_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fbody)
                    .IsRequired()
                    .HasColumnName("FBody");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fextention)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("FExtention");

                entity.Property(e => e.Fhash)
                    .HasMaxLength(16)
                    .HasColumnName("FHash");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");

                entity.Property(e => e.Fsize).HasColumnName("FSize");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappFiles)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppFiles_Type");
            });

            modelBuilder.Entity<TrsappScenario>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppTemplatesScenarios");

                entity.ToTable("TRSAppScenarios");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FflagInputDateManual).HasColumnName("FFlagInputDateManual");

                entity.Property(e => e.FflagSendConfirm).HasColumnName("FFlagSendConfirm");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappScenarios)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSDirAppTemplatesScenarios_Type");
            });

            modelBuilder.Entity<TrsappScenariosAction>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppTemplatesScenariosActions");

                entity.ToTable("TRSAppScenariosActions");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkGroup).HasColumnName("FK_Group");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.HasOne(d => d.FkGroupNavigation)
                    .WithMany(p => p.TrsappScenariosActions)
                    .HasForeignKey(d => d.FkGroup)
                    .HasConstraintName("FK_RSDirAppTemplatesScenariosActions_Group");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappScenariosActions)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSDirAppTemplatesScenariosActions_Type");
            });

            modelBuilder.Entity<TrsappScenariosActionsValue>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosActionsValues");

                entity.ToTable("TRSAppScenariosActionsValues");

                entity.HasIndex(e => new { e.FkParent, e.Fname }, "UK_RSAppScenariosActionsValues_Name")
                    .IsUnique();

                entity.HasIndex(e => new { e.FkParent, e.Fvalue }, "UK_RSAppScenariosActionsValues_Value")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.Property(e => e.Fvalue).HasColumnName("FValue");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosActionsValues)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosActionsValues_Parent");
            });

            modelBuilder.Entity<TrsappScenariosCustom>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkLink })
                    .HasName("PK_RSAppScenariosCustom");

                entity.ToTable("TRSAppScenariosCustom");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappScenariosCustoms)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosCustom_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosCustoms)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosCustom_Parent");
            });

            modelBuilder.Entity<TrsappScenariosGroup>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosGroups");

                entity.ToTable("TRSAppScenariosGroups");

                entity.HasIndex(e => e.FkType, "UI_RSAppScenariosGroups_FlagDefault")
                    .HasFilter("([FFlagDefault]=(1))");

                entity.HasIndex(e => e.Fname, "UK_RSAppScenariosGroups_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcomment)
                    .HasMaxLength(255)
                    .HasColumnName("FComment");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagDefault).HasColumnName("FFlagDefault");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappScenariosGroups)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosGroups_Type");
            });

            modelBuilder.Entity<TrsappScenariosGroupsItem>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosGroupsItems");

                entity.ToTable("TRSAppScenariosGroupsItems");

                entity.HasIndex(e => new { e.FkParent, e.Fname }, "UK_RSAppScenariosGroupsItems_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkImage).HasColumnName("FK_Image");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkParentItem).HasColumnName("FK_ParentItem");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FName");

                entity.Property(e => e.Fposition).HasColumnName("FPosition");

                //entity.HasOne(d => d.FkImageNavigation)
                //    .WithMany(p => p.TrsappScenariosGroupsItems)
                //    .HasForeignKey(d => d.FkImage)
                //    .HasConstraintName("FK_RSAppScenariosGroupsItems_Image");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappScenariosGroupsItems)
                    .HasForeignKey(d => d.FkLink)
                    .HasConstraintName("FK_RSAppScenariosGroupsItems_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosGroupsItems)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosGroupsItems_Parent");

                entity.HasOne(d => d.FkParentItemNavigation)
                    .WithMany(p => p.InverseFkParentItemNavigation)
                    .HasForeignKey(d => d.FkParentItem)
                    .HasConstraintName("FK_RSAppScenariosGroupsItems_ParentItem");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappScenariosGroupsItems)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosGroupsItems_Type");
            });

            modelBuilder.Entity<TrsappScenariosInstruction>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosInstructions");

                entity.ToTable("TRSAppScenariosInstructions");

                entity.HasIndex(e => new { e.FkParent, e.FkLink }, "UK_RSAppScenariosInstructions_Link")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                //entity.HasOne(d => d.FkLinkNavigation)
                //    .WithMany(p => p.TrsappScenariosInstructions)
                //    .HasForeignKey(d => d.FkLink)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RSAppScenariosInstructions_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosInstructions)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosInstructions_Parent");
            });

            modelBuilder.Entity<TrsappScenariosItem>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosItems");

                entity.ToTable("TRSAppScenariosItems");

                entity.HasIndex(e => new { e.FkParent, e.Fcode }, "UK_RSAppScenariosItems_Code")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FCode");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FflagRequired).HasColumnName("FFlagRequired");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkStep).HasColumnName("FK_Step");

                entity.Property(e => e.Fposition).HasColumnName("FPosition");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappScenariosItems)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosItems_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosItems)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosItems_Parent");

                entity.HasOne(d => d.FkStepNavigation)
                    .WithMany(p => p.TrsappScenariosItems)
                    .HasForeignKey(d => d.FkStep)
                    .HasConstraintName("FK_RSAppScenariosItems_Step");
            });

            modelBuilder.Entity<TrsappScenariosItemsStep>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppScenariosItemsSteps");

                entity.ToTable("TRSAppScenariosItemsSteps");

                entity.HasIndex(e => new { e.FkParent, e.Fposition }, "UK_RSAppScenariosItemsSteps_Position")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.Fname)
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.Property(e => e.Fposition).HasColumnName("FPosition");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappScenariosItemsSteps)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppScenariosItemsSteps_Parent");
            });

            modelBuilder.Entity<TrsappTemplate>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppTemplates");

                entity.ToTable("TRSAppTemplates");

                entity.HasIndex(e => e.Fname, "UK_RSAppTemplates_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcomment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FComment");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");

                entity.Property(e => e.FperiodDataExchanges)
                    .HasColumnName("FPeriodDataExchanges")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.FperiodLockWithoutDataExchange)
                    .HasColumnName("FPeriodLockWithoutDataExchange")
                    .HasDefaultValueSql("((72))");

                entity.Property(e => e.FphoneBase)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FPhoneBase");
            });

            modelBuilder.Entity<TrsappTemplatesLinksAccess>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkLink })
                    .HasName("PK_RSAppTemplatesLinksAccess");

                entity.ToTable("TRSAppTemplatesLinksAccess");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappTemplatesLinksAccesses)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppTemplatesLinksAccess_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappTemplatesLinksAccesses)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppTemplatesLinksAccess_Parent");
            });

            modelBuilder.Entity<TrsappTemplatesLinksScenariosGroup>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkLink })
                    .HasName("PK_RSAppTemplatesLinksScenariosGroups");

                entity.ToTable("TRSAppTemplatesLinksScenariosGroups");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappTemplatesLinksScenariosGroups)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppTemplatesLinksScenariosGroups_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappTemplatesLinksScenariosGroups)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppTemplatesLinksScenariosGroups_Parent");
            });

            modelBuilder.Entity<TrsappUser>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsers");

                entity.ToTable("TRSAppUsers");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCode");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fphone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FPhone");
            });

            modelBuilder.Entity<TrsappUsersContact>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersContacts");

                entity.ToTable("TRSAppUsersContacts");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappUsersContacts)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersContacts_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersContacts)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersContacts_Parent");
            });

            modelBuilder.Entity<TrsappUsersMission>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMissions");

                entity.ToTable("TRSAppUsersMissions");

                entity.HasIndex(e => e.FkParent, "UI_RSAppUsersMissions_FlagCurrent")
                    .IsUnique()
                    .HasFilter("([FFlagCurrent]=(1))");

                entity.HasIndex(e => e.FkParent, "UI_RSAppUsersMissions_FlagNext")
                    .IsUnique()
                    .HasFilter("([FFlagNext]=(1))");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagCurrent).HasColumnName("FFlagCurrent");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FflagNext).HasColumnName("FFlagNext");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithOne(p => p.TrsappUsersMission)
                    .HasForeignKey<TrsappUsersMission>(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissions_Parent");
            });

            modelBuilder.Entity<TrsappUsersMissionsFile>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMissionsFiles");

                entity.ToTable("TRSAppUsersMissionsFiles");

                entity.HasIndex(e => new { e.FkParent, e.FkLink }, "UK_RSAppUsersMissionsFiles_Link")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                //entity.HasOne(d => d.FkLinkNavigation)
                //    .WithMany(p => p.TrsappUsersMissionsFiles)
                //    .HasForeignKey(d => d.FkLink)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RSAppUsersMissionsFiles_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMissionsFiles)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsFiles_Parent");
            });

            modelBuilder.Entity<TrsappUsersMissionsItem>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMissionsItems");

                entity.ToTable("TRSAppUsersMissionsItems");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Fdescription).HasColumnName("FDescription");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FName");

                entity.Property(e => e.Fposition).HasColumnName("FPosition");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappUsersMissionsItems)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsItems_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMissionsItems)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsItems_Parent");
            });

            modelBuilder.Entity<TrsappUsersMissionsItemsSigned>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMissionsItemsSigned");

                entity.ToTable("TRSAppUsersMissionsItemsSigned");

                entity.HasIndex(e => new { e.FkParent, e.FkLink }, "UK_RSAppUsersMissionsItemsSigned_Link")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkScenarioGroup).HasColumnName("FK_ScenarioGroup");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappUsersMissionsItemsSigneds)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsItemsSigned_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMissionsItemsSigneds)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsItemsSigned_Parent");

                entity.HasOne(d => d.FkScenarioGroupNavigation)
                    .WithMany(p => p.TrsappUsersMissionsItemsSigneds)
                    .HasForeignKey(d => d.FkScenarioGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMissionsItemsSigned_ScenarioGroup");
            });

            modelBuilder.Entity<TrsappUsersMsg>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMsgs");

                entity.ToTable("TRSAppUsersMsgs");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FcodeResponse)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FCodeResponse");

                entity.Property(e => e.Fdate)
                    .HasColumnType("datetime")
                    .HasColumnName("FDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkScenario).HasColumnName("FK_Scenario");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Ftext)
                    .HasMaxLength(500)
                    .HasColumnName("FText");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMsgs)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgs_Parent");

                entity.HasOne(d => d.FkScenarioNavigation)
                    .WithMany(p => p.TrsappUsersMsgs)
                    .HasForeignKey(d => d.FkScenario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgs_Scenario");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappUsersMsgs)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgs_Type");
            });

            modelBuilder.Entity<TrsappUsersMsgsItem>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSAppUsersMsgsItems");

                entity.ToTable("TRSAppUsersMsgsItems");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcomment)
                    .HasMaxLength(255)
                    .HasColumnName("FComment");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Fsize).HasColumnName("FSize");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMsgsItems)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgsItems_Parent");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappUsersMsgsItems)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgsItems_Type");
            });

            modelBuilder.Entity<TrsappUsersMsgsItemsDatum>(entity =>
            {
                entity.HasKey(e => e.FkParent)
                    .HasName("PK_RSAppUsersMsgsItemsData");

                entity.ToTable("TRSAppUsersMsgsItemsData", "fls");

                entity.Property(e => e.FkParent)
                    .ValueGeneratedNever()
                    .HasColumnName("FK_Parent");

                entity.Property(e => e.Fbody)
                    .IsRequired()
                    .HasColumnName("FBody");

                entity.Property(e => e.Fhash)
                    .HasMaxLength(16)
                    .HasColumnName("FHash");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithOne(p => p.TrsappUsersMsgsItemsDatum)
                    .HasForeignKey<TrsappUsersMsgsItemsDatum>(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgsItemsData_Parent");
            });

            modelBuilder.Entity<TrsappUsersMsgsSigned>(entity =>
            {
                entity.HasKey(e => new { e.FkParent, e.FkType })
                    .HasName("PK_RSAppUsersMsgsSigned");

                entity.ToTable("TRSAppUsersMsgsSigned");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsappUsersMsgsSigneds)
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgsSigned_Parent");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.TrsappUsersMsgsSigneds)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersMsgsSigned_Type");
            });

            modelBuilder.Entity<TrsappUsersTemplatesLink>(entity =>
            {
                entity.HasKey(e => e.FkParent)
                    .HasName("PK_RSAppUsersTemplatesLinks");

                entity.ToTable("TRSAppUsersTemplatesLinks");

                entity.Property(e => e.FkParent)
                    .ValueGeneratedNever()
                    .HasColumnName("FK_Parent");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany(p => p.TrsappUsersTemplatesLinks)
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersTemplatesLinks_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithOne(p => p.TrsappUsersTemplatesLink)
                    .HasForeignKey<TrsappUsersTemplatesLink>(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSAppUsersTemplatesLinks_Parent");
            });

            modelBuilder.Entity<TrsdirAccTemplatesAccessGroup>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAccTemplatesAccessGroups");

                entity.ToTable("TRSDirAccTemplatesAccessGroups", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAccTemplatesAccessGroups_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAccTemplatesAccessType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAccTemplatesAccessTypes");

                entity.ToTable("TRSDirAccTemplatesAccessTypes", "dir");

                entity.HasIndex(e => new { e.FkGroup, e.Fname }, "UK_RSDirAccTemplatesAccessTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkGroup).HasColumnName("FK_Group");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FName");

                entity.HasOne(d => d.FkGroupNavigation)
                    .WithMany(p => p.TrsdirAccTemplatesAccessTypes)
                    .HasForeignKey(d => d.FkGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSDirAccTemplatesAccessTypes_Group");
            });

            modelBuilder.Entity<TrsdirAppContact>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppContacts");

                entity.ToTable("TRSDirAppContacts", "dir");

                entity.HasIndex(e => new { e.FlinkGroup, e.FlinkId }, "UK_RSDirAppContacts_Link")
                    .IsUnique();

                entity.HasIndex(e => e.Fname, "UK_RSDirAppContacts_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Fcode)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("FCode")
                    .HasComputedColumnSql("((CONVERT([varchar],[FLinkGroup],(0))+':')+CONVERT([varchar],[FLinkID],(0)))", false);

                entity.Property(e => e.Fcomment)
                    .HasMaxLength(150)
                    .HasColumnName("FComment");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FlinkGroup).HasColumnName("FLinkGroup");

                entity.Property(e => e.FlinkId).HasColumnName("FLinkID");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");

                //entity.HasOne(d => d.TrsdirAppContactsLinks)
                //    .WithOne(p => p.FkParentNavigation)
                //    .HasForeignKey<TrsdirAppContactsLink>(d => d.FkParent)
                //    .HasConstraintName("FK_RSDirAppContactsLinks_Parent");
            });

            modelBuilder.Entity<TrsdirAppContactsLink>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppContactsLinks");

                entity.ToTable("TRSDirAppContactsLinks", "dir");

                entity.HasIndex(e => e.FkParent, "UI_RSDirAppContactsLinks_FlagPrimary")
                    .IsUnique()
                    .HasFilter("([FFlagPrimary]=(1))");

                entity.HasIndex(e => new { e.FkParent, e.Fcontact }, "UK_RSDirAppContactsLinks_Contact")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.Fcontact)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FContact");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FflagPrimary).HasColumnName("FFlagPrimary");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany(p => p.TrsdirAppContactsLinks)
                    .HasForeignKey(d => d.FkParent)
                    .HasConstraintName("FK_RSDirAppContactsLinks_Parent");
            });

            modelBuilder.Entity<TrsdirAppFilesType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppFilesTypes");

                entity.ToTable("TRSDirAppFilesTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppFilesTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ffilter)
                    .HasMaxLength(150)
                    .HasColumnName("FFilter");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppScenariosActionsGroup>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppScenariosActionsGroups");

                entity.ToTable("TRSDirAppScenariosActionsGroups", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppScenariosActionsGroups_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppScenariosActionsType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppScenariosActionsTypes");

                entity.ToTable("TRSDirAppScenariosActionsTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppScenariosActionsTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName")
                    .UseCollation("Cyrillic_General_CS_AS");
            });

            modelBuilder.Entity<TrsdirAppScenariosGroupsType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppScenariosGroupsTypes");

                entity.ToTable("TRSDirAppScenariosGroupsTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppScenariosGroupsTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName")
                    .UseCollation("Cyrillic_General_CS_AS");
            });

            modelBuilder.Entity<TrsdirAppScenariosItemsType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppScenariosItemsTypes");

                entity.ToTable("TRSDirAppScenariosItemsTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppScenariosItemsTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppScenariosType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppScenariosTypes");

                entity.ToTable("TRSDirAppScenariosTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppScenariosTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagCustom).HasColumnName("FFlagCustom");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppTemplatesAccessType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppTemplatesAccessTypes");

                entity.ToTable("TRSDirAppTemplatesAccessTypes", "dir");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Fcomment)
                    .HasMaxLength(255)
                    .HasColumnName("FComment");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");
            });

            modelBuilder.Entity<TrsdirAppUsersMsgsItemsType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppUsersMsgsItemsTypes");

                entity.ToTable("TRSDirAppUsersMsgsItemsTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppUsersMsgsItemsTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.FdateChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateChanged")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FdateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("FDateCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppUsersMsgsSignedType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppUsersMsgsSignedTypes");

                entity.ToTable("TRSDirAppUsersMsgsSignedTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppUsersMsgsSignedTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FflagIn).HasColumnName("FFlagIn");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirAppUsersMsgsSignedTypesLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TRSDirAppUsersMsgsSignedTypesLinks", "dir");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.FkLink).HasColumnName("FK_Link");

                entity.Property(e => e.FkParent).HasColumnName("FK_Parent");

                entity.HasOne(d => d.FkLinkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkLink)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSDirAppUsersMsgsSignedTypesLinks_Link");

                entity.HasOne(d => d.FkParentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FkParent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RSDirAppUsersMsgsSignedTypesLinks_Parent");
            });

            modelBuilder.Entity<TrsdirAppUsersMsgsType>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirAppUsersMsgsTypes");

                entity.ToTable("TRSDirAppUsersMsgsTypes", "dir");

                entity.HasIndex(e => e.Fname, "UK_RSDirAppUsersMsgsTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("FName");
            });

            modelBuilder.Entity<TrsdirLanguage>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_RSDirLanguages");

                entity.ToTable("TRSDirLanguages", "dir");

                entity.Property(e => e.Fid)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FID")
                    .IsFixedLength(true);

                entity.Property(e => e.FflagDefault).HasColumnName("FFlagDefault");

                entity.Property(e => e.FflagExpire).HasColumnName("FFlagExpire");
            });

            modelBuilder.HasSequence<int>("SRSDirAppContacts", "dir").IsCyclic();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
