using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace bai1
{
    public partial class Form1 : Form
    {
        Socket server;
        Socket client;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 21313);
            server.Bind(ip);
            server.Listen(2);
            client = server.Accept();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] data = Encoding.ASCII.GetBytes(txtMessage.Text);
            client.Send(data);
            lstText.Items.Add("Server: " + txtMessage.Text);
            txtMessage.Text = "";
            data = new byte[2014];
            client.Receive(data);
            lstText.Items.Add("Client: " + Encoding.ASCII.GetString(data));
        }
    }
}
