namespace VulnerableWebApp
{
    public static class Constants
    {
        public const string VALUE_SEPARATOR = "||";

        public static class DatabaseUtils
        {
            public static string SQL_CONNECTION_STRING = string.Empty;         
        }

        public enum EntityState
        {
            Unchanged,
            Added,
            Modified,
            Deleted
        }
    }
}
