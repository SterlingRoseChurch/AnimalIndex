using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using TheAnimalIndex.Controllers;
using TheAnimalIndex.Models;
using Moq;
using Xunit;

namespace TheAnimalIndex.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnViewResult()
        {
            var ctx = new Mock<AnimalContext>();
            var controller = new HomeController(ctx.Object) 
            { 
                TempData = new FakeAnimalContext()
            };


            var result = controller.Index();
           

            Assert.IsType<ViewResult>(result);
        }

    }
}
