using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.RequestModels
{
    public class TweetRequestModel
    {
        [Required]
        [StringLength(240)]
        public string Message { get; set; }    
    }
}
