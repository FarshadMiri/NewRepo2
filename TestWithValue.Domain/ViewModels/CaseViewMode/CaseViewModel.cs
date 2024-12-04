using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.ViewModels.CaseViewMode
{
    public class CaseViewModel
    {
        public int CaseId { get; set; }
        public string Title { get; set; }
        public string CaseType { get; set; }
        public bool IsDone { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string UserName { get; set; } // نام کاربر
    }

}
