using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class Data
    {
        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public Data()
        {
            Categories = new List<Category>{
                new Category { Id = 1, ImageName = "chiars", Name = "Chairs" },
                new Category { Id = 2, ImageName = "tables", Name = "Tables" },
                new Category { Id = 3, ImageName = "lights", Name = "Lights" },
            };

            Products = new List<Product> {
            new Product{CategoryId = 1, Id = 1, ImageName="riale", Name="Riale", Price= 100.0,},
            new Product{CategoryId = 1, Id = 2, ImageName="chair", Name="Chair", Price= 500.0,},
            new Product{CategoryId = 1, Id = 3, ImageName="bookshelf", Name="Book Shelf", Price= 1000.0,},
            new Product{CategoryId = 1, Id = 4, ImageName="cherries-floor-lamp", Name="Floor Lamp", Price= 1000.0,},
            new Product{CategoryId = 1, Id = 5, ImageName="rattan-sit", Name="Rattan", Price= 300.0,},
            new Product{CategoryId = 1, Id = 6, ImageName="wall-clock", Name="Wall Clock", Price= 90.99,},
            new Product{CategoryId = 1, Id = 7, ImageName="wood-table", Name="Wood Table", Price= 500.0,},
            };
        }
    }
}
