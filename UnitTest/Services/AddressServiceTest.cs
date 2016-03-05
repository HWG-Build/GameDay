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

        //Intialize the addressservice as a mock
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

        //test to make sure that we get the count and all results when we invoke the getrecord method
        [Fact]
        public void Get_All_Addresses_From_GetRecord_Test()
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

        //Make sure that the create function in the address controller returns the correct view
        [Fact]
        public void Verify_Correct_Route_When_Calling_Create()
        {
            //Arrange
            var addressVM = new AddressVM() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 };

            //Act
            var result = (RedirectToRouteResult)objController.Create(addressVM);

            //Assert
            _addressServiceMock.Verify(m => m.AddRecord(It.IsAny<Address>()), Times.Once);
            Assert.Equal(Constant.Controller.Index, result.RouteValues[Constant.Controller.Action]);
        }

        //test to make sure that the correct details are returned from the getdetails function
        [Fact]
        public void Get_Correct_Values_From_GetRecord()
        {
            //Arrange
            var address = new Address() { ID = 1, Name = "test1", Line1 = "1 street", City = "City1", State = (State)1, Zip = 91234 };
            _addressServiceMock.Setup(x => x.FindRecord(address.ID)).Returns(address);

            //Act
            var result = (AddressVM)((ViewResult)objController.Details(address.ID)).Model;

            //Assert
            Assert.Equal("test1", result.Name);
        }
    }
}
