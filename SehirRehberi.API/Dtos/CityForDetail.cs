using System.Collections.Generic;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Dtos
{
    public class CityForDetailDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
