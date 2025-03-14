using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace MyChatRooms.API.Hubs;
[Authorize]
public class ChatHub : Hub
{
    private static List<MessageDto> messageHistory = new List<MessageDto>();
    private readonly IHttpContextAccessor _contextAccessor;

    public ChatHub(IHttpContextAccessor contextAccessor)
    {
        this._contextAccessor = contextAccessor;
    }
    public async Task SendMessage(string message)
    {

        var user = Context.User;

        if (user == null || String.IsNullOrEmpty(user.Identity?.Name))
        {

            Console.WriteLine("No Identity User found!");
            throw new ArgumentNullException(nameof(user));
        }

        var newMessage = new MessageDto()
        {
            User = user.Identity?.Name!,
            Message = message
        };
        messageHistory.Add(newMessage);
        Console.WriteLine($"new message with content: {message} added to messageHistory, current count is: {messageHistory.Count()}");
        // TODO Get real user
        // string userName = Context.User.Identity.Name;
        // !String.IsNullOrEmpty(userName)
        if (true)
        {
            await Clients.All.SendAsync("ReceiveMessage", newMessage.User, message);
        }
    }

    public override async Task OnConnectedAsync()
    {
        var sessionKey = this._contextAccessor.HttpContext?.Request.Cookies["SessionKey"];
        var inMemorySessionKey = this._contextAccessor.HttpContext?.Session.GetString("SessionKey");

        if (String.IsNullOrEmpty(sessionKey) || sessionKey != inMemorySessionKey)
        {
            Context.Abort();
            throw new UnauthorizedAccessException("Session expired or invalid");
        }

        await Clients.Caller.SendAsync("MessageHistory", messageHistory);
        Console.WriteLine($"messageHistory sent: {messageHistory.Count}");
        Console.WriteLine(JsonConvert.SerializeObject(messageHistory));


        await base.OnConnectedAsync();
    }
}

public class MessageDto
{
    public required string User { get; set; }

    public required string Message { get; set; }
}
