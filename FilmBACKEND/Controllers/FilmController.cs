using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmBACKEND.Dtos.FilmDtos;
using FilmBACKEND.Dtos.MovieDtos;
using FilmBACKEND.Interfaces;
using FilmBACKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IPhotoService _photoService;

        public FilmController(IUnitOfWork unitOfWork, IMapper mapper, Context context, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _photoService = photoService;
        }
        //[HttpGet("Film")]

        //public  IActionResult GetMovies()
        //{
        //    var Movies = _unitOfWork.Movies.GetAll();
        //    return Ok(Movies);
        //}



        [HttpGet("Films")]
        public async Task<ActionResult<IEnumerable<GetMovieDto>>> GetMoviesList()
        {
            var Movies = await _unitOfWork.Movies.GetAllMovies();

            return Ok(Movies);
        }


        [HttpPost]
        public async Task<ActionResult> AddMovie(CreateMovieDto filmDto)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(filmDto.OwnerId);
            var movie = new Movie
            {
                Name = filmDto.Name,
                OwnerId = filmDto.OwnerId,
                Owner = user
            };
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();
            return Ok(movie);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(CreateMovieDto filmDto)
        {
            var movie = new Movie
            {
                Name = filmDto.Name
            };
            _unitOfWork.Movies.Update(movie);
            _unitOfWork.Complete();
            return Ok(movie);
        }

        [HttpPut("Renting")]
        public async Task<ActionResult> RentMovie(RentMovieDto rentMovie)
        {
            var movie = new Movie
            {
                RenterId = rentMovie.RenterId
            };
            _unitOfWork.Movies.Update(movie);
            _unitOfWork.Complete();
            return  Ok(movie);
        }
        [HttpPut("UnRent")]
        public async Task<ActionResult> UnrentMovie(RentMovieDto rentMovie)
        {
            var movie = new Movie
            {
                RenterId = rentMovie.RenterId
            };
            _unitOfWork.Movies.Delete(movie);
            _unitOfWork.Complete();
            return Ok("Success");
        }

    }
}
