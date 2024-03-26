using LoginManagement.DataAccess;
using LoginManagement.Entities;

namespace TestProject
{
    [TestClass]
    public class UserTests
    {
        IRepository<User, int> repository = new UserRepository();

        [TestMethod]
        public void Test_For_Insert()
        {
            int ExpectedResult = repository.GetAll().Count() + 1;
            User user = new User();
            user.UserName  = "Test1";
            user.FirstName = "Test1";
            user.LastName = "Test1";
            user.Password = "Test";
            user.IsActive = true;
            repository.AddNew(user);
            int ActualResults = repository.GetAll().Count();    
            Assert.AreEqual(ExpectedResult, ActualResults); 
        }
        [TestMethod]
        public void Test_For_FindById()
        {

            User user = new User();
            user.UserName = "Test4";
            user.FirstName = "Test4";
            user.LastName = "Test4";
            user.Password = "Test4";
            user.IsActive = true;

            //repository.AddNew(user);
            Console.WriteLine(3);

            var entity = repository.FindById(user.UserId);

            Assert.IsNotNull(entity);
            Assert.AreEqual(entity.UserId, user.UserId);


        }
        [TestMethod]
        public void Test_For_GetAll()
        {
            int ExpectedResult = repository.GetAll().Count() ;
            User user = new User();
            user.UserName = "Test3";
            user.FirstName = "Test3";
            user.LastName = "Test3";
            user.Password = "Test3";
            user.IsActive = false;
            repository.AddNew(user);
            int ActualResult = repository.GetAll().Count(); 
            Assert.AreEqual(ExpectedResult, ActualResult);
        }
        [TestMethod]
        public void Test_For_Remove()
        {
            int ExpectedResult = repository.GetAll().Count();
            
            repository.Remove(9);
            int ActualResult = repository.GetAll().Count();
            Assert.AreEqual(ExpectedResult, ActualResult+1);
        }
        [TestMethod]
        public void Test_For_Update()
        {
            var user = repository.FindById(1);
            user.UserName = "Updated Name";
            repository.Update(user);
            var updatedUser = repository.FindById(user.UserId);
            Assert.AreEqual(user.UserName, updatedUser.UserName);
        }
    }
}