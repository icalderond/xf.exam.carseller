using System;
using System.IO;
using carseller.Abstractions;
using carseller.iOS.Implementation;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManageriOS))]
namespace carseller.iOS.Implementation
{
    public class FileManageriOS : IFileManager
    {
        public string GetSQLiteDBPath(string _databaseName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, _databaseName);
        }
    }
}
