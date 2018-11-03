using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string defaultPath = System.IO.Path
            .GetFullPath(System.IO.Path
            .Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, EventArgs e)
        {
            #region EntityTypes
            ComboBox_EntityType.SelectedIndex = 0;
            ComboBox_EntityType.Items.Add("—Select type—");
            ComboBox_EntityType.Items.Add("Product");
            #endregion

            #region DefaultFilePath
            TextBox_FilePath.Text = defaultPath;
            #endregion
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text;
            Regex regEx = new Regex(@"(?<=.+)\..+");    // *.fileFormat
            string format = regEx.Match(TextBox_FilePath.Text).Value;
            switch (format)
            {
                case ".xml":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    XmlSerializationService<List<Product>> xmlService = new XmlSerializationService<List<Product>>();
                                    DataGrid_Main.ItemsSource = xmlService.Read(filePath, System.IO.FileMode.Open);
                                }
                                break;
                        }
                    }
                    break;
                case ".json":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    JsonSerializationService<List<Product>> jsonService = new JsonSerializationService<List<Product>>();
                                    DataGrid_Main.ItemsSource = jsonService.Read(filePath, System.IO.FileMode.Open);
                                }
                                break;
                        }
                    }
                    break;
                case ".bin":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    BinarySerializationService<List<Product>> binService = new BinarySerializationService<List<Product>>();
                                    DataGrid_Main.ItemsSource = binService.Read(filePath, System.IO.FileMode.Open);
                                }
                                break;
                        }
                    }
                    break;
                    //TODO add default with exception
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text;
            Regex regEx = new Regex(@"(?<=.+)\..+");    // *.fileFormat
            string format = regEx.Match(TextBox_FilePath.Text).Value;
            switch (format)
            {
                case ".xml":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    XmlSerializationService<List<Product>> xmlService = new XmlSerializationService<List<Product>>();
                                    xmlService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
                                }
                                break;
                        }
                    }
                    break;
                case ".json":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    JsonSerializationService<List<Product>> jsonService = new JsonSerializationService<List<Product>>();
                                    jsonService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
                                }
                                break;
                        }
                    }
                    break;
                case ".bin":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    BinarySerializationService<List<Product>> binService = new BinarySerializationService<List<Product>>();
                                    binService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
                                }
                                break;
                        }
                    }
                    break;
                    //TODO add default with exception
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            var items = DataGrid_Main.ItemsSource;
            items = null;
            DataGrid_Main.ItemsSource = items;
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.Exists(TextBox_FilePath.Text) ? TextBox_FilePath.Text : defaultPath;
            openFileDialog.Filter = "Storage Files (*.xml, *.json, *.bin, *.custom) | *.xml;*.json;*.bin;*.custom";
            openFileDialog.ShowDialog();
            TextBox_FilePath.Text = openFileDialog.FileName;
        }
    }
}
