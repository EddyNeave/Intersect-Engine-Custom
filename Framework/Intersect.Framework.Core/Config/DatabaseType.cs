using Intersect.Framework.Annotations;

namespace Intersect.Config;

public enum DatabaseType
{
    [Ignore]
    Unknown,

    SQLite,

    Sqlite = SQLite,

    sqlite = SQLite
}