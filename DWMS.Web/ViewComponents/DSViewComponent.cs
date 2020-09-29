using DWMS.Domain;
using DWMS.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DWMS.Web.ViewComponents
{
    public class DSViewComponent: ViewComponent
    {
        private readonly DefaultContext db;
        public DSViewComponent(DefaultContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return  View(items);
        }
        private Task<List<DSSQLServer>> GetItemsAsync()
        {
            return db.DSSQLServers.ToListAsync();
        }
    }
}
