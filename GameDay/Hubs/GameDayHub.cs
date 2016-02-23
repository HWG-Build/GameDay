using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;


namespace GameDay.Hubs
{
    public class GameDayHub : Hub
    {
        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            //Clients.All.Hello(name);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool b)
        {
            return base.OnDisconnected(b);
        }
    }
}
