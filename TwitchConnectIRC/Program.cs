using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchConnectIRC
{
    public class Program
    {
	    static void Main(string[] args)
	    {
            // Jooj plz dont steal my oauth code :(
            IrcClient irc = new IrcClient("irc.twitch.tv", 6667, "argentumvir", "oauth:fsxdrod6u373j4q5t0yt12ciy6pf2x");

            irc.joinRoom("argentumvir");
            while (true)
            {
                string message = irc.readMessage();
                Console.WriteLine(message);
            }
	    }
    }
}