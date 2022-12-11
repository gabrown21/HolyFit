namespace HolyFit.Data
{
    public interface IWeatherForecast
    {
        DateOnly Date { get; set; }
        string? Summary { get; set; }
        int TemperatureC { get; set; }
        int TemperatureF { get; }
    }
}