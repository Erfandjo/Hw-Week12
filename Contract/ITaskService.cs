namespace Hw_Week12.Contract;
using Hw_Week12.Entities;

    public interface ITaskService
    {
        public void Add(string title , DateTime dateTime , int order);
        public void GetAll();
        public Result UpdateState(int id, int state);
        public Result Update(int id , string title , int order , DateTime dateTime);
        public Result Remove(int id);
        public void Search(string str);
    }

