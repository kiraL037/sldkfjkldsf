using System;

namespace principle_Tell_Don_t_Ask
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessage[] messages = new IMessage[] { new VoiceMessage(Array.Empty<byte>(), "tom", "sam"), new TextMessage("Hello", "sam", "tom") };
            foreach (var message in messages)
            {
                message.Launch();
            }
        }
    }
}
    interface IMessage
    {
        string Sender { get; }
        string Receiver { get; }
        void Launch();
    }
    class TextMessage : IMessage
    {
        public string Sender { get; }
        public string Receiver { get; }
        public string Text { get; }
        public TextMessage(string text, string sender, string receiver)
        {
            Text = text;
            Receiver = receiver;
            Sender = sender;
        }
        private void Print() => Console.WriteLine($"Текстовое сообщение: {Text}");
        public void Launch() => Print();
    }

class VoiceMessage : IMessage
{
    public string Sender { get; }
    public string Receiver { get; }
    public byte[] Voice { get; }
    public VoiceMessage(byte[] voice, string sender, string receiver)
    {
        Voice = voice;
        Receiver = receiver;
        Sender = sender;
    }
    private void Play() => Console.WriteLine($"Воспроизведение голосового сообщения");
    public void Launch() => Play();
}

