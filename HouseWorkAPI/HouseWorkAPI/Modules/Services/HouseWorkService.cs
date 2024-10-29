using HouseWorkAPI.Enums;
using HouseWorkAPI.Models;
using HouseWorkAPI.Modules.DbContexts;

namespace HouseWorkAPI.Modules.Services
{
    public class HouseWorkService(HouseWorkListDbContext dbContext)
    {
        private HouseWorkListDbContext _dbContext = dbContext;

        public List<Member> Members
        {
            get
            {
                return _dbContext.Members.ToList();
            }
        }

        public Member? GetMember(int id)
        {
            return _dbContext.Members.SingleOrDefault(m => m.Id == id);
        }

        public Member? GetMember(string name)
        {
            return _dbContext.Members.SingleOrDefault(m => m.Name == name);
        }

        public bool AddMember(string name)
        {
            _dbContext.Members.Add(new Member {  Name = name });
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteMember(int id)
        {
            _dbContext.Members.Remove(new Member { Id = id });
            _dbContext.SaveChanges();
            return true;
        }

        public bool ModifyMember(int id, string name)
        {
            var member = _dbContext.Members.Single(m => m.Id == id);
            member.Name = name;
            _dbContext.SaveChanges();
            return true;
        }

        public bool CreateOrModifyWork(Work work)
        {
            if(work.Id is null)
            {
                _dbContext.Works.Add(work);
            }
            else
            {
                _dbContext.Works.Update(work);
            }
            
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteWork(Work work)
        {
            _dbContext.Works.Remove(work);
            _dbContext.SaveChanges();
            return true;
        }

        public List<HouseWork> GetWorks(DateTimeOffset from, DateTimeOffset end)
        {
            var works = _dbContext.HouseWorks.Where(w => w.date <= end && w.date >= from);
            return works.ToList();
        }

        public bool CreateOrModifyHouseWork(HouseWork houseWork)
        {
            if (houseWork.Id is null)
            {
                _dbContext.HouseWorks.Add(houseWork);
            }
            else
            {
                _dbContext.HouseWorks.Update(houseWork);
            }

            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteHouseWork(HouseWork houseWork)
        {
            _dbContext.HouseWorks.Remove(houseWork);
            _dbContext.SaveChanges();
            return true;
        }

        public DailyWork GetDailyWorks() => GetDailyWorks(DateTimeOffset.UtcNow);

        public DailyWork GetDailyWorks(DateTimeOffset now)
        {
            var dailyworks = _dbContext.HouseWorks
                                .Where(w => w.date <= now && w.date > now.AddDays(-1))
                                .Join(_dbContext.Works,
                                    housework => housework.Work,
                                    work => work.Id,
                                    (housework, work) => new { housework, work })
                                .Join(_dbContext.Members,
                                    daily => daily.housework.Owner,
                                    member => member.Id,
                                    (daily, member) => new WorkInfo
                                    {
                                        Owner = member,
                                        Work = daily.work })
                                .Where(work => work.Work.Frequence == WorkFreqenseEnum.Daily.ToString())
                                .ToList();

            return new DailyWork() { Works = dailyworks, date = now.Date};
        }

        public WeeklyWork GetWeeklyWork() => GetWeeklyWork(DateTimeOffset.UtcNow);

        public WeeklyWork GetWeeklyWork(DateTimeOffset now)
        {
            var date = now.DayOfWeek switch
            {
                DayOfWeek.Monday => now.AddDays(-1),
                DayOfWeek.Tuesday => now.AddDays(-2),
                DayOfWeek.Wednesday => now.AddDays(-3),
                DayOfWeek.Thursday => now.AddDays(-4),
                DayOfWeek.Friday => now.AddDays(-5),
                DayOfWeek.Saturday => now.AddDays(-6),
                _ => now,
            };

            var weeklyworks = _dbContext.HouseWorks
                                .Where(w => w.date == date)
                                .Join(_dbContext.Works,
                                    housework => housework.Work,
                                    work => work.Id,
                                    (housework, work) => new { housework, work })
                                .Join(_dbContext.Members,
                                    daily => daily.housework.Owner,
                                    member => member.Id,
                                    (daily, member) => new WorkInfo
                                    {
                                        Owner = member,
                                        Work = daily.work
                                    })
                                .Where(work => work.Work.Frequence == WorkFreqenseEnum.Weekly.ToString())
                                .ToList();

            return new WeeklyWork() { Works = weeklyworks, date = date};
        }

        public MonthlyWork GetMonthlyWork() => GetMonthlyWork(DateTimeOffset.UtcNow);

        public MonthlyWork GetMonthlyWork(DateTimeOffset now)
        {
            var monthlyworks = _dbContext.HouseWorks
                                .Where(w => w.date.Month == now.Month &&
                                            w.date.Year == now.Year)
                                .Join(_dbContext.Works,
                                    housework => housework.Work,
                                    work => work.Id,
                                    (housework, work) => new { housework, work })
                                .Join(_dbContext.Members,
                                    daily => daily.housework.Owner,
                                    member => member.Id,
                                    (daily, member) => new WorkInfo
                                    {
                                        Owner = member,
                                        Work = daily.work
                                    })
                                .Where(work => work.Work.Frequence == WorkFreqenseEnum.Monthly.ToString())
                                .ToList();

            return new MonthlyWork() { Works = monthlyworks, date = now };
        }
    }
}
