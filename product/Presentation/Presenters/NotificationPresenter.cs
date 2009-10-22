using System.Text;
using System.Windows.Forms;
using gorilla.commons.utility;

namespace momoney.presentation.presenters
{
    public class NotificationPresenter : Notification
    {
        public void notify(params NotificationMessage[] messages)
        {
            var builder = new StringBuilder();
            messages.each(x => builder.AppendLine(x));
            MessageBox.Show(builder.ToString(), "Ooops...", MessageBoxButtons.OK);
        }
    }
}