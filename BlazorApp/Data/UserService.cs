
namespace BlazorApp.Data
{
    public class UserService
    {
        public Dictionary<string, string> Users = new Dictionary<string, string>();
        public void Add(string connectionId, string username)
        {
            Users.Add(connectionId, username);
        }
        public void RemoveByName(string username)
        {
            var x = Users.First(x => x.Value == username);
            Users.Remove(x.Key);
        }
        public string GetConnectionIdByName(string username)
        {
            string name = "";
            foreach (var u in Users)
            {
                if (u.Value == username)
                    name = u.Key;
            }
            return name;
        }
        public Dictionary<string, string> GetAll()
        {
            return Users;
        }
    }
}