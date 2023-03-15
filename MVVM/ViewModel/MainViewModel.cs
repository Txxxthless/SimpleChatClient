using ChatClient.Core;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChatClient.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        private StreamReader? _reader;
        private StreamWriter? _writer;
        private TcpClient? _tcpClient;
        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        private string _message;
        private SendMessageCommand _sendMessageCommand;


        public SendMessageCommand MessageCommand => _sendMessageCommand;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }
        public StreamReader? Reader => _reader;
        public StreamWriter? Writer => _writer;
        public ObservableCollection<string> Messages => _messages;


        public MainViewModel()
        {
            _sendMessageCommand = new SendMessageCommand(this);

            _tcpClient = new TcpClient();

            try
            {
                _tcpClient.Connect("127.0.0.1", 8888);
                _reader = new StreamReader(_tcpClient.GetStream());
                _writer = new StreamWriter(_tcpClient.GetStream());

                Task.Run(() => ReceiveMessage());
            }
            catch
            {

            }
        }

        public void SendMessage()
        {
            Writer.WriteLine(Message);
            Writer.Flush();
            Messages.Add(Message);
        }

        public async Task ReceiveMessage()
        {
            while(true)
            {
                try
                {
                    string message = Reader.ReadLine();
                    if (string.IsNullOrEmpty(message)) continue;
                    App.Current.Dispatcher.Invoke(
                        () =>
                        {
                            Messages.Add(message);
                        });
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
