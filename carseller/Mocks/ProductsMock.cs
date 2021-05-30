using System.Collections.Generic;
using carseller.Models;

namespace carseller.Mocks
{
    public static class ProductsMock
    {
        public static List<Product> Products = new List<Product>
        {
            new Product{Brand="Ford",Model="Focus",Year=2010,Kilometers=10000,Price=10000 },
            new Product{Brand="Chevrolet",Model="Impala",Year=2011,Kilometers=100000,Price=150000 },
            new Product{Brand="Nissan",Model="GTR",Year=2015,Kilometers=5000,Price=1000000 },
            new Product{Brand="Volkswagen",Model="Jetta",Year=2009,Kilometers=120000,Price=110000 },
            new Product{Brand="Toyota",Model="RAV-4",Year=2015,Kilometers=50000,Price=200000 }
        };
    }
}
