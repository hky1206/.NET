using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	public class DanhMucSanPhamViewComponent : ViewComponent
	{
		private readonly DoanmonhocContext _context;

		public DanhMucSanPhamViewComponent(DoanmonhocContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var danhMucs = await _context.DanhMucSanPhams.ToListAsync();
			return View(danhMucs);
		}
	}
}
