using System;

namespace Interface_Segregation_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FromAddress");
            Console.ReadLine();
            Console.WriteLine("ToAddress");
            Console.ReadLine();
            Console.WriteLine("Send a message");
            VoiceMessage p = new VoiceMessage();
            p.Send();
            EmailMessage v = new EmailMessage();
            v.Send();
            SmsMessage j = new SmsMessage();
            j.Send();
        }
    }
    interface IMessage
    {
        void Send();
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }
    interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }
    interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }

    interface IEmailMessage : ITextMessage
    {
        string Subject { get; set; }
    }

    class VoiceMessage : IVoiceMessage
    {
        public string ToAddress { get; set; } = "";
        public string FromAddress { get; set; } = "";

        public byte[] Voice { get; set; } = Array.Empty<byte>();
        public void Send() => Console.WriteLine("Передача голосовой почты");
    }
    class EmailMessage : IEmailMessage
    {
        public string Text { get; set; } = Console.ReadLine();
        public string Subject { get; set; } = "";
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";

        public void Send() => Console.WriteLine($"Отправляем по Email сообщение: {Text}");
    }

    class SmsMessage : ITextMessage
    {
        public string Text { get; set; } = Console.ReadLine();
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public void Send() => Console.WriteLine($"Отправляем по Sms сообщение: {Text}");
    }

}
