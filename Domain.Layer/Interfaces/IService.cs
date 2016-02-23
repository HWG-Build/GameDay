using System.Collections.Generic;
using Domain.Layer.Models;

namespace Domain.Layer.Interfaces
{
    public interface IService<T>
    {
        List<T> GetRecords();
        T FindRecord(int? id);
        void AddRecord(T t);
        void EditRecord(T t);
        void DeleteRecord(T t);
        void SaveChanges();
        void Dispose();
    }
}
