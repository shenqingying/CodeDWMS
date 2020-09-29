using DWMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWMS.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DefaultContext context)
        {
            context.Database.EnsureCreated();
          
            if (context.SysUsers.Any())
            {
                return; // 有数据就不插入了
            }

            var users = new SysUser[]
            {
                new SysUser{Name="Bob"},
                new SysUser{Name="Buu"}
            };

            foreach (SysUser u in users)
            {
                context.SysUsers.Add(u);
            }
            context.SaveChanges();
        }
    }
}
