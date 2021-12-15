using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDB
{
    
    public partial class Form1 : Form
    {
        IMongoCollection<Session> collection;
        IMongoCollection<Session2_0> collection2_0;
        IMongoDatabase db;
        MongoClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private void connection()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("Session2_0");
            collection = db.GetCollection<Session>("Students");
            collection2_0 = db.GetCollection<Session2_0>("Students");
        }

        public void InsertRecord<T>(T record)
        {
            connection();
            var collection = db.GetCollection<T>("Students");
            try
            {
                collection.InsertOne(record);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            connection();
            var objects = collection2_0.Find(_ => true).ToList();
            BindingList<Session2_0> doclist = new BindingList<Session2_0>();
            foreach (var deger in objects)
            {
                doclist.Add(deger);
                Application.DoEvents();
            }
            dataGridView1.DataSource = doclist;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("Do you really want to exit?", "Session2.0", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (iExit == DialogResult.Yes)
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var filter = Builders<Session2_0>.Filter.Eq("_id", new Bson.ObjectId(textBox3.Text));
            collection2_0.DeleteOne(filter);
        }
    }

    public class Session
    {
        [BsonId]
        public Bson.ObjectId _id { get; set; }
        public FN Fullname { get; set; }
        public EX Exams { get; set; }
        public OF Offset { get; set; }
    }

    public class FN
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
    }

    public class EX
    {
        public string Programming { get; set; }
        public string WEB { get; set; }
        public string Math { get; set; }
    }

    public class OF
    {
        public string TCPP { get; set; }
        public string Networks { get; set; }
    }

    public class Session2_0
    {
        [BsonId]
        [BsonRepresentation(Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public Bson.BsonDocument Fullname { get; set; }
        public Bson.BsonDocument Exams { get; set; }
        public Bson.BsonDocument Offset { get; set; }
    }
}
