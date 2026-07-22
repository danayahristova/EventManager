using EventManager.Data.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace EventManager.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            string json = File.ReadAllText(Path.Combine("Data", "DataSets", "categories.json"));
            var entities = JsonSerializer.Deserialize<List<Category>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true}); 
            
            if(!entities.IsNullOrEmpty())
            {
                builder.HasData(entities);

            }
            

        }
    }
}
