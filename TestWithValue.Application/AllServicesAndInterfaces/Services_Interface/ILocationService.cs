using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Application.AllServicesAndInterfaces.Services_Interface
{
    public interface ILocationService
    {
        Task<IEnumerable<SelectListItem>> GetLocationsForDropdownAsync();
    }
}
