using System;
using Data.Layer.Interfaces;
using Data.Layer.Models;
using GameDay.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
            var result = ((AddressListVM)((ViewResult)objController.Index()).Model).AddressList.ToList();
            //var result2 = result.AddressList.ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("test1", result[0].Name);
            Assert.Equal("1 street", result[0].Line1);
            Assert.Equal("City1", result[0].City);
            Assert.Equal((State)1, result[0].State);
            Assert.Equal(91234, result[0].Zip);
            Assert.Equal("test2", result[1].Name);
            Assert.Equal("2 street", result[1].Line1);
            Assert.Equal("City2", result[1].City);
            Assert.Equal((State)2, result[1].State);
            Assert.Equal(91234, result[1].Zip);
            Assert.Equal("test3", result[2].Name);
            Assert.Equal("3 street", result[2].Line1);
            Assert.Equal("City3", result[2].City);
            Assert.Equal((State)3, result[2].State);
            Assert.Equal(91245, result[2].Zip);
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
        public void Detail_Get_Correct_Values_From_GetRecord()
        {
            //Arrange
            _addressServiceMock.Setup(x => x.FindRecord(It.IsAny<int>())).Returns(listAddress[0]);

            //Act
            var result = (AddressVM)((ViewResult)objController.Details(listAddress[0].ID)).Model;

            //Assert
            Assert.Equal("test1", result.Name);
            Assert.Equal("1 street", result.Line1);
            Assert.Equal("City1", result.City);
            Assert.Equal((State)1, result.State);
            Assert.Equal(91234, result.Zip);
        }

        [Fact]
        public void Edit_Get_Action_Calls_EditRecord()
        {
            //Arrange
            _addressServiceMock.Setup(x => x.EditRecord(It.IsAny<Address>()));

            //Act
            var result = (RedirectToRouteResult)objController.Edit(listAddressVM[0]);

            //Assert
            _addressServiceMock.Verify(x=>x.EditRecord(It.IsAny<Address>()), Times.Once);
            Assert.Equal(Constant.Controller.Index, result.RouteValues[Constant.Controller.Action]);
        }

        [Fact]
        public void Delete_Post_Action_Calls_DeleteRecord()
        {
            //Arrange
            _addressServiceMock.Setup(x => x.DeleteRecord(It.IsAny<Address>()));

            //Act
            var result = (RedirectToRouteResult)objController.DeleteConfirmed(1);

            //Assert
            _addressServiceMock.Verify(x=>x.DeleteRecord(It.IsAny<Address>()), Times.Once);
            Assert.Equal(Constant.Controller.Index, result.RouteValues[Constant.Controller.Action]);
        }
    }
}
