using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DWMS.Web.Controllers
{
    /// <summary>
    /// 放文档类的帮助性文件
    /// </summary>
    public class DocsController : Controller
    {

        public IActionResult Roadmap()
        {
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
