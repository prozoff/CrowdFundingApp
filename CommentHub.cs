using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp
{
    public class CommentHub : Hub
    {
        public async Task Send(string comment)
        {
            await this.Clients.All.SendAsync("Send", comment);
        }
    }
}
