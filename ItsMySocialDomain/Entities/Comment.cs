﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsMySocialDomain.Entities
{
    public class Comment
    {
        public long Id { get; set; }
        public string Contenet { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public long PostId { get; set; }
        public Post Post { get; set; }
        public long UserId { get; set; }
        //public User User { get; set; }

    }
}
