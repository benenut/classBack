using Microsoft.AspNetCore.Identity;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthServices
    {
        public readonly UserManager<Users> _userManager; 
        public readonly RoleManager<Role> _roleManager;

        public AuthServices(UserManager<Users> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SignInAsync(SignInDTO user)
        {
            Users userToAdd = new Users()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
            };
            var result = await _userManager.CreateAsync(userToAdd, user.Password);
            if (result.Succeeded)
            {
                return;
            }
            else
            {
                throw new BadHttpRequestException(result.Errors.FirstOrDefault().Description);
            }
        }

        public void SignIn(SignInDTO signInDTO )
        {

        }

        public async Task RoleAsync(RoleDTO role)
        {
            Role roleToAdd = new Role()
            {
                Name = role.Name,
                Description = role.Description,
            };  
            var result = await _roleManager.CreateAsync(roleToAdd);
            if (result.Succeeded)
            {
                return;
            }
            else
            {
                throw new BadHttpRequestException(result.Errors.FirstOrDefault().Description);
            }
        }
        public void Role(RoleDTO roleDTO)
        {
        
        }



    }
}
