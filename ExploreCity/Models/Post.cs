using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExploreCity.Models
{
    public class Post
    {
        public long id { get; set; }
        private string _key;
        public string Key
        {
            get
            {
                if(_key==null)
                {

                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }


        [Required]
    [Display(Name ="Post title")]
    [StringLength(100,MinimumLength =5,ErrorMessage ="Title should be between 5 and 100 characters ")]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "Body should be of 20 minimum  Charcters")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public DateTime Posted { get; set; }
    }
}
