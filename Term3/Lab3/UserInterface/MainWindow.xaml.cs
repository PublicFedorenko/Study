using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services.Services;
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



namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, EventArgs e)
        {
            #region SerializationTypes
            ComboBox_SerializationType.SelectedIndex = 0;
            ComboBox_SerializationType.Items.Add("—Select file type—");
            ComboBox_SerializationType.Items.Add(".xml");
            ComboBox_SerializationType.Items.Add(".json");
            ComboBox_SerializationType.Items.Add(".bin");
            #endregion

            #region EntityTypes
            ComboBox_EntityType.SelectedIndex = 0;
            ComboBox_EntityType.Items.Add("—Select type—");
            ComboBox_EntityType.Items.Add("Product");
            #endregion
        }

        private void Button_Read_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text + ComboBox_SerializationType.SelectedItem.ToString();
            switch (ComboBox_SerializationType.SelectedItem.ToString())
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
            }
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            string filePath = TextBox_FilePath.Text + ComboBox_SerializationType.SelectedItem.ToString();
            switch (ComboBox_SerializationType.SelectedItem.ToString())
            {
                case ".xml":
                    {
                        switch (ComboBox_EntityType.SelectedItem.ToString())
                        {
                            case "Product":
                                {
                                    XmlSerializationService<List<Product>> xmlService = new XmlSerializationService<List<Product>>();
                                    xmlService.Write((List<Product>) DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
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
                                    jsonService.Write((List<Product>) DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
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
                                    binService.Write((List<Product>) DataGrid_Main.ItemsSource, filePath, System.IO.FileMode.Truncate);
                                }
                                break;
                        }
                    }
                    break;
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
    }
}
