using FilmBACKEND.Dtos.FilmDtos;
using FilmBACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmBACKEND.Interfaces
{
    public interface IMovieRepository:IGenericRepository<Movie>
    {
        //void AddRole(MovieRole role);
        IEnumerable<Movie> GetMoviesCount(int count);
        Task<ActionResult<IEnumerable<GetMovieDto>>> GetAllMovies();

    }
}
