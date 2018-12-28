using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AngleSharp.Dom.Html;
using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using AngleSharp;
using System.Text.RegularExpressions;

namespace WebRequests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            char[] arr = new char[1024];
            string line;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(str);
            request.UserAgent ="Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.Accept = @"*/*";
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    line = reader.ReadToEnd();
                                                   
                }
            }

            var config = Configuration.Default.WithJavaScript().WithCss();

            var parser = new HtmlParser(config);
            var doc = parser.Parse(line);
           
            var cells = doc.QuerySelectorAll("div.a-container h4");
            
            var kells = doc.QuerySelectorAll("div.a-container div.text");
            var listH = new List<string>();
            var listTxt = new List<string>();
            foreach (var cell in cells)
            {
                listH.Add(cell.TextContent);
                
            }
            foreach (var kell in kells)
            {
                listTxt.Add(kell.TextContent);
            }
            for (int i = 0; i < listH.Count; i++)
            {

                richTextBox1.Text += listH[i].ToString() +"\r\n"+ listTxt[i].ToString()+"\r\n";
             

            }
            foreach (var cell in cells)
            {
                if (richTextBox1.Find(cell.TextContent) > -1)
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
            }
            /*  int my1stPosition = richTextBox1.Find(Convert.ToString(listH));
              richTextBox1.SelectionStart = my1stPosition;
              richTextBox1.SelectionLength = str.Length;*/



            response.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
