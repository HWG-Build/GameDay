using System;
using Data.Layer.Interfaces;
using Data.Layer.Models;
using GameDay.Controllers;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Web.Mvc;
using Data.Layer;
using GameDay.Models;

namespace UnitTest.Services
{
    public class AddressServiceTest
    {
        private Mock<IService<Address>> _addressServiceMock;
        private AddressController objController;
        private List<Address> listAddress;
        private List<AddressVM> listAddressVM;

        public AddressServiceTest()
        {
            _addressServiceMock = new Mock<IService<Address>>();
            objController = new AddressController(_addressServiceMock.Object);
            
            listAddress = new List<Address>() {
               new Address() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 },
               new Address() { ID = 2, Name = "test2", Line1 = "2 street", City = "City2", State = (State)2, Zip = 91234 },
               new Address() { ID = 3, Name = "test3", Line1 = "3 street", City = "City3", State = (State)3, Zip = 91245 }
            };

            listAddressVM = new List<AddressVM>() {
               new AddressVM() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 },
               new AddressVM() { ID = 2, Name = "test2", Line1 = "2 street", City = "City2", State = (State)2, Zip = 91234 },
               new AddressVM() { ID = 3, Name = "test3", Line1 = "3 street", City = "City3", State = (State)3, Zip = 91245 }
            };
        }

        [Fact]
        public void Address_Get_All()
        {
            // Arrange
            _addressServiceMock.Setup(x => x.GetRecords()).Returns(listAddress);

            // Act
            //System.Diagnostics.Debugger.Launch();
            var result = (List<AddressVM>)((ViewResult)objController.Index()).Model;

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("test1", result[0].Name);
            Assert.Equal("test2", result[1].Name);
            Assert.Equal("test3", result[2].Name);
        }

        [Fact]
        public void Event_Create_Route()
        {
            //Arrange
            var addressVM = new AddressVM() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 };

            //Act
            var result = (RedirectToRouteResult)objController.Create(addressVM);

            //Assert
            _addressServiceMock.Verify(m => m.AddRecord(It.IsAny<Address>()), Times.Once);
            Assert.Equal(Constant.Controller.Index, result.RouteValues[Constant.Controller.Action]);
        }

        [Fact]
        public void Event_Details()
        {
            //Arrange
            var address = new Address() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 };
            _addressServiceMock.Setup(x => x.FindRecord(address.ID)).Returns(address);

            //Act
            var result = (AddressVM)((ViewResult)objController.Details(address.ID)).Model;

            //Assert
            Assert.Equal("test1", result.Name);
        }

        //[Fact]
        //public void Event_Edit_Route()
        //{
        //    //Arrange
        //    int id = 1;
        //    var addressVM = new AddressVM() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 };

        //    //Act
        //    var result = (ViewResult)objController.Edit(id);

        //    //Assert
        //    _addressServiceMock.Verify(m => m.FindRecord(It.IsAny<Int32>()), Times.Once);
        //    Assert.Equal(test1, result);
        //}

    }
}
