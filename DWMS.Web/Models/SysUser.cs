using System.ComponentModel.DataAnnotations.Schema;

namespace DWMS.Web.Models
{
    [Table("SysUser")]
    public class SysUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}



