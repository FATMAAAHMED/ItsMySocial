
using Contracts;
using ItsMySocialContext;
using ItsMySocialDomain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IUserRepository
    {
        //private readonly socialDbContext _context;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        //private readonly RoleManager<IdentityRole<long>> _roleManager;
        ////private readonly ILogger<UserController> _logger;
        //private readonly IMapper _mapper;
        //private readonly HttpContext _httpContext;
    //    public UserRepository(socialDbContext context)
    //    {
    //        _context = context;
            
    //    }
    
    //    public async Task AddUserAsync(User user)
    //    {
    //        await _context.Users.AddAsync(user);
    //        await _context.SaveChangesAsync();

               
    //    }

    //    public async Task<User> GetUserByUserNameAsync(string userName)
    //    {
    //        return await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
    //    }
    }
}
