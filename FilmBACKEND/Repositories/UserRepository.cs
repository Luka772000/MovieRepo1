using AutoMapper;
using AutoMapper.QueryableExtensions;
using FilmBACKEND.Dtos.UserDtos;
using FilmBACKEND.Interfaces;
using FilmBACKEND.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmBACKEND.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public UserRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetUserAsync()
        {
            return await _context.AppUsers
                .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers.Include(p=> p.Photos).SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string UserName)
        {

            return await _context.AppUsers
                .SingleOrDefaultAsync(x => x.UserName == UserName);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
        public void Create(AppUser user)
        {   
            _context.Users.Add(user);
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.AppUsers.ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async void AddPhoto(Photo photo, int id)
        {
            var user = await GetUserByIdAsync(id);
            user.Photos.Add(photo);
        }
    }
}
