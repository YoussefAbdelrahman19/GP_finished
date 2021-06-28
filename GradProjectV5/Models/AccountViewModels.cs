using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradProjectV5.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "الإيميل")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "يتطلب ادخال البريد الإلكتروني للمستخدم")]
        [Display(Name = "البريد الإلكتروني")]
        [EmailAddress(ErrorMessage = "ادخل عنوان بريد الكتروني صحيح")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يتطلب ادخال الرقم السري")]
        [DataType(DataType.Password)]
        [Display(Name = "الرقم السري")]
        public string Password { get; set; }

        [Display(Name = " تذكرني  ؟")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }



        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "الرقم السري")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد الرقم السري")]
        [Compare("Password", ErrorMessage = "الرقم السري غير متطابق ")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "الرقم السري")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد الرقم السري")]
        [Compare("Password", ErrorMessage = "الرقم السري غير متطابق ")]

        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
    }
}
