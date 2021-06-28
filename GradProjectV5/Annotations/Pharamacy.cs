using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(PharamacyAnnotation))]

    public partial class Pharamacy
    {
    }

    public class PharamacyAnnotation
    {
        [Display(Name = "اسم الصيدلية")]
        [Required(ErrorMessage = "يتطلب ادخال اسم الصيدلية ")]
        public string PharmacyName { get; set; }
        [Display(Name = "عنوان الصيدلية")]
        [Required(ErrorMessage = "يتطلب ادخال عنوان الصيدلية ")]
        public string PharmacyAddress { get; set; }
        [Display(Name = "التليفون")]
        [RegularExpression(@"(01)[0-9]{9}",ErrorMessage = "يتطلب ادخال رقم هاتف صحيح ")]
        [Required(ErrorMessage = "يتطلب ادخال رقم الهاتف ")]
        public string PharmacyPhone { get; set; }
    }
}