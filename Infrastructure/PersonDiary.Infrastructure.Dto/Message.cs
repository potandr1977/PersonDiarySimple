namespace PersonDiary.Infrastructure.Dto
{
    //Сообщение которые получает клиент в ответе из бизнес логики
    public class Message
    {
        public Message() { }
        
        public Message(string text)
        {
            this.Type = MessageTypeEnum.Error;
            this.Text = text;
        }
        
        private string Text { get; }
        
        private MessageTypeEnum Type { get;  }
    }
}
