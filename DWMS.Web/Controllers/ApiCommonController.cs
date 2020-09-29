using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DWMS.Domain;
using DWMS.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DWMS.Web.Controllers
{
  //  [Route("api/[controller]")]
    [ApiController]
    public class ApiCommonController : ControllerBase
    {
        private readonly DefaultContext _context;
        public ApiCommonController(DefaultContext context)
        {
            _context = context;
        }
        private SqlConnection mySqlConnection = null;

      
        [HttpPost("api/tryConn")]
        public IActionResult TryConn(dynamic obj)
        {
            var jsonText = obj.ToString();
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
            string connstr = jo["Conn"].ToString();

            //测试链接
            mySqlConnection = new SqlConnection(connstr);
            string msg = "";
            try
            {
                mySqlConnection.Open();
                if(mySqlConnection.State == ConnectionState.Open)
                {
                    msg = "连接成功";
                }
                else
                {
                    msg = "连接失败";
                }
            }
            catch
            {
                msg = "连接失败";
            }
            finally
            {
                mySqlConnection.Close();
            }
            return Ok(msg);
        }
        [HttpPost("api/saveConn")]
        public IActionResult SaveConn(dynamic obj)
        {
            var jsonText = obj.ToString();
            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
            string connstr = jo["Conn"].ToString();

            //测试链接
            mySqlConnection = new SqlConnection(connstr);
            string msg = "";
            try
            {
                mySqlConnection.Open();
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    msg = "连接成功";
                    //构造函数对象并赋值
                    DSSQLServer ds = new DSSQLServer();

                    ds.DStype = DStype.SQLServer;
                    ds.DSName = jo["dsName"].ToString();
                    ds.DSDesc = jo["dsDesc"].ToString();
                    ds.DBHost = jo["host"].ToString();
                    ds.DBName = jo["database"].ToString();
                    ds.UseId = jo["username"].ToString();
                    ds.Pwd = jo["password"].ToString();
                    ds.IsActive = "Y";
                    _context.DSSQLServers.Add(ds);
                    _context.SaveChanges();

                    msg = msg + "已保存至数据库";
                }
                else
                {
                    msg = "连接失败";
                }
            }
            catch
            {
                msg = "连接失败";
            }
            finally
            {
                mySqlConnection.Close();
            }
            return Ok(msg);
        }
    }
}
