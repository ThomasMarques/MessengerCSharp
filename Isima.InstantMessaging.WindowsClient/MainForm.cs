using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Isima.InstantMessaging.WindowsClient
{
    public partial class MainForm : Form
    {
        Isima.InstantMessaging.Contacts.ContactsDataSet contacts;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tsslStatus.Text = "Initializing session...";
            MessagingContext.Current.SenderAddress = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            bgwSessionInitializer.RunWorkerAsync();

            contacts = MessagingContext.Current.ContactsManager.Load();
            this.dataGridView1.DataMember = "Contacts";
            this.dataGridView1.DataSource = contacts;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            NewContactForm frm = new NewContactForm();
            if (DialogResult.OK.Equals(frm.ShowDialog(this)))
            {
                contacts.Contacts.AddContactsRow(frm.Address, frm.DisplayName);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Refresh();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            MessagingContext.Current.ContactsManager.Save(contacts);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bgwSessionInitializer.IsBusy)
            {
                MessageBox.Show("The session is being initialized. Please wait.");
            }
            else
            {
                if (e.RowIndex >= 0 && e.RowIndex < contacts.Contacts.Count)
                {
                    ConversationForm frm = new ConversationForm(contacts.Contacts[e.RowIndex].Address);
                    frm.Show();
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (row.Index >= 0 && row.Index < contacts.Contacts.Count)
                {
                    contacts.Contacts.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void bgwSessionInitializer_DoWork(object sender, DoWorkEventArgs e)
        {
            MessagingContext.Current.MessagingSessionController.Initialize();
        }

        private void bgwSessionInitializer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = string.Format("{0} ({1})", this.Text, MessagingContext.Current.SenderAddress);
            tsslStatus.Text = "Session initialized.";
        }
    }
}
