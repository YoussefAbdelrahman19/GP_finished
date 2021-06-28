using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(ConsultAnnotations))]

    public partial class Consult
    {
    }

    public class ConsultAnnotations
    {
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        [Display(Name ="عنوان الإستشارة")]
        public string ConsultQuestionTitle { get; set; }


        [Display(Name = "تفاصيل الإستشارة")]
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        [DataType(DataType.MultilineText)]

        public string ConsultQuestionName { get; set; }
    }
}