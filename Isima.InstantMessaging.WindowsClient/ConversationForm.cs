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
        /// <summary>
        /// Addresse du destinataire.
        /// </summary>
        private String _receiver;
        /// <summary>
        /// Addresse de l'expéditeur.
        /// </summary>
        private String _sender;
        
        /// <summary>
        /// Permet l'encodage d'un texte en base 64.
        /// </summary>
        private Base64Encoder _base64;
        /// <summary>
        /// Permet de nétoyer un texte.
        /// </summary>
        private Sanitizer _sani;

        /// <summary>
        /// Font gras utilisée pour afficher les addresses.
        /// </summary>
        private readonly static Font BOLD = new Font("Georgia", 9, FontStyle.Bold);
        /// <summary>
        /// Font italic utilisée pour afficher les contenus du messages.
        /// </summary>
        private readonly static Font ITALIC = new Font("Georgia", 8, FontStyle.Italic);

        /// <summary>
        /// Constructeur initialisant les différents attributs.
        /// </summary>
        /// <param name="sender">Addresse de l'expéditeur.</param>
        /// <param name="receiver">Addresse du destinataire.</param>
        public ConversationForm(String sender, String receiver)
        {
            InitializeComponent();

            _sani = new Sanitizer();
            _base64 = new Base64Encoder();

            SessionController.GetInstance()._sendMessageEvent += new EventHandler<MessageEventArgs>(this.MessageReceived);

            _receiver = receiver;
            _sender = sender;
            this.Text = receiver;
            this.sendText.KeyUp += new KeyEventHandler(this.sendText_KeyUp);
        }

        /// <summary>
        /// Methode levé lors de la réception d'un message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public void MessageReceived(object sender, MessageEventArgs message)
        {
            if (message.Mess.SenderAdress.Equals(_receiver))
            {

                richTextConv.SelectionFont = BOLD;
                richTextConv.SelectionColor = Color.DarkRed;
                richTextConv.SelectedText += Environment.NewLine + _sender + "  [" + message.Mess.Instant.ToString("HH:mm") + "]";

                richTextConv.SelectionFont = ITALIC;
                richTextConv.SelectionColor = Color.Red;
                richTextConv.SelectedText += Environment.NewLine + message.Mess.Content;
            }
        }

        /// <summary>
        /// Méthode levé lors du click sur le bouton d'envoi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            send();
        }

        /// <summary>
        /// Méthode levé lorsqu'une touche est appuyé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                send();
            }
        }

        /// <summary>
        /// Permet l'envoi d'un message.
        /// </summary>
        private void send()
        {
            this.Cursor = Cursors.WaitCursor;
            button1.Enabled = false;
            sendText.Enabled = false;

            Messaging.Message mess = new Messaging.Message(_sender, _receiver, _sani.Sanitize(_sani.NeutralizeUrl(sendText.Text)));

            if (richTextConv.Text.Length > 0)
                richTextConv.SelectedText += Environment.NewLine;

            richTextConv.SelectionFont = BOLD;
            richTextConv.SelectionColor = Color.DarkBlue;
            richTextConv.SelectedText += _sender + "  [" + mess.Instant.ToString("HH:mm") + "]";

            richTextConv.SelectionFont = ITALIC;
            richTextConv.SelectionColor = Color.Blue;
            richTextConv.SelectedText += Environment.NewLine + mess.Content;

            sendText.Clear();
            sendText.Enabled = true;
            button1.Enabled = true;
            this.Cursor = Cursors.Arrow;

            Update();

            SessionController.GetInstance().send(mess);
        }
    }
}
