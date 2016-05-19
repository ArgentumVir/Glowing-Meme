using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchConnectIRC
{
    public class Program
    {
        private static string username;
        private static string oauth;
        private static string configFile = "../../IRC_CONFIG.txt";

        //silv sucks lol

	    static void Main(string[] args)
	    {
            
            setCredentials();
            IrcClient irc = new IrcClient("irc.twitch.tv", 6667, username, oauth);

            irc.joinRoom(username);
            while (true)
            {
                string message = irc.readMessage();
                Console.WriteLine(message);
            }
	    }

        private static void setCredentials()
        {
            try
            {
                using(StreamReader sr = new StreamReader(configFile))
                {
                    username = sr.ReadLine();
                    oauth = sr.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read config file you're fucked. ");
                Console.WriteLine(e.Message);
            }

        }
    }
}