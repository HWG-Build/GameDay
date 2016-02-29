using System.Collections.Generic;
using System.Linq;
using Data.Layer.Models;
using TrackerEnabledDbContext.Common.Models;

namespace Data.Layer.Interfaces
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
        IQueryable<AuditLog> GetAuditLogs(int id);
    }
}
