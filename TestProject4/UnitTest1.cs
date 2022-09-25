using Findergers1._0.Controllers;
using Findergers1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestProject4
{
    public class Tests
    {
        public int Id { get; private set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Index()
        {
            DesaparecidosController controller = new DesaparecidosController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Edit()
            
        {
            DesaparecidosController controller = new DesaparecidosController();
            var result = controller.Edit(1) as ViewResult;
        }
        [Test]
        public void Delete()

        {
            DesaparecidosController controller = new DesaparecidosController();
            var result = controller.Delete(1) as ViewResult;
        }

    }
}