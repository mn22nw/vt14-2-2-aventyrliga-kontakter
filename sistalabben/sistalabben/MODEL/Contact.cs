using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sistalabben.MODEL
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "En emailadress måste anges")]
        [RegularExpression(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(50)]
        public string LastName { get; set; }

    }
}