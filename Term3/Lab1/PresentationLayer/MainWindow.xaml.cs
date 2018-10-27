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
using BusinessLogicLayer;
using BusinessEntities.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window        //TODO RENAME ALL BUTTONS AND BUTTON CLICKS
    {
        StudentDataHandler studentDataHandler;
        TeacherDataHandler teacherDataHandler;
        FileMode fileMode;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Load
        {
            string comboBoxValue = Regex.Match(Entity_ComboBox.SelectedValue.ToString(), @"(?<=: )\w+").Value;
            switch (comboBoxValue)
            {
                case "Student":
                    {
                        Entity_ComboBox.IsEnabled = false;
                        studentDataHandler = new StudentDataHandler(FilePath_Box.Text);
                        MainDataGrid.ItemsSource = studentDataHandler.Students;
                        break;
                    }
                case "Teacher":
                    {
                        Entity_ComboBox.IsEnabled = false;
                        teacherDataHandler = new TeacherDataHandler(FilePath_Box.Text);
                        MainDataGrid.ItemsSource = teacherDataHandler.Teachers;
                        break;
                    }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)   // save
        {
            string comboBoxValue = Regex.Match(Entity_ComboBox.SelectedValue.ToString(), @"(?<=: )\w+").Value;
            switch (comboBoxValue)
            {
                case "Student":
                    {
                        studentDataHandler.SaveStudents(FilePath_Box.Text, fileMode);
                        break;
                    }
                case "Teacher":
                    {
                        teacherDataHandler.SaveTeachers(FilePath_Box.Text, fileMode);
                        break;
                    }
            }
            
        }

        private void RButton_Truncate_Checked(object sender, RoutedEventArgs e)
        {
            fileMode = FileMode.Truncate;
        }

        private void RButton_Append_Checked(object sender, RoutedEventArgs e)
        {
            fileMode = FileMode.Append;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)   //ADD
        {
            if (MainDataGrid.ItemsSource == null)
                return;

            string comboBoxValue = Regex.Match(Entity_ComboBox.SelectedValue.ToString(), @"(?<=: )\w+").Value;
            switch (comboBoxValue) {
                case "Student":
                    {
                        List<Student> s = studentDataHandler.Students.ToList();
                        s.Add(new Student());
                        studentDataHandler.Students = s.ToArray();
                        MainDataGrid.ItemsSource = studentDataHandler.Students;
                        break;
                    }
                case "Teacher":
                    {
                        List<Teacher> t = teacherDataHandler.Teachers.ToList();
                        t.Add(new Teacher());
                        teacherDataHandler.Teachers = t.ToArray();
                        MainDataGrid.ItemsSource = teacherDataHandler.Teachers;
                        break;
                    }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)   //REMOVE
        {
            string comboBoxValue = Regex.Match(Entity_ComboBox.SelectedValue.ToString(), @"(?<=: )\w+").Value;
            switch (comboBoxValue)
            {
                case "Student":
                    {
                        List<Student> s = studentDataHandler.Students.ToList();
                        if (MainDataGrid.SelectedIndex != -1)
                        {
                            s.RemoveAt(MainDataGrid.SelectedIndex);
                            studentDataHandler.Students = s.ToArray();
                            MainDataGrid.ItemsSource = studentDataHandler.Students;
                        }
                        break;
                    }
                case "Teacher":
                    {
                        List<Teacher> t = teacherDataHandler.Teachers.ToList();
                        if (MainDataGrid.SelectedIndex != -1)
                        {
                            t.RemoveAt(MainDataGrid.SelectedIndex);
                            teacherDataHandler.Teachers = t.ToArray();
                            MainDataGrid.ItemsSource = teacherDataHandler.Teachers;
                        }
                        break;
                    }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainDataGrid.ItemsSource = null;
            Entity_ComboBox.IsEnabled = true;
        }
    }
}
