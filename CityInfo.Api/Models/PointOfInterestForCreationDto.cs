namespace CityInfo.Api.Models
{
    // DTO for creating PointOfInterest. 
    // Rule of thumb: Use separate DTOs for creating, updating, and deleting resources
    public class PointOfInterestForCreationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } 
    }
}
