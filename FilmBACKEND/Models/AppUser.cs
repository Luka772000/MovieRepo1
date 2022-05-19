using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime DateOfBirth { get; set; }
        public List<AppUserRole> UserRoles { get; set; }
        public List<Photo> Photos { get; set; }    
        public List<Movie> OwnedMovies { get; set; }
        public List<Movie> RentedMovies { get; set; }
    }
}
