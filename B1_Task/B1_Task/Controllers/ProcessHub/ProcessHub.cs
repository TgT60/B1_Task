using Microsoft.AspNetCore.SignalR;

namespace B1_Task.Controllers.ProcessHub
{
    public class ProcessHub : Hub
    {
        public async Task UploadProcess(int importedCount, int remainingCount)
        {
            await Clients.All.SendAsync("UploadProcess", importedCount, remainingCount);
        }
    }
}
