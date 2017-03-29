using System;
namespace ProductsShop.Models
{
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }

        public ICollection<Product> SoldProducts { get; set; } = new HashSet<Product>();
        public ICollection<Product> BoughtProducts { get; set; } = new HashSet<Product>();
        public virtual ICollection<User> Friends { get; set; } = new HashSet<User>();
    }
}
