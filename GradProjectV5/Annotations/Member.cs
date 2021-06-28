using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(MemberAnnotations))]
    public partial class Member
    {
    }
    public class MemberAnnotations
    {
        [Display(Name = "الاسم بالكامل")]
        [Required(ErrorMessage = "يتطلب ادخال الاسم بالكامل")]
        public string FullName { get; set; }


        [Display(Name = "الرقم القومي")]
        [RegularExpression(@"[0-9]{14}",ErrorMessage = "يرجي ادخل رقم قومي صحيح")]
        [Required(ErrorMessage = "يتطلب ادخال الرقم القومي")]
        public string NationalId { get; set; }


        [RegularExpression(@"(01)[0-9]{9}", ErrorMessage = "يتطلب ادخال رقم هاتف صحيح ")]
        [Required(ErrorMessage = "يتطلب ادخال رقم الهاتف ")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNo { get; set; }


        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "يتطلب ادخال العنوان")]
        public string Address { get; set; }


        [Display(Name = "العمر")]
        [Required(ErrorMessage = "يتطلب ادخال العمر ")]
        [RegularExpression(@"[0-9]{2}" , ErrorMessage = "يتطلب ادخال عمر صحيح ")]
        public string Age { get; set; }
    }
}