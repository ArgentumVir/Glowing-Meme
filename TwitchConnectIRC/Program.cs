using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TwitchConnectIRC
{
    public class Program
    {
        private static string username;
        private static string oauth;
        private static string configFile = "../../IRC_CONFIG.txt";

	    static void Main(string[] args)
	    {
            
            setCredentials();
            IrcClient irc = new IrcClient("irc.twitch.tv", 6667, username, oauth);

            irc.joinRoom(username);

            //listening loop
            while (true)
            {
                //grab the message from irc
                string message = irc.readMessage();

                //send whole, unadulterated message to the console
                Console.WriteLine(message);

                //grabs actual message, puts it in results[1]
                string[] results = Regex.Split(message, @"PRIVMSG.+:");

                //if it found a match...
                if (results.Length > 1)
                {
                    //automatically respond to fart with toot
                    if (results[1] == "fart")
                    {
                        irc.sendChatMessage("toot");
                    }
                }

                //curls get the gurls
                message = "";
                Array.Clear(results, 0, results.Length);
            }
	    }



        //private auth
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