using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NET_student_project.Models
{
    public class MemeModel
    {
        public int Points { get; set; }
        public int Comments { get; set; }
        public DateTime RelesaseTime { get; set; }
        public UserModel User { get; set; }

    }
}