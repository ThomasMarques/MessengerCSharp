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
using Isima.InstantMessaging.Messaging;

namespace Isima.InstantMessaging.WindowsClient
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Le ContactDataSet contenant les addresses de destinations enregistrées.
        /// </summary>
        private ContactDataSet ds;

        /// <summary>
        /// Background worker utilisé lors d'un démarrage de session.
        /// </summary>
        private BackgroundWorker _bw;

        /// <summary>
        /// Ligne sélectionné lors d'un démarrage de conversation.
        /// </summary>
        private int _rowSelected;

        /// <summary>
        /// Map contenant toutes les fenetres de conversations.
        /// </summary>
        private Dictionary<int, ConversationForm> _dicConv;

        /// <summary>
        /// Constructeur de la fenetre.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ds = new XmlContactManager().Load();
            if (ds == null)
                ds = new ContactDataSet();
            dataGridView1.DataMember = "Contacts";
            dataGridView1.DataSource = ds;
            dataGridView1.Focus();

            _dicConv = new Dictionary<int, ConversationForm>();
            for (int i = 0; i < dataGridView1.RowCount; ++i )
            {
                _dicConv.Add(i,null);
            }

            _bw = new BackgroundWorker();
            _bw.DoWork += openConversation;
        }

        /// <summary>
        /// Methode appelé lorsque la fenetre est fini de charger.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainWindows_Load(Object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Méthode appelé lors du click sur une cellule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Méthode appelé lors du double click sur une cellule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(!_bw.IsBusy)
            {
                _rowSelected = e.RowIndex;
                _bw.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Fonction appelé par le backgroundWorker qui initialise une conversation et crée la fenètre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void openConversation(object sender, DoWorkEventArgs e)
        {
            if (_dicConv[_rowSelected] == null)
            {
                toolStripStatusLabel1.Text = "Initializing Session...";
                SessionController.GetInstance().initialize();
                //Update();
                Invoke(new Action(delegate()
                {
                    ConversationForm conv = new ConversationForm(SessionController.MY_NAME, ds.Contacts[_rowSelected].Name);
                    _dicConv[_rowSelected] = conv;
                    conv.Show();
                }));
                toolStripStatusLabel1.Text = "Loading completed.";
            }
            else
            {
                Invoke(new Action(delegate()
                {
                    _dicConv[_rowSelected].Focus();
                }));
            }
        }

        /// <summary>
        /// Méthode levé lorsque l'on clique sur le bouton add dans la barre de menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            AddContact ac = new AddContact();
            if (ac.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ds.Contacts.AddContactsRow(ac.Address_Text_Box.Text, ac.Name_Text_Box.Text);
                dataGridView1.Focus();
                _dicConv.Add(dataGridView1.RowCount-1,null);
            }
            
        }

        /// <summary>
        /// Méthode levé lorsque l'on clique sur le bouton save dans la barre de menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            new XmlContactManager().Save(ds);
        }

        /// <summary>
        /// Méthode levé lorsque l'on clique sur le bouton refresh dans la barre de menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, EventArgs e)
        {
            ds = new XmlContactManager().Load();
            if (ds == null)
                ds = new ContactDataSet();
            dataGridView1.DataMember = "Contacts";
            dataGridView1.DataSource = ds;
        }

        /// <summary>
        /// Méthode levé lorsque l'on clique sur le bouton remove dans la barre de menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            ds.Clear();
            foreach(int key in _dicConv.Keys)
            {
                if(_dicConv[key] != null)
                {
                    _dicConv[key].Close();
                }
            }
            _dicConv.Clear();
        }

    }
}
