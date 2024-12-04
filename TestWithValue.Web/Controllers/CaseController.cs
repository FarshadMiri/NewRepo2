using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestWithValue.Application.AllServicesAndInterfaces.Services;
using TestWithValue.Application.AllServicesAndInterfaces.Services_Interface;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.CaseViewMode;

namespace TestWithValue.Web.Controllers
{
    public class CaseController : Controller
    {
        private readonly ICaseService _caseService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILocationService _locationService;



        public CaseController(ICaseService caseService, UserManager<IdentityUser >userManager, ILocationService locationService
           )
        {
            _caseService = caseService;
            _userManager = userManager;
             _locationService = locationService;    
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateCaseViewModel
            {
                Locations = await _locationService.GetLocationsForDropdownAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Locations = await _locationService.GetLocationsForDropdownAsync(); // بازگرداندن Dropdown در صورت خطا
                return View(model);
            }

            var userId = _userManager.GetUserId(User);
            var newCase = new Tbl_Case
            {
                Title = model.Title,
                CaseType = model.CaseType,
                LocationId = model.LocationId,
                IsDone = false,
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now),
                UserId = userId
            };

            await _caseService.AddCaseAsync(newCase); // فرض بر اینکه سرویس پرونده دارید
            TempData["SuccessMessage"] = "پرونده با موفقیت ثبت شد.";
            return RedirectToAction("UserCases", new { userId });
        }

        [HttpGet]
        public async Task<IActionResult> UserCases()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is required.");
            }

            var cases = await _caseService.GetCasesByUserIdAsync(userId);
            return View(cases); // ارسال لیست پرونده‌ها به ویو
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
