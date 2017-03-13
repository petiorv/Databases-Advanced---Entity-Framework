using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Photographer
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Album> Albums { get; set; }
        
    }
}
