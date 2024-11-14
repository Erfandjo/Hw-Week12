using Hw_Week12.Contract;
using Hw_Week12.Enum;
using Hw_Week12.Repositories;
using Hw_Week12.Entities;

namespace Hw_Week12.Service
{
    public class TaskService : ITaskService
    {
        ITaskRepository Repo;

        public TaskService()
        {
            Repo = new TaskRepository();
        }
        public void Add(string title, DateTime dateTime, int order)
        {
            var task = new Entities.Task()
            {
                Title = title,
                TimeToDone = dateTime,
                Order = order,
                State = Enum.StateEnum.InPending,
                UserId = OnlineUser.CurrentUser.Id
            };
            Repo.Add(task);
        }

        public void GetAll()
        {
            foreach (var task in Repo.GetAll())
            {
                Console.WriteLine($"Id : {task.Id} , Title : {task.Title} , Time To Done : {task.TimeToDone} , Order : {task.Order} , State : {(StateEnum) task.State}");
            }
        }

        public Result Remove(int id)
        {
           return Repo.Remove(id);

        }

        public void Search(string str)
        {
            var tasks = Repo.Search(str);
            foreach (var task in tasks)
            {
                Console.WriteLine($"Id : {task.Id} , Title : {task.Title} , Time To Done : {task.TimeToDone} , Order : {task.Order} , State : {(StateEnum)task.State}");
            }

        }

        public Result Update(int id, string title, int order, DateTime dateTime)
        {
           return Repo.Update(id, title, order, dateTime);
        }

        public Result UpdateState(int id, int state)
        {
           return Repo.UpdateState(id , state);
        }

    }
}
