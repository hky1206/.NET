using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.ViewModel
{
    public class LoginViewModel
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Làm ơn nhập tài khoản")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Làm ơn nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
