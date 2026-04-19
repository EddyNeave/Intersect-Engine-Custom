using Intersect.Config;
using SqlKata.Compilers;

namespace Intersect.Server.Database;

public interface IDataMigrationSqlGenerator
{
    IEnumerable<string> Generate(DatabaseType databaseType);

    Compiler PickCompiler(DatabaseType databaseType) =>
        databaseType switch
        {
            DatabaseType.Unknown => throw new NotImplementedException(),
            DatabaseType.SQLite => new SqliteCompiler(),
            _ => throw new ArgumentOutOfRangeException(nameof(databaseType), databaseType, null)
        };
}