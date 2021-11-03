using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TheBookShop.Common;
using TheBookShop.DataAccess.Data;

namespace TheBookShop.API.Helpers
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception) { }

            #region Roles
            if (!_db.Roles.Any(x => x.Name == SD.RoleAdmin))
            {
                _roleManager.CreateAsync(new IdentityRole(SD.RoleAdmin)).GetAwaiter().GetResult();
            }

            if (!_db.Roles.Any(x => x.Name == SD.RoleEmployeee))
            {
                _roleManager.CreateAsync(new IdentityRole(SD.RoleEmployeee)).GetAwaiter().GetResult();
            }

            if (!_db.Roles.Any(x => x.Name == SD.RolePatron))
            {
                _roleManager.CreateAsync(new IdentityRole(SD.RolePatron)).GetAwaiter().GetResult();
            }
            #endregion

            #region AdminUser
            if (_roleManager.FindByNameAsync("admin@thebookshop.co.za").GetAwaiter().GetResult() == null)
            {
                IdentityResult result = _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@thebookshop.co.za",
                    Email = "admin@thebookshop.co.za",
                    FirstName = "Admin",
                    EmailConfirmed = true
                }, "Admin123*").GetAwaiter().GetResult();

                if (result.Succeeded)
                {
                    ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == "admin@thebookshop.co.za");
                    _userManager.AddToRoleAsync(user, SD.RoleAdmin).GetAwaiter().GetResult();
                }
            }
            #endregion

        }
    }
}
