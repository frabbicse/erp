using Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Auth
{
    public class Register : UtilityBase
    {
        [Required]
        public string UserName { get; set; }
        //[Required]
        //public string UserId { get; set; }
        [Required]
        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string EmailId { get; set; }
    }
}
