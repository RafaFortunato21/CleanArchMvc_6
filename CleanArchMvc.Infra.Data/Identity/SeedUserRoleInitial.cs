using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedUsers()
    {
        var userData = "usuario@localhost";
        if (_userManager.FindByEmailAsync(userData).Result == null)
        {
            ApplicationUser user = new ApplicationUser();
            
            user.UserName = userData;
            user.Email = userData;
            user.NormalizedUserName = userData.ToUpper();
            user.NormalizedEmail = userData.ToUpper();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Ipiranga#01").Result;

            if (result.Succeeded)
                _userManager.AddToRoleAsync(user, "User").Wait();
        }

        userData = "admin@localhost";
        
        if (_userManager.FindByEmailAsync(userData).Result == null)
        {
            ApplicationUser user = new ApplicationUser();

            user.UserName = userData;
            user.Email = userData;
            user.NormalizedUserName = userData.ToUpper();
            user.NormalizedEmail = userData.ToUpper();
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Ipiranga#02").Result;

            if (result.Succeeded)
                _userManager.AddToRoleAsync(user, "Admin").Wait();
        }
    }

    public void SeedRoles()
    {
        var roleData = "User";
        if (! _roleManager.RoleExistsAsync(roleData).Result)
        {
            IdentityRole role = new IdentityRole();

            role.Name = roleData;
            role.NormalizedName = roleData.ToUpper();
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        roleData = "Admin";

        if (!_roleManager.RoleExistsAsync(roleData).Result)
        {
            IdentityRole role = new IdentityRole();

            role.Name = roleData;
            role.NormalizedName = roleData.ToUpper();
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

   
}
