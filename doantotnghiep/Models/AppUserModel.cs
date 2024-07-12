using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    namespace WebApplication2.Models
    {
        public class AppUserModel : IdentityUser
        {
            public string Ocupation { get; set; }
        }
    }

}
