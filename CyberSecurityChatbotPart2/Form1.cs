using System;
using System.Media;
using System.Windows.Forms;

namespace CyberSecurityChatbot
{
    public partial class Form1 : Form
    {
        ChatBot bot;

        public Form1()
        {
            InitializeComponent();

            string userName = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter your name:",
                "Cybersecurity Bot",
                "");

            while (string.IsNullOrWhiteSpace(userName))
            {
                userName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Please enter a valid name:",
                    "Cybersecurity Bot",
                    "");
            }

            bot = new ChatBot(userName);

            // Voice greeting
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {

            }

            richTextBox1.AppendText("====================================\n");
            richTextBox1.AppendText("      CYBER SECURITY BOT\n");
            richTextBox1.AppendText("====================================\n\n");

            richTextBox1.AppendText($"Welcome {userName}!\n");
            richTextBox1.AppendText("Ask me about passwords, phishing, scams, or safe browsing.\n");
            richTextBox1.AppendText("Type 'exit' to quit.\n\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            richTextBox1.AppendText("You: " + textBox1.Text + "\n");

            string response = bot.GetResponse(input);

            richTextBox1.AppendText("Bot: " + response + "\n\n");

            if (input == "exit")
            {
                Application.Exit();
            }

            textBox1.Clear();
        }
    }
}