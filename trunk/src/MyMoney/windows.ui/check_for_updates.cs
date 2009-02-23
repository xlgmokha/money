using System.Deployment.Application;
using System.Windows.Forms;
using MyMoney.Infrastructure.Extensions;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    public class check_for_updates : ICommand
    {
        private readonly ApplicationDeployment deployment;

        public check_for_updates()
        {
            if (!ApplicationDeployment.IsNetworkDeployed) {
                return;
            }
            deployment = ApplicationDeployment.CurrentDeployment;
        }

        public void run()
        {
            if (null == deployment) {
                return;
            }
            if (deployment.IsFirstRun) {
                this.log().debug("this is the first time the application is run");
                MessageBox.Show("It looks like this is the first time you've used this application", "Welcome");
                return;
            }
            if (deployment.CheckForUpdate()) {
                MessageBox.Show("Looks like there are updates...", "Updates are available");
                this.log().debug("starting_update");
                deployment.Update();
                this.log().debug("update completed");
                MessageBox.Show("Updates were downloaded. The application will restart now", "Restarting application");
                Application.Restart();
                this.log().debug("restarting application");
            }
        }
    }
}