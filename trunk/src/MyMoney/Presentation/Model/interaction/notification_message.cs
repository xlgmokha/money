namespace MyMoney.Presentation.Model.interaction
{
    public class notification_message
    {
        private readonly string the_message_to_display;

        public notification_message(string the_message_to_display)
        {
            this.the_message_to_display = the_message_to_display;
        }

        public static implicit operator string(notification_message message)
        {
            return message.ToString();
        }

        public static implicit operator notification_message(string message)
        {
            return new notification_message(message);
        }

        public override string ToString()
        {
            return the_message_to_display;
        }

        public bool Equals(notification_message obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.the_message_to_display, the_message_to_display);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (notification_message)) return false;
            return Equals((notification_message) obj);
        }

        public override int GetHashCode()
        {
            return (the_message_to_display != null ? the_message_to_display.GetHashCode() : 0);
        }
    }
}