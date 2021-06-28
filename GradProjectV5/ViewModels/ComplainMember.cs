using GradProjectV5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradProjectV5.ViewModels
{
    public class ComplainMember
    {
        public Member Member { get; set; }
        public Complaint Complaint { get; set; }
        public Gender Gender { get; set; }
    }
}