using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;


namespace GameDay.Hubs
{
    public class ChatHub : Hub
    {
        //Gets the identity of the person logged in and send it to the js function to append on screen
        //Allows instant updates to the chat div without refeshing page
        public void Send(string message)
        {
            string name = Context.User.Identity.Name;
            name = name.Substring(0, name.IndexOf("@", StringComparison.Ordinal));
            Clients.All.broadcastMessage(name, message);
        }

        //Currently not doing anything
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            name = name.Substring(0, name.IndexOf("@", StringComparison.Ordinal));
            return base.OnConnected();
        }

        //Currently not doing anything
        public override Task OnDisconnected(bool b)
        {
            return base.OnDisconnected(b);
        }
    }
}
