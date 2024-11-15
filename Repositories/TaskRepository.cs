using Hw_Week12.Contract;
using Hw_Week12.Entities;
using System.Threading.Tasks;

namespace Hw_Week12.Repositories
{
    public class TaskRepository : ITaskRepository
    {
      private readonly AppDbContext _appDbContext;

        public TaskRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public void Add(Entities.Task task)
        {
            _appDbContext.Tasks.Add(task);
            _appDbContext.SaveChanges();
        }

        public List<Entities.Task> GetAll()
        {
           var tasks =_appDbContext.Tasks.OrderBy(t=>t.TimeToDone).Where(t => t.user == OnlineUser.CurrentUser).ToList();
            return tasks;
        }

        public Result Remove(int id)
        {
            var task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == OnlineUser.CurrentUser.Id);
            if(task is not null)
            {
                _appDbContext.Tasks.Remove(task);
                _appDbContext.SaveChanges();
                return new Result(true , "Success");
            }   
            return new Result(false , "Not Accses");
        }

        public List<Entities.Task> Search(string str)
        {
            var tasks = _appDbContext.Tasks.Where(t => t.Title.Contains(str) && t.user == OnlineUser.CurrentUser).ToList();
            return tasks;
        }

        public Result Update(int id, string title, int order, DateTime dateTime)
        {
            var task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == OnlineUser.CurrentUser.Id);
            if (task is not null)
            {
                task.Order = order;
                task.Title = title;
                task.TimeToDone = dateTime;
                _appDbContext.SaveChanges();
                return new Result(true , "Success");
            } 
                return new Result(false, "Not Accses");
            
        }

        public Result UpdateState(int id, int state)
        {
            var task = _appDbContext.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == OnlineUser.CurrentUser.Id);
            if (task is not null)
            {
                task.State = (Enum.StateEnum)state;
                _appDbContext.SaveChanges();
                return new Result(true , "Success");
            }
            return new Result(false, "Not Accses");
        }

       
    }
}
