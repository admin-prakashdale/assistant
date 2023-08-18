using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Model;
public class Conversation
{
    public Profile Sender { get; set; }    
    public DateTime DateStarted { get; set; }
    public DateTime LastSeen { get; set; }
    public string LastMessage { get; set; }
}
