using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetIdentityUsers.Models
{
    public enum Cities
    {
        [Display(Name = "London")]
        LONDON,
        [Display(Name = "Paris")]
        PARIS,
        [Display(Name = "Moscow")]
        MOSCOW
    }

    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
    }
}