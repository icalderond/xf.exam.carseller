using SQLite;

namespace carseller.Models
{
    [Table("Product")]
    public class Product
    {
        private int _Id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => _Id;
            set => _Id = value;
        }

        private string _Model;
        public string Model
        {
            get => _Model;
            set => _Model = value;
        }

        private string _Description;
        public string Description
        {
            get => _Description;
            set => _Description = value;
        }

        private int _Year;
        public int Year
        {
            get => _Year;
            set => _Year = value;
        }

        private string _Brand;
        public string Brand
        {
            get => _Brand;
            set => _Brand = value;
        }

        private int _Kilometers;
        public int Kilometers
        {
            get => _Kilometers;
            set => _Kilometers = value;
        }

        private decimal _Price;
        public decimal Price
        {
            get => _Price;
            set => _Price = value;
        }
    }
}
