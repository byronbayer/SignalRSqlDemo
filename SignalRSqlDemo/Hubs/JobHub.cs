using Microsoft.AspNet.SignalR;

namespace SignalRSqlDemo.Hubs
{
    public class JobHub : Hub
    {
        public static void Show()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<JobHub>();
            context.Clients.All.displayStatus();
        }
    }
}