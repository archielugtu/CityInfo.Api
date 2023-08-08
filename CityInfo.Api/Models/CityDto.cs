namespace CityInfo.Api.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfPointOfInterests
        {
            get
            {
                return PointOfInterest.Count;
            }
        }
        
        // if using ICollection it is important to initialise it with a value to avoid null references.
        public ICollection<PointOfInterestDto> PointOfInterest { get; set; } = new List<PointOfInterestDto>(); 
    }
}
