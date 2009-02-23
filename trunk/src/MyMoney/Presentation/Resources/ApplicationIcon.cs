using System;
using System.Drawing;
using System.IO;
using MyMoney.Infrastructure.Extensions;

namespace MyMoney.Presentation.Resources
{
    public class ApplicationIcon : IDisposable
    {
        private readonly Icon underlying_icon;

        public ApplicationIcon(string name_of_the_icon)
        {
            this.name_of_the_icon = name_of_the_icon;
            if (icon_can_be_found()) {
                ApplicationIcons.add(this);
                underlying_icon = new Icon(find_full_path_to(this));
            }
        }

        public string name_of_the_icon { get; private set; }

        public virtual void Dispose()
        {
            if (underlying_icon != null) underlying_icon.Dispose();
        }

        public static implicit operator Icon(ApplicationIcon icon_to_convert)
        {
            return icon_to_convert.underlying_icon;
        }

        protected string find_full_path_to(ApplicationIcon icon_to_convert)
        {
            return Path.Combine(icon_to_convert.startup_directory() + @"\icons", icon_to_convert.name_of_the_icon);
        }

        protected bool icon_can_be_found()
        {
            var path_to_the_icon = find_full_path_to(this);
            return File.Exists(path_to_the_icon);
        }
    }
}