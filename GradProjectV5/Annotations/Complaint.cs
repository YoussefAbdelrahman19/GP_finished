using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(ComplaintAnnotations))]
    public partial class Complaint
    {
    }
    public class ComplaintAnnotations
    {
        [Display(Name ="الوصف ")]
        [Required(ErrorMessage = "يتطلب ادخال السؤال ")]
        [DataType(DataType.MultilineText)]

        public string ComplaintDescription { get; set; }
        [Display(Name = "التاريخ ")]
        [Required(ErrorMessage = "يتطلب ادخال التاريخ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ComplainDate { get; set; }

    }
}