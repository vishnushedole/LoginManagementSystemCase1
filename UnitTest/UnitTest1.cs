using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_For_Insert()
        {
            IRespository<User, int> respository = new UserRepository();
            int expectedResult;
        }
    }
}
