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
public class MailBox
{
    private Dictionary<string, User> users = new Dictionary<string, User>();

    public bool RegisterUser(string username, string password)
    {
        if (users.ContainsKey(username))
        {
            Console.WriteLine("User already exists.");
            return false;
        }

        users.Add(username, new User(username, password));
        Console.WriteLine("Registration successful!");
        return true;
    }

    public User Authenticate(string username, string password)
    {
        if (users.ContainsKey(username) && users[username].Password == password)
        {
            return users[username];
        }
        return null;
    }

    public void SendMessage(User fromUser, string toUsername, string content)
    {
        if (users.ContainsKey(toUsername))
        {
            var message = new Message(fromUser.Username, toUsername, content);
            users[toUsername].Inbox.Add(message);
            fromUser.SentMessages.Add(message);
            Console.WriteLine("Message sent successfully!");
        }
        else
        {
            Console.WriteLine("Recipient not found.");
        }
    }

    public void ReceiveMessages(User user)
    {
        if (user.Inbox.Count == 0)
        {
            Console.WriteLine("No messages.");
            return;
        }

        foreach (var message in user.Inbox)
        {
            Console.WriteLine($"From: {message.From}, Date: {message.DateSent}, Message: {message.Content}");
        }
    }

    public void ExportMessagesToTxt(User user)
    {
        string fileName = $"{user.Username}_messages.txt";
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var message in user.Inbox)
            {
                writer.WriteLine($"From: {message.From}, Date: {message.DateSent}");
                writer.WriteLine($"Message: {message.Content}");
                writer.WriteLine(new string('-', 40));
            }
        }
        Console.WriteLine($"Messages exported to {fileName}");
    }
}