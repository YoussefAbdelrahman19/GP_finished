using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(PharmacyMedicineRequestAnnotations))]
    public partial class PharmacyMedicineRequest
    {
    }
    public  class PharmacyMedicineRequestAnnotations
    {
        [Required]
        [Display(Name ="الكمية")]
      
        public string RequestedAmount { get; set; }

    }

}