using System.ComponentModel.DataAnnotations;

namespace RegistrationApp.Models;

public class User
{
    [Display(Name = "Tài khoản")]
    [Required(ErrorMessage = "Tên người dùng không được để trống")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 50 ký tự")]
    public string Username { get; set; } = string.Empty;

    [Display(Name = "Địa chỉ Email")]
    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải ít nhất 6 ký tự")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Display(Name = "Xác thực mật khẩu")]
    [Required(ErrorMessage = "Xác thực mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu và Xác nhận mật khẩu không trùng khớp")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
