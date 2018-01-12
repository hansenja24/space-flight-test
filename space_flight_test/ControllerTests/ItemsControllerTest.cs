using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using space_flight.Models;
using space_flight.Controllers;

using Moq;
using System.Linq;

namespace space_flight_test
{
    
    [TestClass]
    	public class ControllerTest1
    	{

    		Mock<IItemRepository> mock = new Mock<IItemRepository>();

    		private void DbSetup()
    		{
    			mock.Setup(m => m.Items).Returns(new CrewReq[]
    			{
						new CrewReq {Duration = 10, Tasks = 200, Id = 1},
						new CrewReq {Duration = 20, Tasks = 500, Id = 2}
    			}.AsQueryable());
    		}

    		[TestMethod]
    		public void Mock_GetViewResultIndex_ActionResult()
    		{
                DbSetup();
                ItemController controller = new ItemController(mock.Object);

                var result = controller.Index();

                Assert.IsInstanceOfType(result, typeof(ActionResult));

    		}

    		[TestMethod]
    		public void Mock_IndexContainsModelData_List()
    		{
    			DbSetup();
                ViewResult indexView = new ItemController(mock.Object).Index() as ViewResult;

                var result = indexView.ViewData.Model;

                Assert.IsInstanceOfType(result, typeof(List<CrewReq>));

    		}

    		[TestMethod]
    		public void Mock_IndexModelContainsItems_Collection()
    		{
    			DbSetup();
                ItemController controller = new ItemController(mock.Object);
                CrewReq testItem = new CrewReq();
                testItem.Duration = 10;
                testItem.Tasks = 10;
                testItem.Id = 5;

                ViewResult indexView = controller.Index() as ViewResult;
                List<CrewReq> collection = indexView.ViewData.Model as List<CrewReq>;

                CollectionAssert.Contains(collection, testItem);

    		}
    	}
}
