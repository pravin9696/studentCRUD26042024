using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace studentCRUD26042024.Models
{
    public class LoginModel
    {
        public int id { get; set; }
        [Display(Name ="User ID")]
        [DataType(DataType.EmailAddress)]
        public string userid { get; set; }
        [Display(Name = "Password..")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}