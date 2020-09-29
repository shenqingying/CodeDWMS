using System.Linq;
using DWMS.Domain;
using DWMS.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace DWMS.Web.Controllers
{
    /// <summary>
    /// 数据仓库管理，包括菜单：数据源、数据源预览、SQL模型、数据值映射
    /// </summary>
    public class DWController : Controller
    {

        private readonly DefaultContext _context;
    //    private SqlConnection sqlConnection = null;
        public DWController(DefaultContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SONLUK()
        {
            return View();
        }


        // TODO 菜单：数据表预览
        public IActionResult DBPreview()
        {
            // 前置条件：获取一个测试的数据源的 数据源类别 和 id（先指定好用于测试）
            DStype dSType = DStype.SQLServer;

            //1、页面加载时接收一个DataSourceBase类型的对象，通过此对象获取 数据源名称 和 数据源类别。
            DataSourceBase ds = new DataSourceBase();
            if (dSType == DStype.SQLServer)
            {
                //2、前端根据 数据源类别 和 数据源名称 动态查询，获取相关连接字符串。
                ds = _context.DSSQLServers.FirstOrDefault(x => x.ID == 4);

            }

            ViewBag.Context = _context;
            return View(ds);
        }

        // TODO 菜单：SQL模型
        public IActionResult SQLModel()
        {
            return View();
        }

        // TODO 菜单：数据值映射
        public IActionResult ValueRename()
        {
            return View();
        }
    }
}
