using LoginManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.Process
{
    public class UserFactory
    {
        public static User CreateNew(string userName,string FirstName,string LastName,string Password,bool isActive)
        {
            if(Password is not null && (Password.Length >= 8 ) && Password.Any(char.IsDigit) == true)
            {
                User user = new User();
                user.UserName = userName;
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Password = Password;
                user.IsActive = isActive;
                return user;
            }
            return null;
        }
    }
}
