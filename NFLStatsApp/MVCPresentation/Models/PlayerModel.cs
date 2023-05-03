using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataObjects;
using System.ComponentModel.DataAnnotations;

namespace MVCPresentation.Models
{
    public class PlayerModel
    {
        public IEnumerable<Players> Players{ get; set; }
        public NameSort NameSort { get; set; }
    }

    public enum NameSort
    {
        [Display(Name = "First Name A-Z")]
        FirstAscending,
        [Display(Name = "First Name Z-A")]
        FirstDecending,
        [Display(Name = "Last Name A-Z")]
        LastAscending,
        [Display(Name = "Last Name Z-A")]
        LastDecending,
    }

}