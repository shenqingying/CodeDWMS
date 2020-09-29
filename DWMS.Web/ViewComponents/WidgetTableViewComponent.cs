using DWMS.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace DWMS.Web.ViewComponents
{
    public class WidgetTableViewComponent:ViewComponent
    {
        private readonly DefaultContext context;
        public WidgetTableViewComponent(DefaultContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// 调用 VC: 返回 data table
        /// </summary>
        /// <param name="connStr">要查询表所在数据库的连接字符串</param>
        /// <param name="tbName">要查询的表名</param>
        /// <returns></returns>
        public IViewComponentResult Invoke(string connStr,string tbName)
        {
            DataTable DT;
            string curTb = Request.Query["curTb"].ToString();
            if (!string.IsNullOrEmpty(curTb)) 
            {
                SQLHelper sQLHelper = new SQLHelper(connStr);
                string sql = "SELECT TOP 5 * FROM " + curTb + " WHERE 1 = @test";
                SqlParameter[] paras = new SqlParameter[] { 
                    //说明数据库表名比较特殊不能直接作为参数

                    new SqlParameter("@test",1)
                };
                DT =  sQLHelper.ExecuteReader(sql,CommandType.Text,paras);

                //返回的数据类型是DataTable，所以第一行是标题，其他行都是数据

                ViewBag.jsonRes = JsonConvert.SerializeObject(DT);
            }
            return View();
        }
    }
}
