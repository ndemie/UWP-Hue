using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Hue.Models
{
    public class Success
    {
        public string username { get; set; }
    }

    public class Authentication
    {
        public Success success { get; set; }
    }
}
