using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SIGA.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // ⚠️ IMPORTANTE: Cambia esta cadena por la de tu base de datos PostgreSQL
        optionsBuilder.UseNpgsql(
            "Host=127.0.0.1;Database=db_siga;Username=developer;Password=3z3Qu!3l_1994"
        );

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
