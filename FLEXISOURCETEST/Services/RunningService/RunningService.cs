using FLEXISOURCETEST.Models;
using FLEXISOURCETEST.Services.UserService;

namespace FLEXISOURCETEST.Services.RunningService
{
    public class RunningService : IRunningService
    {
        protected _flexiContext _context { get; set; }
        private readonly IUserService _userService;
        public RunningService(_flexiContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<UserProfile> PostRunning(int UserId, RunningActivity e)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var user = _context.UserProfiles.Find(UserId);
                var item = new RunningActivity()
                {
                    UserId = UserId,
                    Location = e.Location,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    DistanceKm = e.DistanceKm

                };

                await _context.RunningActivities.AddAsync(item);
                await _context.SaveChangesAsync();
                trans.Commit();

                var finduser = await _userService.GetUser(UserId);
                Console.WriteLine(finduser.RunningActivities!.Count + " Running activities is listed for User : " + finduser.Name + "!");
                return finduser!;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
