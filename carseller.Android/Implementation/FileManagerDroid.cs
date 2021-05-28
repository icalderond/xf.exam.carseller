using System;
using System.IO;
using carseller.Abstractions;
using carseller.Droid.Implementation;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManagerDroid))]
namespace carseller.Droid.Implementation
{
    public class FileManagerDroid : IFileManager
    {
        public string GetSQLiteDBPath(string _databaseName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, _databaseName);
        }
    }
}
