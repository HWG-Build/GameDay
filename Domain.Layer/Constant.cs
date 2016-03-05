using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer
{
    public static class Constant
    {
        public const string Title = "GameDay";

        public class Route
        {
            public const string Default = "Defualt";
            public const string DefaultUrl = "{controller}/{action}/{id}";
            public const string Home = "Home";
            public const string IgnoreRoute = "{resource}.axd/{*pathInfo}";
        }

        public class Partial
        {
            public const string EventListPartial = "_EventListPartial";
            public const string EventDetailPartial = "_EventDetailPartial";
            public const string EditDetailPartial = "_EditDetailPartial";
        }

        public class StartAuth
        {
            public const string LoginPath = "/Account/Login";
        }

        public class StructuremapMVC
        {
            public const string Start = "Start";
            public const string End = "End";
        }

        public class Controller
        {
            public const string Index = "Index";
            public const string Home = "Home";
            public const string Delete = "Delete";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Lockout = "Lockout";
            public const string Details = "Details";
            public const string Action = "Action";
            public const string Account = "Account";
            public const string Login = "Login";
            public const string ManageLogin = "ManageLogins";
            public const string Manage = "Manage";
            public const string VerifyPhoneNumber = "VerifyPhoneNumber";
            public const string Error = "Error";
            public const string LinkLoginCallback = "LinkLoginCallback";
            public const string ResetPasswordConfirmation = "ResetPasswordConfirmation";
            public const string ExternalLoginCallback = "ExternalLoginCallback";
            public const string VerifyCode = "VerifyCode";
            public const string ExternalLoginConfirmation = "ExternalLoginConfirmation";
            public const string SendCode = "SendCode";
            public const string ExternalLoginFailure = "ExternalLoginFailure";
            public const string ForgotPasswordConfirmation = "ForgotPasswordConfirmation";
            public const string ConfirmEmail = "ConfirmEmail";
            public const string InvalidCode = "Invalid Code.";
        }
        
        public class ViewModels
        {
            public const string Email = "Email";
            public const string Code = "Code";
            public const string Password = "Password";
            public const string FirstName = "First Name";
            public const string LastName = "Last Name";
            public const string Location = "Location";
            public const string ID = "ID";
            public const string Name = "Name";
            public const string ConfirmPassword = "Confirm password";
            public const string DateTime = "Date/Time";
            public const string PlayerCount = "Players:";
        }

        public class Model
        {
            public const string AddressId = "AddressId";
            public const string AttendingPlayers = "AttendingPlayers";
            public const string EventId = "EventId";
            public const string EventsAttending = "EventsAttending";
        }

        public class Keys
        {
            public const string GoogleMapsApiKey = "AIzaSyDqcAyGFqYiYHtuZw7IVmfnz70BTFw-SLk";
        }

        public class EventExceptions
        {
            public const string Message = "Fields cannot be null";
        }
    }
}
