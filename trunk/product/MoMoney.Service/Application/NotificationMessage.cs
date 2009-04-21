namespace MoMoney.Service.Application
{
    public class NotificationMessage
    {
        private readonly string the_message_to_display;

        public NotificationMessage(string the_message_to_display)
        {
            this.the_message_to_display = the_message_to_display;
        }

        public static implicit operator string(NotificationMessage message)
        {
            return message.ToString();
        }

        public static implicit operator NotificationMessage(string message)
        {
            return new NotificationMessage(message);
        }

        public override string ToString()
        {
            return the_message_to_display;
        }

        public bool Equals(NotificationMessage obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.the_message_to_display, the_message_to_display);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NotificationMessage)) return false;
            return Equals((NotificationMessage) obj);
        }

        public override int GetHashCode()
        {
            return (the_message_to_display != null ? the_message_to_display.GetHashCode() : 0);
        }
    }
}