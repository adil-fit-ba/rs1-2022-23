namespace FIT_Api_Examples.Hubs
{
    using Microsoft.AspNetCore.SignalR;


    public class FeedHub : Hub
    {
        public FeedHub()
        {

        }

        public async Task Posalji1(string podaci)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("preuzmi_poruku_od_server1", podaci);
        }

        public async Task Posalji2(string podaci)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("preuzmi_poruku_od_server2", podaci);
        }
    }
}
