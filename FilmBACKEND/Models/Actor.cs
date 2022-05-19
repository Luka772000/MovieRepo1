using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieRole> MovieRoles{ get; set; }
    }
}
