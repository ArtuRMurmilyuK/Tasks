using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfChatClient
{
   

    public partial class MainWindow : Window
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string serverAddress = IpServerTextBox.Text; // Адреса сервера
            int serverPort = 8888; // Порт сервера
            string userName = UserNameTextBox.Text;

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(serverAddress, serverPort);
                

                Stream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };

                await writer.WriteLineAsync(userName);

                _ = Task.Run(ReceiveMessages);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private async Task ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    string message = await reader.ReadLineAsync();
                    if (message != null)
                    {
                        this.Dispatcher.Invoke(() => { ChatTextBox.AppendText(message + Environment.NewLine); });
                    }
                }
            }
            catch (IOException)
            {
                this.Dispatcher.Invoke(() => { ChatTextBox.AppendText("Сервер відключився." + Environment.NewLine); });
            }
        }

        private async void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = InputTextBox.Text;
            await writer.WriteLineAsync(message);
            ChatTextBox.AppendText($"Ви: {message}{Environment.NewLine}");
            InputTextBox.Text = "";
        }
    }
}

