using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.ViewModels.CaseViewMode
{
    public class CreateCaseViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string CaseType { get; set; }

        [Required]
        public int LocationId { get; set; } // ذخیره LocationId انتخاب‌شده

        public IEnumerable<SelectListItem> Locations { get; set; } // لیست موقعیت‌ها

        public string UserId { get; set; } // شناسه کاربر
    }
}


