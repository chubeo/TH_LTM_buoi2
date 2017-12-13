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


namespace bai1_
{
    public partial class Form1 : Form
    {
        Socket server;
        Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtIPSV_TextChanged(object sender, EventArgs e)
        {

        }
         private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 21313);
        }

         private void btnSend_Click(object sender, EventArgs e)
         {
             byte[] data;
             data = Encoding.ASCII.GetBytes(txtMessage.Text);
             lstText.Items.Add("Client: " + txtMessage.Text);
             data = new byte[1024];
             client.Receive(data);
             lstText.Items.Add("Server: " + Encoding.ASCII.GetString(data));

         }

         private void btnConnect_Click(object sender, EventArgs e)
         {
             IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 21313);
             client.Connect(ipep);
             byte[] data;
             data = new byte[1024];
             client.Receive(data);
             lstText.Items.Add("Server: " + Encoding.ASCII.GetString(data));

         }
    }
}
