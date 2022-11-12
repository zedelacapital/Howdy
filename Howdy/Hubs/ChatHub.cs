﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;

namespace Howdy.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        public ChatHub()
        {
            _botUser = "MyChat Bot";
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
            
            await Clients.Group(userConnection.Room).SendAsync("RecieveMessage", _botUser, $"{userConnection.User} has joind {userConnection.Room}");
        }
    }
}
