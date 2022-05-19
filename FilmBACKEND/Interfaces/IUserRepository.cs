using FilmBACKEND.Dtos.UserDtos;
using FilmBACKEND.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmBACKEND.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        void Create(AppUser user);
        void AddPhoto(Photo photo,int id);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUserAsync();

        Task< AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
        
    }
}
