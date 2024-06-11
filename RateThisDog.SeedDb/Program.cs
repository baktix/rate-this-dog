using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RateThisDog.Data;
using RateThisDog.Data.Dto;

using AppDbContext context = new(
    new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite("DataSource=/home/nistrum/dev/rate-this-dog/sqlite/RateThisDog.db")
    .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Information)
    .EnableDetailedErrors(true)
    .EnableSensitiveDataLogging(true)
    .Options
    );

DirectoryInfo root = new("/home/nistrum/dev/rate-this-dog/source-images/");
const string destFolder = "/home/nistrum/dev/rate-this-dog/web/public/dog/";

await context.UserRatings.ExecuteDeleteAsync();
await context.Dogs.ExecuteDeleteAsync();

Random r = new Random(Environment.TickCount);

foreach (FileInfo fi in root.GetFiles("*.jpg"))
{
    Console.WriteLine(fi.FullName);

    string destFile = Path.Combine(destFolder, fi.Name);

    File.Copy(fi.FullName, destFile, true);

    double randomRating = r.NextDouble() * 5;

    Dog newDog = new()
    {
        FileName = $"dog/{fi.Name}",
        UserRatings = new List<UserRating> {
            new UserRating() { Rating = randomRating }
        }
    };

    context.Dogs.Add(newDog);
}

await context.SaveChangesAsync();

Console.WriteLine("Done");
Console.ReadKey();