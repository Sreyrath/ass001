using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NotificationChannelParser
{
    class Program
    {
        // Dictionary to map each tag to a specific notification channel
        private static readonly Dictionary<string, string> tagToChannelMap = new Dictionary<string, string>
        {
            { "BE", "BE" },
            { "FE", "FE" },
            { "QA", "QA" },
            { "Urgent", "Urgent" }
        };

        // Method to parse notification channels from the title
        public static List<string> ParseNotificationChannels(string title)
        {
            // List to store the notification channels found in the title
            List<string> channels = new List<string>();

            // Regular expression to match tags inside square brackets
            var tagPattern = new Regex(@"\[(.*?)\]");
            var matches = tagPattern.Matches(title);

            foreach (Match match in matches)
            {
                // Extract the tag (content inside brackets)
                string tag = match.Groups[1].Value.Trim();

                // Check if the tag maps to a known channel
                if (tagToChannelMap.TryGetValue(tag, out string channel) && !channels.Contains(channel))
                {
                    channels.Add(channel); // Add the channel if it's not already in the list
                }
            }

            return channels; // Return the list of relevant channels
        }

        static void Main(string[] args)
        {
            // Sample title to test the parser
            Console.WriteLine("Enter a notification title:");
            string title = Console.ReadLine();

            // Parse channels from the title
            List<string> channels = ParseNotificationChannels(title);

            // Display the result
            Console.WriteLine("\nNotification Channels:");
            foreach (string channel in channels)
            {
                Console.WriteLine($"{channel},");
            }

            // Wait for the user to press a key before exiting
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}