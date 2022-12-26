using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Examples.Modul4_SignalRDemo
{
    public class PorukeHub: Hub
    {
        public async Task ProslijediPoruku(string p)
        {
            await Clients.Others.SendAsync("PosaljiPoruku", p);
        }
    }
}
