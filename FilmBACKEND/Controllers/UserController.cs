using AutoMapper;
using FilmBACKEND.Dtos.PhotoDtos;
using FilmBACKEND.Interfaces;
using FilmBACKEND.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmBACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Context _context;
        private readonly IPhotoService _photoService;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, Context context, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
            _photoService = photoService;
        }
        [HttpPost("add-photo")]
        public async Task<ActionResult<List<PhotoDto>>> AddPhoto(int id, IFormFile file)
        {
            //var user = await _unitOfWork.Users.GetUserByIdAsync(id);
            //var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());
            var result = await  _unitOfWork.PhotoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);
            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            _unitOfWork.Users.AddPhoto(photo,id);
            //user.Photos.Add(photo);


            if (await _unitOfWork.Users.SaveAllAsync())
            {

                return Ok("Photo succesfully added");

            }

            return BadRequest("problem adding photo");
        }


    }
}
