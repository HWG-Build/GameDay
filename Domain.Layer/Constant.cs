using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Layer
{
    public static class Constant
    {
        public const string Title = "GameDay";

        public class Page
        {

        }

        public class Partial
        {
            public const string EventListPartial = "_EventListPartial";
            public const string EventDetailPartial = "_EventDetailPartial";
            public const string EditDetailPartial = "_EditDetailPartial";
        }
        
        public class Controller
        {
            public const string Index = "Index";
            public const string Home = "Home";
            public const string Delete = "Delete";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Details = "Details";
            public const string EventFields = "ID,Name,Game,Date,Time,Location";
            public const string PlayerFields = "ID,FirstName,LastName,Position,Phone";
            public const string AddressFields = "ID,Name,Line1,Line2,City,State,Zip";
        }
        
        public class ViewModels
        {
            public const string Email = "Email";
            public const string Code = "Code";
            public const string Password = "Password";
            public const string FirstName = "First Name";
            public const string LastName = "Last Name";
            public const string Location = "Location";
        }

        public class Model
        {
            public const string AddressId = "AddressId";
            public const string AttendingPlayers = "AttendingPlayers";
            public const string EventId = "EventId";
            public const string EventsAttending = "EventsAttending";
        }
        

    }
}
