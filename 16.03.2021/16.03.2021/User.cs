using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace _16._03._2021
{
    class User
    {
        public readonly string username;
        public readonly string email;

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public void SaveToJson()
        {
            string newJson = "";
            using (StreamReader r = new StreamReader("users.json"))
            {
                string json = r.ReadToEnd();
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                if (users == null) users = new List<User>();
                users.Add(this);
                newJson = JsonConvert.SerializeObject(users);
            }
            File.WriteAllText("users.json", newJson);
        }
    }
}
