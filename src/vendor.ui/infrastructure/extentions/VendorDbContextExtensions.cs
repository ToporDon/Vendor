using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using vendor.domain.data;
using vendor.domain.entities;

namespace vendor.ui.controllers.extentions
{
    public static class VendorDbContextExtensions
    {
        public static void EnsureSeedData(this VendorDbContext context)
        {
            if (context.IsMigrationsApplied())
            {
                if (!context.Users.Any())
                {
                    context.Users.Add(
                        new User
                        {
                            UserName = "Сервисный пользователь",
                            Email = "-",
                            LockoutEnabled = false,
                            Image = null,
                            RegisterDate = DateTime.Now,
                            UpdateDate = DateTime.Now
                        });
                    context.SaveChanges();
                }
                if (!context.LanguageDict.Any())
                {
                    context.LanguageDict.AddRange(
                        new LanguageDict { Name = "Русский", Alias = "ru-RU", IsDefault = true, UpdateDate = DateTime.Now, UpdateUserId = 1 },
                        new LanguageDict { Name = "English", Alias = "en-US", IsDefault = false, UpdateDate = DateTime.Now, UpdateUserId = 1 });

                    context.SaveChanges();
                }
            }
        }

        public static async void Setup(this VendorDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                adminRole = new Role("Admin");

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.view"));

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.create"));

                await roleManager.AddClaimAsync(adminRole, new Claim(ClaimTypes.Role, "projects.update"));
            }

            if (!await userManager.IsInRoleAsync(user, adminRole.Name))
            {
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }

            var accountManagerRole = await roleManager.FindByNameAsync("Account Manager");

            if (accountManagerRole == null)
            {
                accountManagerRole = new Role("Account Manager");

                await roleManager.CreateAsync(accountManagerRole);

                await roleManager.AddClaimAsync(accountManagerRole, new Claim(ClaimTypes.Role, "account.manage"));
            }

            if (!await userManager.IsInRoleAsync(user, accountManagerRole.Name))
            {
                await userManager.AddToRoleAsync(user, accountManagerRole.Name);
            }
        }

    }
}