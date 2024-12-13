using System;
using System.Collections.Generic;
using System.IO;

namespace MaillApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

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