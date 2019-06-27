namespace SehirRehberi.API.Dtos
{
    public class CityForListDto : BaseDto
    {
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
    }
}
