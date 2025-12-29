using GeminiChatBot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        private GeminiService _geminiService;
        public Form1()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            InitializeComponent();
            
            string myApiKey = "YOUR_GEMINI_API_KEY_HERE";
            _geminiService = new GeminiService(myApiKey);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {

            string userText = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(userText)) return;

            // 1. Kullanıcının mesajını ekrana yaz ve kutuyu temizle
            rtbChat.AppendText($"Siz: {userText}\n");
            txtMessage.Clear();

            // 2. Durumu güncelle (Kullanıcı botun çalıştığını anlasın)
            lblStatus.Text = "Bot yanıt veriyor...";
            btnSend.Enabled = false;

            // 3. Botun cevabını al (Oluşturduğumuz servisi kullanıyoruz)
            string botResponse = await _geminiService.GetResponseAsync(userText);

            // 4. Botun cevabını ekrana yaz
            rtbChat.AppendText($"Bot: {botResponse}\n\n");

            // 5. Durumu eski haline getir
            lblStatus.Text = "Hazır";
            btnSend.Enabled = true;

            // Sohbet ekranını en aşağı kaydır
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();
        
    }
    }
}
