using AspNetIdentityUsers.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace AspNetIdentityUsers.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(UserManager<AppUser, string> manager) : base(manager)
        { }

        public override async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            var result = await base.ValidateAsync(item);

            if (!item.Email.ToLower().EndsWith("@mymail.com"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Любой мыло-адрес, отличный от mymail.com запрещен");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}