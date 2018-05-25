using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace WebApplication1.Models
{
    public class IndexViewModel
    {
        public string UserId { get; set; } 
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The value {0} must contain at least the following characters: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and its confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The value {0} must contain at least the following characters: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and its confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
    public class NewOrderViewModel
    {
        [Required]
        [Display(Name = "E-mail address")]
        public string MainName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Discription { get; set; }

        [Required]
        [Display(Name = "Password confirmation")]
        public string Price { get; set; }

        //[Required]
        //public DateTime DateIn { get; set; }

        //[Required]
        //public DateTime DateOut { get; set; }
    }
  
    public partial class DbUserOrder
    {
   
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(128)]
        public string User1Id { get; set; }

        [StringLength(128)]
        public string User2Id { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateOut { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        public string Discription { get; set; }

        public string WayFile { get; set; }
        
        public string MainName { get; set; }

    }
}