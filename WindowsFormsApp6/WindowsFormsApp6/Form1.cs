using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        

        private void button1_Click(object sender, EventArgs e)
        {

            socket.Connect("127.0.0.1", 8888);
            string msg = Convert.ToString(textBox1.Text);
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            socket.Send(buffer);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
