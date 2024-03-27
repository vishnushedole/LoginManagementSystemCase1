using LoginManagement.Process;
using System;

namespace LoginManagement.UI
{
    public class Program
    {
        public static Userprocess Up = new Userprocess();
        public static RoleProcess Rp = new RoleProcess();
        public static void PrintMainMenu()
        {
            Console.WriteLine("***** Login Management System ******");
            Console.WriteLine("*** 1. Manage Users");
            Console.WriteLine("*** 2. Manage Roles");
            Console.WriteLine("*** 3. Manage User Roles");
            Console.WriteLine("***");
            Console.WriteLine("***");
            Console.WriteLine("*** 0. Quit");
            Console.WriteLine("*******************");
            Console.WriteLine("Your Choice:");
        }
        public static void ManageUser()
        {
            int choice = -1;
            while(choice != 0)
            {

            Console.WriteLine("*****Login Management System ******");
            Console.WriteLine("*****Manage Users ******");
            Console.WriteLine("***1.List all Users");
            Console.WriteLine("***2.Find User By Id");
            Console.WriteLine("***3.Add new User");
            Console.WriteLine("***4.Update User Details");
            Console.WriteLine("***5.Remove User");
            Console.WriteLine("***");
            Console.WriteLine("***");
            Console.WriteLine("***0.Back to Main Menu");
            Console.WriteLine("*******************");

                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(choice)
                {
                    case 1:
                        try
                        {

                        ListAllUsers();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 2:
                        try
                        {

                        FindUserById();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        try
                        {

                        AddUser();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;
                    case 4:
                        try
                        {

                        UpdateUser();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 5:
                        try
                        {

                        RemoveUser();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RemoveUser()
        {
            Console.WriteLine("Enter User ID:");
            int id = int.Parse(Console.ReadLine());
            Up.RemoveUser(id);
            Console.WriteLine("User Removed");
        }

        private static void UpdateUser()
        {
            Console.Write("Enter User Id:");
            int id = int.Parse(Console.ReadLine());
            var user = Up.GetUserById(id);
            if(user is not null)
            {

            Console.WriteLine($"Enter User Name({user.UserName}): ");
            string name = Console.ReadLine();
            Console.WriteLine($"Enter First Name({user.FirstName}): ");
            string firstName = Console.ReadLine();
            Console.WriteLine($"Enter Last Name({user.LastName}): ");
            string lastName = Console.ReadLine();
            //Console.WriteLine("Enter Password: ");
            //string password = Console.ReadLine();
            Console.Clear();
            Up.UpdateUser(user.UserId,name, firstName, lastName, user.Password);
            }
            Console.WriteLine("User Updated");
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter User Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.Clear();
            Up.AddUser(name,firstName, lastName, password);
            Console.WriteLine("User Added");
        }

        private static void FindUserById()
        {
            Console.WriteLine("Enter User Id:");
            int id = int.Parse(Console.ReadLine());
            var user = Up.GetUserById(id);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(user.UserId);
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.LastName);
            Console.WriteLine(user.IsActive);
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static void ListAllUsers()
        {
            
            var Users = Up.GetAllUsers();
            foreach ( var user in Users )
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(user.UserId);
                Console.WriteLine(user.UserName);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
                Console.WriteLine(user.IsActive);
                Console.ResetColor();
                Console.WriteLine("-------------------------------------");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void ManageRoles()
        {
            int choice = -1;
            while (choice != 0)
            {

                Console.WriteLine("*****Login Management System ******");
                Console.WriteLine("*****Manage Roles ******");
                Console.WriteLine("***1.List all Roles");
                Console.WriteLine("***2.Find Role By Id");
                Console.WriteLine("***3.Add new Role");
                Console.WriteLine("***4.Update Role Details");
                Console.WriteLine("***5.Remove Role");
                Console.WriteLine("***");
                Console.WriteLine("***");
                Console.WriteLine("***0.Back to Main Menu");
                Console.WriteLine("*******************");

                choice = int.Parse(Console.ReadLine());
                Console.Clear();

                try
                {

                switch (choice)
                {
                    case 1:
                        ListAllRoles();
                        break;
                    case 2:
                        FindRoleById();
                        break;
                    case 3:
                        AddRole();
                        break;
                    case 4:
                        UpdateRole();
                        break;
                    case 5:
                        RemoveRole();
                        break;
                    default:
                        break;
                }
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

        private static void RemoveRole()
        {
            Console.WriteLine("Enter Role ID:");
            int id = int.Parse(Console.ReadLine());
            Rp.RemoveRole(id);
            Console.WriteLine("Role Removed");
        }

        private static void UpdateRole()
        {
            Console.Write("Enter Role Id:");
            int id = int.Parse(Console.ReadLine());
            var role = Rp.GetRoleById(id);
            if (role is not null)
            {

                Console.WriteLine($"Enter Role Name({role.RoleName}): ");
                string name = Console.ReadLine();
                Console.WriteLine($"Enter Role Discription({role.Description}): ");
                string discription = Console.ReadLine();
                Console.WriteLine($"IsActive ({role.IsActive}): ");
               
                
                Console.Clear();
                Rp.UpdateRole(id,name, discription);
            }
            Console.WriteLine("Role Updated");
        }

        private static void AddRole()
        {

            Console.WriteLine("Enter Role Name: ");
            string role = Console.ReadLine();
            Console.WriteLine("Enter Role Discription: ");
            string discription = Console.ReadLine();
            
            Console.Clear();
            Rp.AddRole(role,discription);
            Console.WriteLine("Role Added");
        }

        private static void FindRoleById()
        {
            Console.WriteLine("Enter Role Id:");
            int id = int.Parse(Console.ReadLine());
            var role = Rp.GetRoleById(id);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(role.RoleId);
            Console.WriteLine(role.RoleName);
            Console.WriteLine(role.Description);
            Console.WriteLine(role.IsActive);
 
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static void ListAllRoles()
        {
            var Roles = Rp.GetAllRoles();
            foreach (var role in Roles)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(role.RoleId);
                Console.WriteLine(role.RoleName);
                Console.WriteLine(role.Description);
                Console.WriteLine(role.IsActive);
                Console.ResetColor();
                Console.WriteLine("-------------------------------------");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void ManageUserRoles()
        {
            int choice = -1;
 
            while(choice != 0)
            {

            Console.WriteLine("***** Login Management System ******");
            Console.WriteLine("***** Manage User Roles ******");
            Console.WriteLine("1.Update User Role");
            Console.WriteLine("2.Find Role by User Id");
                Console.WriteLine("0.Exit ");

                choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                        UpdateUserRole();
                        break;
                    case 2:
                        FindRoleByUserId();
                        break;
                    default:
                        break;

            }
           
            }
        }

        private static void FindRoleByUserId()
        {
            int id;
            Console.WriteLine("Enter User Id:");
            id = int.Parse(Console.ReadLine());
            var role = Up.GetRoleForUser(id);
            Console.WriteLine($"{role.RoleId}");
            Console.WriteLine($"{role.RoleName}");
            Console.WriteLine($"{role.Description}");
            Console.ReadKey();
            Console.Clear();
        }

        private static void UpdateUserRole()
        {
            Console.WriteLine("Enter User Id: __");
            int id = int.Parse(Console.ReadLine());
            var roles = Rp.GetAllRoles();

            foreach (var role in roles)
                Console.Write(role.RoleName + ", ");

            Console.WriteLine();

            Console.WriteLine("Enter Role Name:");
            string roleChoice = Console.ReadLine();

            Console.WriteLine("Save this mapping? Y/N");
            string c = Console.ReadLine();
            if (c == "Y")
            {

                int roleId = 0;
                foreach (var role in roles)
                {
                    if (role.RoleName == roleChoice)
                        roleId = role.RoleId;
                }
                Up.UpdateRole(id, roleId);
            }

            Console.ReadKey();
            Console.Clear();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            int choice = -1;
            while(choice != 0)
            {
                PrintMainMenu();
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch(choice)
                {
                    case 1:
                        ManageUser();
                        break;
                    case 2:
                        ManageRoles();
                        break;
                    case 3:
                        ManageUserRoles();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
