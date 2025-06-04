using AppBackend.Entities;
namespace AppBackend.UseCases;

public interface IWeatherService
{
    public IEnumerable<WeatherForecast> GetForecast();
}
