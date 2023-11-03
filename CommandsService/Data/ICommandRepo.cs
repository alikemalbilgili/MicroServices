using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        void CreatePlatform(Platform plat);
        bool PlatformExists(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);


        IEnumerable<Platform> GetAllPlatforms();
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommandById(int id);
        void CreateCommand(int platformId, Command cmd);
    }
}