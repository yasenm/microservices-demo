using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Messaging;

namespace MediaApi.Infra
{
    public class MessageHandler : IMessageHandlerCallback
    {
        IMessageHandler _messageHandler;

        public MessageHandler(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            var asd = MessageSerializer.Deserialize(message);
            string logMessage = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffffff")} - {message}{Environment.NewLine}";
            Serilog.Log.Information("{MessageType} - {Body}", messageType, message);
            return true;
        }
    }

    class Asd
    {
        public string asd { get; set; }
    }
}
