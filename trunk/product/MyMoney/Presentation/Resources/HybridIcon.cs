using System.Drawing;

namespace MoMoney.Presentation.Resources
{
    public class HybridIcon : ApplicationIcon
    {
        private readonly Image underlying_image;

        public HybridIcon(string name_of_the_icon) : base(name_of_the_icon)
        {
            if (icon_can_be_found()) {
                underlying_image = Image.FromFile(find_full_path_to(this));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            if (underlying_image != null) underlying_image.Dispose();
        }

        public static implicit operator Image(HybridIcon icon_to_convert)
        {
            return icon_to_convert.underlying_image;
        }
    }
}