using System;
using System.Collections.Generic;
using System.IO;
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Message> Inbox { get; set; } = new List<Message>();
    public List<Message> SentMessages { get; set; } = new List<Message>();

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

public class Message
{
    public string From { get; set; }
    public string To { get; set; }
    public string Content { get; set; }
    public DateTime DateSent { get; set; }

    public Message(string from, string to, string content)
    {
        From = from;
        To = to;
        Content = content;
        DateSent = DateTime.Now;
    }
}