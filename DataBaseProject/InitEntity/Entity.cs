using DataBaseProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataBaseProject.InitEntity
{
    public class Entity
    {
        public bool Initialize()
        {
            using (var db = new ExerciseDbContext())
            {
                try
                {

                    if (!db.Database.EnsureCreated())
                        Console.WriteLine($"{DateTime.Now} || " +
                            $"WARNING: Cant create map table to database. Possible App structure database schema exist.");
                    else
                        Console.WriteLine($"{DateTime.Now} || INFO: Success mapping table to database.");

                    db.Database.Migrate();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: Some problem when mapping entity.");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    return false;
                }
            }
        }
    }
}
