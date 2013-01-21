using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Isima.InstantMessaging.Contacts.Xml;
using Isima.InstantMessaging.Contacts;

namespace Isima.InstantMessaging.WindowsClient
{
    public partial class MainForm : Form
    {

        ContactDataSet ds;


        public MainForm()
        {
            InitializeComponent();
            ds = new XmlContactManager().Load();
            if (ds == null)
                ds = new ContactDataSet();
            dataGridView1.DataMember = "Contacts";
            dataGridView1.DataSource = ds;
            //new ConversationForm("marquesthom", "florian.rotagnon").Show();
        }

        public void MainWindows_Load(Object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddContact ac = new AddContact();
            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ds.Contacts.AddContactsRow(ac.Address_Text_Box.Text, ac.Name_Text_Box.Text);
            }
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            new XmlContactManager().Save(ds);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            ds = new XmlContactManager().Load();
            if (ds == null)
                ds = new ContactDataSet();
            dataGridView1.DataMember = "Contacts";
            dataGridView1.DataSource = ds;
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            ds.Clear();
        }

    }
}
