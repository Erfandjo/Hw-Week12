namespace Hw_Week12.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Task> Tasks { get; set; }


        public Result SetPassword(string password)
        {
            if (password.Length >= 3)
            {
                Password = password;
                return new Result(true);
            }
            return new Result(false, "Password Must Be More Than 3 Characters");
        }

       
    }
}
