using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieRole> MovieRoles { get; set; }
        public int OwnerId { get; set; } 
        public AppUser Owner { get; set; }
        public int? RenterId { get; set; }  
        public AppUser Renter { get; set; }
        // DODAJ DA SE MORE RENTAT KAD DODJES OPET
    }
}
