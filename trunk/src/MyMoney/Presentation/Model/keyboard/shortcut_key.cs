using System.Windows.Forms;

namespace MyMoney.Presentation.Model.keyboard
{
    public class shortcut_key
    {
        private readonly Keys key;

        public shortcut_key(Keys key)
        {
            this.key = key;
        }

        public shortcut_key and(shortcut_key other_key)
        {
            return new shortcut_key(key | other_key.key);
        }

        public static implicit operator Keys(shortcut_key key_to_convert)
        {
            return key_to_convert.key;
        }
    }
}