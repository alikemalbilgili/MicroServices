
using CommandsService.Models;
using CommandsService.SyncDataServices;

namespace CommandsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                var grpcClient = servicesScope.ServiceProvider.GetService<IPlatformDataClient>();
                var platforms = grpcClient.ReturnAllPlatforms();
                SeedData(servicesScope.ServiceProvider.GetService<ICommandRepo>(), platforms);
            }
        }
        private static void SeedData(ICommandRepo commandRepo, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("Seeding new platforms...");

            foreach (var plat in platforms)
            {
                if (!commandRepo.ExternalPlatformExists(plat.ExternalId))
                {
                    commandRepo.CreatePlatform(plat);
                }

                commandRepo.SaveChanges();
            }

        }
    }
}