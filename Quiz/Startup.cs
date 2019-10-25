using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//new Microsoft.AspNet.Identity.EntityFramework.IdentityRole;
using Microsoft.Owin;
using Owin;
using Quiz.Models;

[assembly: OwinStartupAttribute(typeof(Quiz.Startup))]
namespace Quiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers ()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

        //    if (!roleManager.RoleExists("Admin"))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        var user = new ApplicationUser();
        //        user.UserName = "Kris Jenner";
        //        user.Email = "kris.jenner@admin.com";

        //        var checkUser = userManager.Create(user);

        //        if(checkUser.Succeeded)
        //        {
        //            var result = userManager.AddToRole(user.Id, "Admin");
        //        }
        //    }

        //    if(!roleManager.RoleExists("Manager"))
        //    {
        //        var role = new IdentityRole();
        //        role.Name = "Manager";
        //        roleManager.Create(role);
        //    }

        //    if (!roleManager.RoleExists("User"))
        //    {
        //        var role = new IdentityRole();
        //        role.Name ="User";
        //        roleManager.Create(role);
        //    }
        }
    }
}
