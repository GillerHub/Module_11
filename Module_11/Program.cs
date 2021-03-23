using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Module_11
{
    public static class BotCredentials
    {
        public static readonly string BotToken = "1669123713:AAFN41UctuddQEpkIGYcI1Kai53Oo-g68kI";
    }
    public class Messenger
        {
        /*public string CreateTextMessage(Conversation chat)
        {

        }
        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }*/
    }
    public class BotMessageLogic
    {
        public BotMessageLogic(ITelegramBotClient botClient)
        {
            /*messanger = new Messenger();
            chatList = new Dictionary<long,
            Conversation>();
            this.botClient = botClient;*/
        }

    }
    public class BotWorker
    {
        private ITelegramBotClient botClient;
        public BotMessageLogic logic;
        public void Initialaze()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken);
            //logic = new BotMessageLogic();
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                chatId: e.Message.Chat, text: "Вы написали:\n" + e.Message.Text);
            }
        }
    }

    public class Conversation
    {
        /*private Chat telegramChat;

        private List<Message> telegramMessages;

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            await SendTextMessage(chat);

        }
        private async Task SendTextMessage(Conversation chat)
        {
            var text = messanger.CreateTextMessage(chat);

            await botClient.SendTextMessageAsync(
            chatId: chat.GetId(), text: text);
        }
        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }*/
    }

    class Program
    {

        static void Main(string[] args)
        {
            var bot = new BotWorker();

            bot.Initialaze();
            bot.Start();

            Console.WriteLine("Нажмите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();
            }
            while (command != "stop");

            bot.Stop();

        }
        
    }
}
