namespace FIT_Api_Examples.Hubs
{
    using Microsoft.AspNetCore.SignalR;


    public class FeedHub : Hub
    {
        public FeedHub()
        {

        }
        public async Task SaljiTxtBox(string p)
        {
            await Clients.Others.SendAsync("PrimiTxtBox", p);
        }
     
    }
}
