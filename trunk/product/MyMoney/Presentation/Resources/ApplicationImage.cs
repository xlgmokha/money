using System;
using System.Drawing;
using System.IO;
using MyMoney.Infrastructure.Extensions;

namespace MyMoney.Presentation.Resources
{
    public class ApplicationImage : IDisposable
    {
        private readonly string name_of_the_image;
        private readonly Image underlying_image;

        public ApplicationImage(string name_of_the_image)
        {
            this.name_of_the_image = name_of_the_image;
            underlying_image = Image.FromFile(FullPathToTheFile(this));
        }

        public static implicit operator Image(ApplicationImage image_to_convert)
        {
            return image_to_convert.underlying_image;
        }

        private string FullPathToTheFile(ApplicationImage image_to_convert)
        {
            return Path.Combine(image_to_convert.startup_directory() + @"\images", image_to_convert.name_of_the_image);
        }

        public void Dispose()
        {
            underlying_image.Dispose();
        }
    }
}