using Intersect.Config;
using Intersect.Server.Database.GameData;
using Intersect.Server.Database.Logging;
using Intersect.Server.Database.PlayerData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Design;

namespace Intersect.Server.Database;

internal class SqliteGameContextFactory : IDesignTimeDbContextFactory<SqliteGameContext>
{
    public SqliteGameContext CreateDbContext(string[] args)
    {
        return new SqliteGameContext(new DatabaseContextOptions
        {
            ConnectionStringBuilder = new SqliteConnectionStringBuilder("Data Source=gamedata.db"),
            DatabaseType = DatabaseType.SQLite,
        });
    }
}

internal class SqlitePlayerContextFactory : IDesignTimeDbContextFactory<SqlitePlayerContext>
{
    public SqlitePlayerContext CreateDbContext(string[] args)
    {
        return new SqlitePlayerContext(new DatabaseContextOptions
        {
            ConnectionStringBuilder = new SqliteConnectionStringBuilder("Data Source=playerdata.db"),
            DatabaseType = DatabaseType.SQLite,
        });
    }
}

internal class SqliteLoggingContextFactory : IDesignTimeDbContextFactory<SqliteLoggingContext>
{
    public SqliteLoggingContext CreateDbContext(string[] args)
    {
        return new SqliteLoggingContext(new DatabaseContextOptions
        {
            ConnectionStringBuilder = new SqliteConnectionStringBuilder("Data Source=logging.db"),
            DatabaseType = DatabaseType.SQLite,
        });
    }
}