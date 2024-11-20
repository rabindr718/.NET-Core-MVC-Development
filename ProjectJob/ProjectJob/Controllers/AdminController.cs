using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectJob.Data;
using ProjectJob.Models;
using ProjectJob.Models.Entitiy;

namespace ProjectJob.Controllers
{
	public class AdminController : Controller
	{
		private ApplicationDbContext dbContext;
		public AdminController(ApplicationDbContext dbContext)
		{ this.dbContext = dbContext; }
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		//[HttpPost]
		//public async Task<IActionResult> Add(AddAdminViewModel viewModel)
		//{
		//	var admin = new Admin
		//	{
		//		Name = viewModel.Name,
		//		Phone = viewModel.Phone,
		//		Email = viewModel.Email,
		//		Address = viewModel.Address,
		//		IsRole = viewModel.IsRole,
		//	};
		//	await dbContext.Admins.AddAsync(admin); 
		//	await dbContext.SaveChangesAsync();
		//	return View();
		//}
		[HttpPost]
		public async Task<IActionResult> Add(AddAdminViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var admin = new Admin
				{
					Name = viewModel.Name,
					Phone = viewModel.Phone,
					Email = viewModel.Email,
					Address = viewModel.Address,
					IsRole = viewModel.IsRole,  // The selected role (either "Admin" or "User")
				};

				await dbContext.Admins.AddAsync(admin);
				await dbContext.SaveChangesAsync();

				return RedirectToAction("List");  // Redirect to the list of admins after successful submission
			}

			return View(viewModel);  // Return to the same view with validation errors (if any)
		}

		//Displayed

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var admins = await dbContext.Admins.ToListAsync();

			return View(admins);

		}
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			var admin = await dbContext.Admins.FindAsync(id);
			return View(admin);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Admin viewModel)
		{
			var admins = await dbContext.Admins.FindAsync(viewModel.id);
			if (admins is not null)
			{
				admins.Name = viewModel.Name;
				admins.Phone = viewModel.Phone;
				admins.Email = viewModel.Email;
				admins.Address = viewModel.Address;
				admins.IsRole = viewModel.IsRole;
				await dbContext.SaveChangesAsync();

			}
			return RedirectToAction("List", "Admin");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{
			var admin = await dbContext.Admins.FindAsync(id);
			if (admin != null)
			{
				dbContext.Admins.Remove(admin);
				await dbContext.SaveChangesAsync();
			}
			return RedirectToAction("List", "Admin");
		}

	}


}