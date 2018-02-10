using Microsoft.AspNet.SignalR;

namespace ToMars.Web.Hubs
{
    public class ProgressHub : Hub
    {
        static IHubContext _Progress = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
        public static void SendProgress(string connectionID, int progressCount, int totalItems)
        {
            _Progress.Clients.Client(connectionID).AddProgress(progressCount, totalItems);
        }
        public static void SendMessage(string connectionId, string message)
        {
            _Progress.Clients.Client(connectionId).ShowMessage(message);
        }
        public static void HideProgress(string connectionId)
        {
            _Progress.Clients.Client(connectionId).HideProgress();
        }
        public static void ParsingCompleted(string connectionId, int fileId)
        {
            _Progress.Clients.Client(connectionId).ParsingCompleted(fileId);
        }

    }
}