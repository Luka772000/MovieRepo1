using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmBACKEND.Dtos.FilmDtos;
using FilmBACKEND.Interfaces;
using FilmBACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Repositories
{
    public class MovieRepository:GenericRepository<Movie>, IMovieRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public MovieRepository(Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        

        public IEnumerable<Movie> GetMoviesCount(int count)
        {
            return _context.Movies.OrderByDescending(d => d.Name).Take(count).ToList();
        }
        public async Task<ActionResult<IEnumerable<GetMovieDto>>> GetAllMovies()
        {
            return await _context.Movies.ProjectTo<GetMovieDto>(_mapper.ConfigurationProvider).ToListAsync();

        }

    }
}
