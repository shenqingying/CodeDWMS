using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DWMS.Domain
{
     /// <summary>
     /// SQL Server数据源连接字符串配置
     /// </summary>
   [Table("DSSQLServer")]
    public class DSSQLServer : DataSourceBase
    {
        [DisplayName("数据库地址")]
        public string DBHost { get; set; }
        [DisplayName("数据库名"), Required]
        public string DBName { get; set; }
        [DisplayName("用户名"), Required]
        public string UseId { get; set; }
        [DisplayName("密码"), Required]
        public string Pwd { get; set; }
    }
}
