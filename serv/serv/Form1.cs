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
using System.IO;
using System.Threading;


namespace serv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static string path = "C:/Users"; //System.Configuration.ConfigurationManager.AppSettings["Path"];
        private void button1_Click(object sender, EventArgs e)
        {
                socket.Bind(new IPEndPoint(IPAddress.Any, 8888));
                socket.Listen(3);
                Socket client = socket.Accept();
                textBox1.Text += "Новое подключение";
                byte[] buffer = new byte[1024];
                int sizebuf = client.Receive(buffer);
                string decode = "";
                for (int i = 0; i < sizebuf; i++)
                {
                    decode += Convert.ToChar(buffer[i]);
                }
               //// //string s = Encoding.ASCII.GetString(decode);
                textBox1.Text += decode; 
                switch (decode)
                {
                    case "/Show":
                        if (Directory.Exists(path))
                        {
                            textBox1.Text += "Корневая система:";
                            string[] dir = Directory.GetDirectories(path);
                            foreach (string str in dir)
                            {
                                textBox1.Text = str;
                            }
                            textBox1.Text += "\r\n";
                            string[] file = Directory.GetFiles(path);
                            foreach (string str in file)
                            {
                                textBox1.Text += str;
                            }
                        }
                        else
                        {
                            textBox1.Text += "Неверный путь";
                        }
                        break;

                }

            
        }
    }
}
