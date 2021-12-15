using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 add = new Form1();
            Session obj = new Session
            {
                Fullname = new FN
                {
                    Name = textBox1.Text,
                    Lastname = textBox2.Text
                },

                Exams = new EX
                {
                    Programming = textBox3.Text,
                    WEB = textBox4.Text,
                    Math = textBox5.Text
                },

                Offset = new OF
                {
                    TCPP = textBox8.Text,
                    Networks = textBox7.Text
                }
            };
            

            add.InsertRecord(obj);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
