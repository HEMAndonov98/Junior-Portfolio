﻿namespace TheBookSummary.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using TheBookSummary.Common;
    using TheBookSummary.Data.Models.Identity;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            await SeedRoleAsync(roleManager, GlobalConstants.AdministratorRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.ModeratorRoleName);
            await SeedRoleAsync(roleManager, GlobalConstants.ManagerRoleName);
            await SeedAdministrator(userManager, configuration);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedAdministrator(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            string email = configuration["Administrator:Email"]!;
            string password = configuration["Administrator:Password"]!;

            if (await userManager.FindByEmailAsync(email) == null)
            {
                var admin = new ApplicationUser();
                admin.Email = email;
                admin.UserName = email;

                await userManager.CreateAsync(admin, password);

                await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
