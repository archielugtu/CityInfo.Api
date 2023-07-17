using CityInfo.Api.Models;

namespace CityInfo.Api
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore(); 

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Manila",
                    Description = "Very busy and dirty."
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Nara",
                    Description = "They have yummy Mochi!"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Christchurch",
                    Description = "Good old Christchurch"
                },
            };
        }
    }
}
