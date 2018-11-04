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
        private readonly Config MainConfig;
        private List<Product> _products;
        private List<Student> _students;

        public MainWindow()
        {
            InitializeComponent();
            MainConfig = new Config();
            _products = new List<Product>();
            _students = new List<Student>();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region EntityTypes
            ComboBox_EntityType.SelectedIndex = 0;
            ComboBox_EntityType.Items.Add("—Select type—");
            ComboBox_EntityType.Items.Add("Product");
            ComboBox_EntityType.Items.Add("Student");
            #endregion

            #region DefaultFilePath
            TextBox_FilePath.Text = MainConfig.DefaultPath;
            #endregion
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text;    //TODO add check if filePath is valid
            MainConfig.CurrentEntity = ComboBox_EntityType.SelectedItem.ToString();

            #region ParseFileFormat
            Regex regEx = new Regex(@"(?<=.+)\..+");    // *.fileFormat
            string format = regEx.Match(TextBox_FilePath.Text).Value;
            #endregion

            switch (format)
            {
                case ".xml":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    XmlSerializationService<List<Product>> xmlService = new XmlSerializationService<List<Product>>();
                                    DataGrid_Main.ItemsSource = xmlService.Read(filePath, MainConfig.FileReadMode);
                                }
                                break;
                            case "Student":
                                {
                                    XmlSerializationService<List<Student>> xmlService = new XmlSerializationService<List<Student>>();
                                    DataGrid_Main.ItemsSource = xmlService.Read(filePath, MainConfig.FileReadMode);
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
                                    DataGrid_Main.ItemsSource = jsonService.Read(filePath, MainConfig.FileReadMode);
                                }
                                break;
                            case "Student":
                                {
                                    JsonSerializationService<List<Student>> jsonService = new JsonSerializationService<List<Student>>();
                                    DataGrid_Main.ItemsSource = jsonService.Read(filePath, MainConfig.FileReadMode);
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
                                    DataGrid_Main.ItemsSource = binService.Read(filePath, MainConfig.FileReadMode);
                                }
                                break;
                            case "Student":
                                {

                                }
                                break;
                        }
                    }
                    break;
                    //TODO add default with exception
            }

            Button_Read.IsEnabled = false;
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
                                    xmlService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
                                }
                                break;
                            case "Student":
                                {

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
                                    jsonService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
                                }
                                break;
                            case "Student":
                                {

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
                                    binService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
                                }
                                break;
                            case "Student":
                                {

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
            openFileDialog.InitialDirectory = Directory.Exists(TextBox_FilePath.Text) ? TextBox_FilePath.Text : MainConfig.DefaultPath;
            openFileDialog.Filter = "Storage Files (*.xml, *.json, *.bin, *.custom) | *.xml;*.json;*.bin;*.custom";
            openFileDialog.ShowDialog();
            TextBox_FilePath.Text = openFileDialog.FileName;
        }

        private void ComboBox_EntityType_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedEntity = ComboBox_EntityType.SelectedItem.ToString();
            bool isDefaultType = Convert.ToBoolean(ComboBox_EntityType.SelectedIndex);
            Button_Read.IsEnabled = isDefaultType && selectedEntity != MainConfig.CurrentEntity; 
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
