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
    public partial class NewContactForm : Form
    {
        public NewContactForm()
        {
            InitializeComponent();
        }

        public string Address
        {
            get { return textBox1.Text; }
        }

        public string DisplayName
        {
            get { return textBox2.Text; }
        }
    }
}
