using app_citas_psico.Models;
using app_citas_psico.Models.Procedures;
using Microsoft.EntityFrameworkCore;

namespace app_citas_psico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las entidades y relaciones si es necesario
            base.OnModelCreating(modelBuilder);
            #region Modelos
            modelBuilder.Entity<OPCIONES>().ToTable("OPCION").HasIndex(x => x.ID_OPCION).IsUnique();
            modelBuilder.Entity<ROL>().ToTable("ROL").HasIndex(x => x.ID_ROL).IsUnique();
            modelBuilder.Entity<OPCION_ROL>().ToTable("OPCION_ROL").HasIndex(x => x.ID_OPCION_ROL).IsUnique();
            modelBuilder.Entity<USUARIO>().ToTable("USUARIO").HasIndex(x => x.ID_USUARIO).IsUnique();
            modelBuilder.Entity<USUARIO_ROL>().ToTable("USUARIO_ROL").HasIndex(x => x.ID_USUARIO_ROL).IsUnique();
            modelBuilder.Entity<CLIENTE>().ToTable("CLIENTE").HasIndex(x => x.ID_CLIENTE).IsUnique();
            modelBuilder.Entity<PSICOLOGO>().ToTable("PSICOLOGO").HasIndex(x => x.ID_PSICOLOGO).IsUnique();
            modelBuilder.Entity<SERVICIOS>().ToTable("SERVICIO").HasIndex(x => x.ID_SERVICIO).IsUnique();
            modelBuilder.Entity<PSICOLOGO_SERVICIO>().ToTable("PSICOLOGO_SERVICIO").HasIndex(x => x.ID_PSICOLOGO_SERVICIO).IsUnique();
            modelBuilder.Entity<HORARIOS>().ToTable("HORARIO").HasIndex(x => x.ID_HORARIO).IsUnique();
            modelBuilder.Entity<PSICOLOGO_HORARIO>().ToTable("PSICOLOGO_HORARIO").HasIndex(x => x.ID_PSICOLOGO_HORARIO).IsUnique();
            modelBuilder.Entity<COLABORADOR>().ToTable("COLABORADOR").HasIndex(x => x.ID_COLABORADOR).IsUnique();
            modelBuilder.Entity<CITAS>().ToTable("CITAS").HasIndex(x => x.ID_CITAS).IsUnique();
            modelBuilder.Entity<ARCHIVOS_CITAS>().ToTable("ARCHIVOS_CITAS").HasIndex(x => x.ID_ARCHIVOS_CITAS).IsUnique();
            modelBuilder.Entity<HISTORIAL_CITAS>().ToTable("HISTORIAL_CITAS").HasIndex(x => x.ID_HISTORIAL_CITAS).IsUnique();
            #endregion

            #region Views
            #endregion

            #region Stored Procedures
            modelBuilder.Entity<SP_LISTA_OPCIONES_USUARIO>().ToTable("SP_LISTA_OPCIONES_USUARIO").HasIndex(x => x.ID_OPCION).IsUnique();
            #endregion
        }

        public DbSet<OPCIONES> OPCIONES { get; set; }
        public DbSet<ROL> ROL { get; set; }
        public DbSet<OPCION_ROL> OPCION_ROL { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
        public DbSet<USUARIO_ROL> USUARIO_ROL { get; set; }
        public DbSet<CLIENTE> CLIENTE { get; set; }
        public DbSet<PSICOLOGO> PSICOLOGO { get; set; }
        public DbSet<SERVICIOS> SERVICIOS { get; set; }
        public DbSet<PSICOLOGO_SERVICIO> PSICOLOGO_SERVICIO { get; set; }
        public DbSet<HORARIOS> HORARIOS { get; set; }
        public DbSet<PSICOLOGO_HORARIO> PSICOLOGO_HORARIO { get; set; }
        public DbSet<COLABORADOR> COLABORADOR { get; set; }
        public DbSet<CITAS> CITAS { get; set; }
        public DbSet<ARCHIVOS_CITAS> ARCHIVOS_CITAS { get; set; }
        public DbSet<HISTORIAL_CITAS> HISTORIAL_CITAS { get; set; }

        #region Stored Procedures
        public DbSet<SP_LISTA_OPCIONES_USUARIO> SP_LISTA_OPCIONES_USUARIO { get; set; }
        #endregion
    }
}
