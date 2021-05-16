using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            string url = "http://api.openweathermap.org/data/2.5/find?q=" + city + "&type=like&APPID=c3f93d23f4afc931f07743b1f8a9ffc6";

            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            JObject o = JObject.Parse(s);

            JToken b = o["list"][0]["main"]["temp"];
            int tempr = Convert.ToInt32(b);

            JToken  v = o["list"][0]["wind"]["speed"];
            int wind = Convert.ToInt32(v);

            JToken l = o["list"][0]["main"]["humidity"];
            int humidity = Convert.ToInt32(l);

            JToken dg = o["list"][0]["main"]["humidity"];
            int degree = Convert.ToInt32(dg);  // направление ветра раздел по 22.5




            label1.Text = ("Температура: ")+(tempr - 273).ToString();
            label2.Text = ("Ветер: ")+(wind)+(" м/с").ToString();
            label3.Text = ("Влажность: ")+(humidity)+("%").ToString();
            //label4.Text =



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
