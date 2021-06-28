using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models

{
    [MetadataType(typeof(BeneficierMedicineRequestAnnotations))]

    public partial class BeneficierMedicineRequest
    {
    }

    public class BeneficierMedicineRequestAnnotations
    {
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        [Display(Name = "كمية الدواء المطلوبة")]
        public string RequestedAmount { get; set; }

        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل")]
        public string RespondedAmount { get; set; }
    }
}