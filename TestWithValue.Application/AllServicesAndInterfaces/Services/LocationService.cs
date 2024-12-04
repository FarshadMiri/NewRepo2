using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.AllServicesAndInterfaces.Services_Interface;
using TestWithValue.Application.Contract.Persistence;

namespace TestWithValue.Application.AllServicesAndInterfaces.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsForDropdownAsync()
        {
            var locations = await _locationRepository.GetAllLocationsAsync();
            return locations.Select(l => new SelectListItem
            {
                Value = l.LocationId.ToString(),
                Text = l.Name
            }).ToList();
        }
    }
}
