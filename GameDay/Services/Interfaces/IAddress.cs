using System.Collections.Generic;
using Domain.Layer.Models;

namespace GameDay.Services.Interfaces
{
    public interface IAddress
    {
        List<Address> GetAddresses();
        Address FindAddress(int? id);
        void AddAddress(Address a);
        void EditAddress(Address a);
        void DeleteAddress(Address a);
        void SaveChanges();
        void Dispose();
    }
}
