using Dapper;
using Entity.Model.Location;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

namespace Entity.Model.Context
{
    public class AplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Security.Module> Modules { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleView> RoleView { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<UserRole> Userroles { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Continent> Continents { get; set; }
    }

    public readonly struct DapperEFCoreCommand : IDisposable
    {
        public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
        {
            var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            var commandType = type ?? CommandType.Text;
            var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

            Definition = new CommandDefinition(
                text,
                parameters,
                transaction,
                commandTimeout,
                commandType,
                cancellationToken: ct
            );
        }
        public CommandDefinition Definition { get; }
        public void Dispose() { }
    }
}
