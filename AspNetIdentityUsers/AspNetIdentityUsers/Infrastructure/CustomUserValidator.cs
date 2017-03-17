using AspNetIdentityUsers.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AspNetIdentityUsers.Infrastructure
{
    //public class CustomUserValidator : UserValidator<AppUser>
    //{
    //    public CustomUserValidator(UserManager<AppUser, string> manager) : base(manager)
    //    { }

    //    public override async Task<IdentityResult> ValidateAsync(AppUser item)
    //    {
    //        var result = await base.ValidateAsync(item);

    //        if (!item.Email.ToLower().EndsWith("@mymail.com"))
    //        {
    //            var errors = result.Errors.ToList();
    //            errors.Add("Любой мыло-адрес, отличный от mymail.com запрещен");
    //            result = new IdentityResult(errors);
    //        }

    //        return result;
    //    }
    //}

    public class CustomUserValidator : IIdentityValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(AppUser item)
        {
            return await Task.Run(() =>
            {
                var errors = new List<string>();

                if (string.IsNullOrWhiteSpace(item.UserName))
                {
                    errors.Add("Указано пустое имя");
                }

                var userNamePattern = @"^[a-zA-Z0-9а-яА-Я]+$";

                if (!Regex.IsMatch(item.UserName, userNamePattern))
                {
                    errors.Add("В имени разрешается указывать буквы английского или русского языков, и цифры");
                }

                if (errors.Any())
                {
                    return IdentityResult.Failed(errors.ToArray());
                }

                return IdentityResult.Success;
            });
        }
    }
}