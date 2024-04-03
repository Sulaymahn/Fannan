﻿namespace Fannan.Web.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; } = string.Empty;
        public User? Sender { get; set; }
        public User? Receiver { get; set; }
        public DateTime Date { get; set; }
    }
}
