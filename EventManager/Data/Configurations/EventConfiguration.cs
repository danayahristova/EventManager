using EventManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
namespace EventManager.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            string json = File.ReadAllText(Path.Combine("Data", "DataSets", "events.json"));
            List<Event> entities = JsonSerializer.Deserialize<List<Event>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (!entities.IsNullOrEmpty())
            {
                builder.HasData(entities);
            }
        }
    }
}
