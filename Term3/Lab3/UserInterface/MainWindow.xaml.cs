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

        private void Button_Open_Click(object sender, RoutedEventArgs e)
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
                                    if (new FileInfo(filePath).Length != 0)
                                        _products = xmlService.Read(filePath, MainConfig.FileReadMode);
                                    DataGrid_Main.ItemsSource = _products;
                                }
                                break;
                            case "Student":
                                {
                                    XmlSerializationService<List<Student>> xmlService = new XmlSerializationService<List<Student>>();
                                    if (new FileInfo(filePath).Length != 0)
                                        _students = xmlService.Read(filePath, MainConfig.FileReadMode);
                                    DataGrid_Main.ItemsSource = _students;
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
                                    if (new FileInfo(filePath).Length != 0)
                                        _products = jsonService.Read(filePath, MainConfig.FileReadMode);
                                    DataGrid_Main.ItemsSource = _products;
                                }
                                break;
                            case "Student":
                                {
                                    JsonSerializationService<List<Student>> jsonService = new JsonSerializationService<List<Student>>();
                                    if (new FileInfo(filePath).Length != 0)
                                        _students = jsonService.Read(filePath, MainConfig.FileReadMode);
                                    DataGrid_Main.ItemsSource = _students;
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
                                    if (new FileInfo(filePath).Length != 0)
                                        _products = binService.Read(filePath, MainConfig.FileReadMode);
                                    DataGrid_Main.ItemsSource = _products;
                                }
                                break;
                            case "Student":
                                {
                                    BinarySerializationService<List<Student>> binService = new BinarySerializationService<List<Student>>();
                                    if (new FileInfo(filePath).Length != 0)
                                        _students = binService.Read(filePath, MainConfig.FileReadMode);
                                }
                                break;
                        }
                    }
                    break;
                    //TODO add default with exception
            }

            Button_Open.IsEnabled = false;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text;

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
                                    xmlService.Write((List<Product>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
                                }
                                break;
                            case "Student":
                                {
                                    XmlSerializationService<List<Student>> xmlService = new XmlSerializationService<List<Student>>();
                                    xmlService.Write((List<Student>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
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
                                    JsonSerializationService<List<Student>> jsonService = new JsonSerializationService<List<Student>>();
                                    jsonService.Write((List<Student>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);
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
                                    BinarySerializationService<List<Student>> binService = new BinarySerializationService<List<Student>>();
                                    binService.Write((List<Student>)DataGrid_Main.ItemsSource, filePath, MainConfig.FileWriteMode);

                                }
                                break;
                        }
                    }
                    break;
                    //TODO add default with exception
            }
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Main.ItemsSource = null;
            MainConfig.CurrentEntity = null;
            Button_Open.IsEnabled = true;
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
            Button_Open.IsEnabled = isDefaultType && selectedEntity != MainConfig.CurrentEntity; 
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            switch (MainConfig.CurrentEntity)
            {
                case "Product":
                    {
                        DataGrid_Main.ItemsSource = null;
                        _products.Add(new Product());
                        DataGrid_Main.ItemsSource = _products;
                    }
                    break;
                case "Student":
                    {
                        DataGrid_Main.ItemsSource = null;
                        _students.Add(new Student());
                        DataGrid_Main.ItemsSource = _students;
                    }
                    break;
            }
        }

        private void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            switch (MainConfig.CurrentEntity)
            {
                case "Product":
                    {
                        _products.RemoveAt(DataGrid_Main.SelectedIndex);
                        DataGrid_Main.ItemsSource = null;
                        DataGrid_Main.ItemsSource = _products;
                    }
                    break;
                case "Student":
                    {
                        _students.RemoveAt(DataGrid_Main.SelectedIndex);
                        DataGrid_Main.ItemsSource = null;
                        DataGrid_Main.ItemsSource = _students;
                    }
                    break;
            }
        }
    }
}
