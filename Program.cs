using Newtonsoft.Json;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessengerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            Chat japanChat = JsonConvert.DeserializeObject<Chat>(File.ReadAllText(@"d:\codeProjects\message_1.json"));
            //Console.WriteLine(japanChat.messages[1].content);
            foreach (Message msg in japanChat.messages)
            {
                foreach (Participant member in japanChat.participants)
                {
                    if (member.name == msg.sender_name)
                    {
                        member.msg_count += 1;
                    }
                }
            }
            foreach (Participant member in japanChat.participants)
            {
                Console.WriteLine($"messages sent by {member.name}: {member.msg_count}");
            }
        }
    }
    public class Participant
    {
        public string name { get; set; }
        public int msg_count { get; set; }
    }

    public class Message
    {
        public string sender_name { get; set; }
        public object timestamp_ms { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public bool is_unsent { get; set; }
    }

    public class Image
    {
        public string uri { get; set; }
        public int creation_timestamp { get; set; }
    }

    public class Chat
    {
        public IList<Participant> participants { get; set; }
        public IList<Message> messages { get; set; }
        public string title { get; set; }
        public bool is_still_participant { get; set; }
        public string thread_type { get; set; }
        public string thread_path { get; set; }
        public IList<object> magic_words { get; set; }
        public Image image { get; set; }
    }
}
