using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Isima.InstantMessaging.Messaging;
using Isima.InstantMessaging.Text;

namespace Isima.InstantMessaging.WindowsClient
{
    public partial class ConversationForm : Form
    {
        private string receiverAddress;

        private static Font headerFont = new Font("Arial", 10, FontStyle.Bold);
        private static Color headerColor = Color.DarkBlue;
        private static Font messageFont = new Font("Arial", 10);
        private static Color messageColor = Color.Blue; 

        public ConversationForm(string receiverAddress)
        {
            MessagingContext.Current.MessagingSessionController.MessageReceived += new EventHandler<MessageEventArgs>(sessionController_MessageReceived);

            InitializeComponent();

            this.receiverAddress = receiverAddress;
        }

        private void ConversationForm_Load(object sender, EventArgs e)
        {
            this.Text = this.receiverAddress;
            txtMessage.Focus();
        }

        void sessionController_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.MessageData.SenderAddress == this.receiverAddress)
            {
                this.Invoke(new Action<Messaging.Message> (this.DisplayMessage), e.MessageData);
            }
        }

        private void DisplayMessage(Messaging.Message message)
        {
            string header = string.Format("{0} [{1}]:\n", message.SenderAddress, message.Instant.ToShortTimeString());
            string content = Sanitizer.Sanitize(Sanitizer.NeutralizeUrl(message.Content));

            int headerStart = rtbConversation.TextLength;
            rtbConversation.AppendText(header);
            rtbConversation.Select(headerStart, header.Length);
            rtbConversation.SelectionColor = headerColor;
            rtbConversation.SelectionFont = headerFont;

            int contentStart = rtbConversation.TextLength;
            rtbConversation.AppendText(content);
            rtbConversation.Select(contentStart, content.Length);
            rtbConversation.SelectionColor = messageColor;
            rtbConversation.SelectionFont = messageFont;

            rtbConversation.AppendText("\n");
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Messaging.Message message = new Messaging.Message()
                {
                    SenderAddress = MessagingContext.Current.SenderAddress,
                    ReceiverAddress = receiverAddress,
                    Instant = DateTime.Now,
                    Content = Sanitizer.Sanitize(txtMessage.Text)
                };
                DisplayMessage(message);

                txtMessage.Text = string.Empty;
                txtMessage.Refresh();

                while (bgwSender.IsBusy)
                {
                    Application.DoEvents();
                }
                bgwSender.RunWorkerAsync(message);

                e.Handled = true;
            }
        }

        private void bgwSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is Messaging.Message)
                MessagingContext.Current.MessagingSessionController.Send(((Messaging.Message)e.Argument));
        }
    }
}
