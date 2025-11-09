using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MessengerApp
{
    public enum MessageType
    {
        Text,
        Image,
        UserList,
        UserConnect,
        System
    }

    public class ChatMessage
    {
        public string Sender { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public MessageType Type { get; set; } = MessageType.Text;
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[] ImageData { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> UserList { get; set; }
    }
}