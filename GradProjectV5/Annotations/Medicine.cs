using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(MedicineAnnotations))]

    public partial class Medicine
    {
    }
    public class MedicineAnnotations
    {
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        [Display(Name="اسم الدواء ")]
        public string MedicineName { get; set; }  



       

        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        [Display(Name="وصف الدواء ")]
        [DataType(DataType.MultilineText)]
        public string MedicineDescription { get; set; }
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]

        [DataType(DataType.Date)]
        [Display(Name="تاريخ انتهاء صلاحية الدواء")]
        public Nullable<System.DateTime> ExpireDate { get; set; }
    }
}