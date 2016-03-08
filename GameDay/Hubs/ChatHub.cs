using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;


namespace GameDay.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            string name = Context.User.Identity.Name;
            name = name.Substring(0, name.IndexOf("@", StringComparison.Ordinal));
            Clients.All.broadcastMessage(name, message);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            name = name.Substring(0, name.IndexOf("@", StringComparison.Ordinal));
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool b)
        {
            return base.OnDisconnected(b);
        }
    }
}
