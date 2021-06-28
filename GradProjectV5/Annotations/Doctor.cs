using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(DoctorAnnotations))]
    public partial class Doctor
    {
    }

    public class DoctorAnnotations
    {
        //public int Id { get; set; }
        //public string Speciality { get; set; }
        //public Nullable<int> YearsOfExperience { get; set; }
        //public Nullable<int> Age { get; set; }
        //public Nullable<bool> IsDeleted { get; set; }
        //public Nullable<int> MemberId { get; set; }
    }
}