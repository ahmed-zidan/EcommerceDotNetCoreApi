using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [ForeignKey("ProductBrand")]
        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}
