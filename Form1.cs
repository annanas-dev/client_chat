using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client_chart
{
    public partial class Form1 : Form
    {
        private delegate void Printer(string data);
        private delegate void Cleaner();
        Printer MessagePrinter;
        Cleaner MessageCleaner;
        private Socket _serverSocket;
        private Thread _clientThread;
        private const string _serverHost = "localhost";
        private const int _serverPort = 010205;

        public Form1()
        {
            InitializeComponent();
            MessagePrinter = new Printer(PrintMessage);
            MessageCleaner = new Cleaner(ClearMessage);
            ConnectToServer();
            _clientThread = new Thread(ListenToServer);
            _clientThread.IsBackground = true;
            _clientThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ListenToServer()
        {
            while (_serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRec = _serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#updatechat"))
                {
                    UpdateChatMessages(data);
                    continue;
                }
            }
        }

        private void ConnectToServer()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(ipEndPoint);
            }
            catch { PrintMessage("Failed to connect to server"); }
        }

        private void ClearMessage()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(MessageCleaner);
                return;
            }
            textBox_Chat.Clear();
        }

        private void UpdateChatMessages(string data)
        {
            ClearMessage();
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    PrintMessage(String.Format("[{0}]:{1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }

        private void SendMessageToServer(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = _serverSocket.Send(buffer);
            }
            catch { PrintMessage("Connection with server has been broken"); }
        }

        private void PrintMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(MessagePrinter, msg);
                return;
            }
            if (textBox_Chat.Text.Length == 0)
                textBox_Chat.AppendText(msg);
            else
                textBox_Chat.AppendText(Environment.NewLine + msg);
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            string Name = textBox_Nickname.Text;
            if (string.IsNullOrEmpty(Name)) return;
            SendMessageToServer("#setname&" + Name);
            textBox_Chat.Enabled = true;
            textBox_Message.Enabled = true;
            button_SendMessage.Enabled = true;
            textBox_Nickname.Enabled = false;
            button_Connect.Enabled = false;
        }

        private void SendUserMessage()
        {
            try
            {
                string data = textBox_Message.Text;
                if (string.IsNullOrEmpty(data)) return;
                SendMessageToServer("#newmsg&" + data);
                textBox_Message.Text = string.Empty;
            }
            catch { MessageBox.Show("Error while sending message"); }
        }


        private void button_SendMessage_Click(object sender, EventArgs e)
        {
            SendUserMessage();
        }

        private void textBox_Chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendUserMessage();
        }

        private void textBox_Message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendUserMessage();
        }
    }
}
