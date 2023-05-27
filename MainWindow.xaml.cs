using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;

namespace ProjectOrganizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        Window addProjectWindow = new NewProjectWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnNewClick(object sender, RoutedEventArgs e)
        {
            addProjectWindow.Show();
        }

        private void ProjectListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
 