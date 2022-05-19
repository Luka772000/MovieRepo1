using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Dtos.FilmDtos
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public int OwnerId { get; set; }
    }
}
