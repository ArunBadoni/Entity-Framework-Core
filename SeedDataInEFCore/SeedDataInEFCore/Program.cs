using SeedDataInEFCore.Entities;

namespace SeedDataInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EFCoreDbContext();
            var countries=context.CountryMaster.ToList();
            Console.WriteLine("-------------Countries Details-------------");
            foreach (var country in countries)
            {
                Console.WriteLine($"CountryId: {country.CountryId}\nCountryName:{country.CountryName}\nCountryCode:{country.CountryCode}");
            }
            var states = context.StateMaster.ToList();

            Console.WriteLine("-------------State Details-------------");
            foreach (var state in states)
            {
                Console.WriteLine($"StateId: {state.StateId}\nStateName:{state.StateName}\nCountryId:{state.CountryId}");
            }
            var cities = context.CityMaster.ToList();

            Console.WriteLine("-------------City Details-------------");
            foreach (var city in cities)
            {
                Console.WriteLine($"CityId: {city.CityId}\nCityName:{city.CityName}\nStateId:{city.StateId}");
            }
        }
    }
}
