
namespace temperature_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/temperature/{location}", (string location) =>
            {
                var response = new TemperatureResponse
                {
                    Value = Random.Shared.Next(-20, 55),
                    Unit = "C",
                    Timestamp = DateTime.UtcNow,
                    Location = location,
                    Status = "ok",
                    SensorId = Guid.NewGuid().ToString(),
                    SensorType = "temperature",
                    Description = $"Temperature sensor for location {location}"
                };

                return Results.Json(response);
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }

    public class TemperatureResponse
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string SensorId { get; set; }
        public string SensorType { get; set; }
        public string Description { get; set; }
    }
}
