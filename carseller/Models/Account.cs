using SQLite;

namespace carseller.Models
{
    [Table("Account")]
    public class Account
    {
        private int _Id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _Id;
            set => _Id = value;
        }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
