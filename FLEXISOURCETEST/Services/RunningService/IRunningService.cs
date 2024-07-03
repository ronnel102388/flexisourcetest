using FLEXISOURCETEST.Models;

namespace FLEXISOURCETEST.Services.RunningService
{
    public interface IRunningService
    {
        Task<UserProfile> PostRunning(int Id, RunningActivity e);
    }
}
