namespace carseller.Abstractions
{
    public interface IFileManager
    {
        string GetSQLiteDBPath(string _databaseName);
    }
}
