using FLEXISOURCETEST.Models;
using Microsoft.EntityFrameworkCore;

namespace FLEXISOURCETEST.Services.UserService
{
    public class UserService : IUserService
    {
        protected _flexiContext _context { get; set; }
        public UserService(_flexiContext context) 
        { 
            _context = context;
        }
        public async Task<List<UserProfile>> GetAllProfile()
        {
            var list = await _context.UserProfiles.ToListAsync();

            List<UserProfile> result = new List<UserProfile>();
            foreach (var item in list)
            {
                var runactlist = _context.RunningActivities.Where(a => a.UserId == item.Id).ToList();
                item.RunningActivities = runactlist;
                result.Add(item);

            }

            return result;
        }

        public async Task<UserProfile> Post(UserProfile e)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var item = new UserProfile()
                {
                    Name = e.Name,
                    Weight = e.Weight,
                    Height = e.Height,
                    BirthDate = e.BirthDate,
                };

                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
                trans.Commit();
                return item;
            }catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }

        public async Task<UserProfile> Put(int Id, UserProfile e)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var item = _context.UserProfiles.Find(Id);
                
                item!.Name = e.Name;
                item.Weight = e.Weight;
                item.Height = e.Height;
                item.BirthDate = e.BirthDate;
         
                await _context.SaveChangesAsync();
                trans.Commit();

                UserProfile profile = await GetUser(Id);

                return profile;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }

        public async Task<UserProfile> GetUser(int Id)
        {
            try
            {
                var item = _context.UserProfiles.Find(Id);
                UserProfile profile = item;
                var runactlist = _context.RunningActivities.Where(a => a.UserId == Id).ToList();
                profile.RunningActivities = runactlist;

                return profile;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
