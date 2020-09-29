using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DWMS.Domain
{
    public class DataSourceBase
    {
        public int ID { get; set; }
        [DisplayName("数据源类型")]
        public DStype? DStype { get; set; }
        [DisplayName("数据源名称"),MaxLength(200)]
        public string DSName { get; set; }
        [DisplayName("描述")]
        public string DSDesc { get; set; }
        [DisplayName("是否启用Y/N")]
        public string IsActive { get; set; }
    }
    public enum DStype 
    {
        [Description("SQL Server")]
        SQLServer = 1,
        [Description("Excel")]
        Excel = 2,
        [Description("其他")]
        Other = 9
    }

}
