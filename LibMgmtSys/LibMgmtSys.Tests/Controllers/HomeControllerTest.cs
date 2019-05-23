using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibMgmtSys.Web;
using LibMgmtSys.Web.Controllers;
using System.Linq.Expressions;

namespace LibMgmtSys.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Create()
        {
            // Arrange
            HomeController controller = new HomeController(new Service<Models.User>(), new Service<Models.Book>());
            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            HomeController controller = new HomeController(new Service<Models.User>(), new Service<Models.Book>());
            // Act
            RedirectToRouteResult result = controller.Delete(Guid.Empty) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            HomeController controller = new HomeController(new Service<Models.User>(), new Service<Models.Book>());
            // Act
            ViewResult result = controller.Edit(Guid.Empty) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            HomeController controller = new HomeController(new Service<Models.User>(), new Service<Models.Book>());
            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(new Service<Models.User>(), new Service<Models.Book>());
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }

    class Service<T> : IService.IService<T> where T : class, new()
    {
        public int Insert(T entity)
        {
            return 1;
        }

        public T QuerySingle(Expression<Func<T, bool>> whereExpression)
        {
            return new T();
        }

        public int Remove(Expression<Func<T, bool>> whereExpression)
        {
            return 1;
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> whereExpression)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new T();
            }
        }

        public int Update(T entity)
        {
            return 2;
        }
    }
}
