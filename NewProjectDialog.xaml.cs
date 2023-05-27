
using System;
using System.Windows;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProjectOrganizer
{
    public partial class NewProjectWindow: Window
    {
        string projectPath;
        string projectName;
        public NewProjectWindow()
        {
            InitializeComponent();
        }

        private void NewProjectOpenExplorer(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            projectPath = dialog.SelectedPath;
        }

        private void NewProjectAddClicked(object sender, RoutedEventArgs e)
        {
            // Store projectPath and projectName to SQLite
        }

        private void NewProjectCancelClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NameFieldChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (ProjectName.Text == "")
            {
                ImageBrush textImgBrush = new ImageBrush();
                textImgBrush.ImageSource = new BitmapImage(
                    new Uri(@"TextBoxBackground.gif", UriKind.Relative));
                textImgBrush.AlignmentX = AlignmentX.Left;
                textImgBrush.Stretch = Stretch.None;
                ProjectName.BorderBrush = textImgBrush;
            }
            else
            {
                ProjectName.Background = null;
            }
        }
    }
}