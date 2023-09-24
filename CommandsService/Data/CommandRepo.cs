using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateCommand(int platformId, Command cmd)
        {
            if (cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }

            cmd.PlatformId = platformId;
            _context.Commands.Add(cmd);
        }

        public void CreatePlatform(Platform plat)
        {
            if (plat == null)
            {
                throw new System.ArgumentNullException(nameof(plat));
            }

            _context.Platforms.Add(plat);
        }

        public IEnumerable<Models.Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Models.Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id) ?? new Models.Command();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(p => p.PlatformId == platformId).OrderBy(p => p.Platform.Name).ToList();
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}