using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsMySocialDomain.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public bool Is_read { get; set; } = false;
        public long User_Id { get; set; }
        public User User { get; set; }
        //public long Sender_Id { get; set; }
        //public User senderUser { get; set; }
        //public long Reciever_Id { get; set; }
        //public User recieverUser { get; set; }

    }
}
