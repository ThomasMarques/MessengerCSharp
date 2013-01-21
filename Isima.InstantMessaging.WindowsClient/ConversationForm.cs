using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Isima.InstantMessaging.Messaging;

namespace Isima.InstantMessaging.WindowsClient
{
    public partial class ConversationForm : Form
    {
        private String _receiver;
        private String _sender;
        private SessionController _session;

        private readonly static Font BOLD = new Font("Georgia", 9, FontStyle.Bold);
        private readonly static Font ITALIC = new Font("Georgia", 8, FontStyle.Italic);

        public ConversationForm(String sender, String receiver)
        {
            InitializeComponent();
            _receiver = receiver;
            _sender = sender;
            this.Text = receiver;
            this.sendText.KeyUp += new KeyEventHandler(this.sendText_KeyUp);
            _session = new SessionController();
            _session.initialize();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            send();
        }

        private void sendText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                send();
            }
        }

        private void send()
        {
            this.Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            sendText.Enabled = false;

            Messaging.Message mess = new Messaging.Message(_sender, _receiver, sendText.Text);
            _session.send(mess);

            richTextConv.SelectionFont = BOLD;
            richTextConv.SelectionColor = Color.DarkBlue;
            richTextConv.SelectedText += _sender + "  ["+mess.Instant.ToString("HH:mm")+"]";

            richTextConv.SelectionFont = ITALIC;
            richTextConv.SelectionColor = Color.Blue;
            richTextConv.SelectedText += Environment.NewLine + mess.Content;

            sendText.Clear();
            sendText.Enabled = true;
            button1.Enabled = true;
            this.Cursor = Cursors.Arrow;
        }
    }
}
