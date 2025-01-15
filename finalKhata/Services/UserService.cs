using finalKhata.Configs;
using finalKhata.Models;
using System.Text.Json;


namespace finalKhata.Services
{
    internal class UserService
    {
        public static UserModel User { get; set; }
        public  string UserFilePath = FolderAndFiles.UserFilePath;


        public void GetUser()
        {
            string json = File.ReadAllText(UserFilePath);
            User = JsonSerializer.Deserialize<UserModel>(json);
            
        }

        public void RegisterUser(UserModel user)
        {
            string json = JsonSerializer.Serialize(user);
            File.WriteAllText(UserFilePath, json);
            FolderAndFiles.IsFirstStart = false;
            User = user;
        }

        public void SaveUserData()
        {
            string json = JsonSerializer.Serialize(User);
            File.WriteAllText(UserFilePath, json);

        }
    }
}
