using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    internal class ChatBot
    {
        public string UserName { get; set; }

        Random random = new Random();

        // Memory feature
        private string rememberedTopic = "";

        // Random responses
        private List<string> passwordResponses = new List<string>()
        {
            "Always use strong passwords with letters, numbers, and symbols.",
            "Avoid using the same password on multiple accounts.",
            "Enable two-factor authentication for better security."
        };

        private List<string> phishingResponses = new List<string>()
        {
            "Phishing scams trick users into giving personal information.",
            "Never click suspicious email links.",
            "Always verify who sent the email before responding."
        };

        private List<string> browsingResponses = new List<string>()
        {
            "Only visit secure websites that use HTTPS.",
            "Avoid downloading files from unknown websites.",
            "Keep your browser updated for better security."
        };

        public ChatBot(string name)
        {
            UserName = name;
        }

        public void GreetUser()
        {
        }

        public string GetResponse(string input)
        {
            // Sentiment Detection
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried. Cyber threats can be scary, but I can help you stay safe.";
            }

            if (input.Contains("frustrated"))
            {
                return "I understand your frustration. Let me help you step-by-step.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is great when learning about cybersecurity!";
            }

            // General Questions
            if (input.Contains("how are you"))
                return "I'm functioning well and ready to help you stay safe online.";

            if (input.Contains("purpose"))
                return "My purpose is to educate users about cybersecurity and online safety.";

            // Password keyword
            if (input.Contains("password"))
            {
                rememberedTopic = "password";
                return passwordResponses[random.Next(passwordResponses.Count)];
            }

            // Phishing keyword
            if (input.Contains("phishing") || input.Contains("scam"))
            {
                rememberedTopic = "phishing";
                return phishingResponses[random.Next(phishingResponses.Count)];
            }

            // Safe browsing keyword
            if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                rememberedTopic = "browsing";
                return browsingResponses[random.Next(browsingResponses.Count)];
            }

            // Memory and Recall
            if (input.Contains("tell me more") || input.Contains("another tip"))
            {
                if (rememberedTopic == "password")
                {
                    return "You should also avoid sharing passwords with anyone.";
                }

                if (rememberedTopic == "phishing")
                {
                    return "Scammers often create fake websites to steal information.";
                }

                if (rememberedTopic == "browsing")
                {
                    return "Using antivirus software helps protect your device while browsing.";
                }
            }

            // Exit
            if (input.Contains("exit"))
                return "Goodbye! Stay safe online.";

            // Error Handling
            return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}