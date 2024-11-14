using Hw_Week12.Enum;

namespace Hw_Week12.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeToDone { get; set; }
        public int Order { get; set; }
        public StateEnum State { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}
