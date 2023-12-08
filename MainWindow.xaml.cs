using Microsoft.Win32;
using PiScripter.Commands;
using PiScripter.FileReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PiScripter
{
  
    public partial class MainWindow : Window
    {
        private static string pathFile = "C:\\Users\\jedominguez\\Documents\\Neumont Career\\Quarter 8\\Programming Languages\\AssemblyTxt.txt";
        Reader reader = new Reader();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            Nullable<bool> open = openFile.ShowDialog();

            openFile.Title = "Select a Text File";
            openFile.Filter = "Text files (*.txt)|*.txt";

            if (open == true)
            {
                pathFile = openFile.FileName;
            }
            reader.Execute(pathFile);

        }

        private void CreateAssembly_Click(object sender, RoutedEventArgs e)
        {
            reader.Execute(pathFile);
        }
    }
}
