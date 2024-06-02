using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorWebApp.Data.Model;
using BlazorWebApp.Data;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;

    public ChatHub(ApplicationDbContext context)
    {
        _context = context;
    }

    public override async Task OnConnectedAsync()
    {
        var messages = await _context.ChatMessages
                               .OrderByDescending(m => m.Created)
                               .Take(100) // Adjust the number of messages as needed
                               .OrderBy(m => m.Created)
                               .ToListAsync();

        await Clients.Caller.SendAsync("ReceiveMessages", messages);
        await base.OnConnectedAsync();
    }

    public async Task Typing(string userName)
    {
        await Clients.Others.SendAsync("UserTyping", userName);
    }

    public async Task SendMessageToAll(string userName, string message, DateTime dateTime)
    {
        var chatMessage = new ChatMessage
        {
            UserName = userName,
            Message = message,
            Created = dateTime
        };

        _context.ChatMessages.Add(chatMessage);
        await _context.SaveChangesAsync();

        await Clients.All.SendAsync("ReceiveMessage", userName, message, dateTime);
    }
}
