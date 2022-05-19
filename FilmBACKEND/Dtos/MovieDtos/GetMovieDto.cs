using FilmBACKEND.Dtos.UserDtos;
using FilmBACKEND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Dtos.FilmDtos
{
    public class GetMovieDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public GetUserDto User { get; set; }
    }
}
