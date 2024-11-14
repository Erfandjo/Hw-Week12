using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hw_Week12.Entities;

namespace Hw_Week12.Contract
{
    public interface ITaskRepository
    {
        public void Add(Entities.Task task);
        public List<Entities.Task> GetAll();
        public Result Remove(int id);
        public Result UpdateState(int id , int state);
        public Result Update(int id, string title, int order, DateTime dateTime);
        public List<Entities.Task> Search(string str);
    }
}
