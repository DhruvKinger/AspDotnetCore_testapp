using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCity.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog posts" };
        }
        [Route("blogs/{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult post(int year,int month,string key)
        {
            return new ContentResult {Content=string.Format(
                "Year :{0};Month :{1};key :{2}",year,month,key
                )
            };
        }
    }
}