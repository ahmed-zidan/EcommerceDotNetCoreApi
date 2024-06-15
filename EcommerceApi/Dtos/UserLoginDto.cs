using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=^.{6,255}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*",
            ErrorMessage = "1.) at least 1 upper case character\n 2.) at least 1 lower case character \n" +
            "3.) at least 1 numerical character \n" +
            "4.) at least 1 special character It also enforces a min and max length")]
        public string Password { get; set; }
    }
}
