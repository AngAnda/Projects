using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

public static class FileManager
{
    public static string SaveImage()
    {
        try
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFilePath = openFileDialog.FileName; 

                string resourcesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

                if (!Directory.Exists(resourcesDirectory))
                {
                    Directory.CreateDirectory(resourcesDirectory);
                }

                string fileName = Path.GetFileName(sourceFilePath); 
                string destinationFilePath = Path.Combine(resourcesDirectory, fileName);

                if (File.Exists(destinationFilePath))
                {
                    return $"./Resources/{fileName}"; 
                }


                File.Copy(sourceFilePath, destinationFilePath, true);

                MessageBox.Show($"The image has been saved in {destinationFilePath}!", "Succesful saving", MessageBoxButton.OK, MessageBoxImage.Information);

                string relativeUriPath = $"./Resources/{fileName}";
                return relativeUriPath;

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error has been encounterd: {ex.Message}", "Saving Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        return null;
    }
}
