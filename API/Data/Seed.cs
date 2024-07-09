using API.Entities;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { Id = Guid.NewGuid(), Name = "HR", CreationTime = DateTime.UtcNow },
                    new Department { Id = Guid.NewGuid(), Name = "IT", CreationTime = DateTime.UtcNow },
                    new Department { Id = Guid.NewGuid(), Name = "Finance", CreationTime = DateTime.UtcNow }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}