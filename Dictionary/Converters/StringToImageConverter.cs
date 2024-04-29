
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Dictionary.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imagePath && !string.IsNullOrEmpty(imagePath))
            {
                Uri imageUri;
                if (imagePath.StartsWith("pack://"))
                {
                    imageUri = new Uri(imagePath, UriKind.Absolute);
                }
                else
                {
                    string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "Resources");

                    string fullPath = Path.Combine(basePath, imagePath.Replace('/', Path.DirectorySeparatorChar));

                    imageUri = new Uri(fullPath, UriKind.Absolute);
                }

                return new BitmapImage(imageUri);

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
