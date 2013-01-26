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
    public partial class AddContact : Form
    {
        /// <summary>
        /// Constructeur de la fenetre.
        /// </summary>
        public AddContact()
        {
            InitializeComponent();
        }

        public void textChanged(object sender, EventArgs e)
        {
            if (Name_Text_Box.Text.Length == 0 || Address_Text_Box.Text.Length == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
