using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BusinessEntities.Entities;
using BusinessLogicLayer.Formats;
using DataAccessLayer;
using System.Text.RegularExpressions;
using System.Collections;

namespace BusinessLogicLayer
{
    public class StudentDataHandler : BaseDataHandler, IEnumerable
    {
        public Student[] Students;
        
        public delegate bool ConditionDelegate(Student st);

        public StudentDataHandler(string filePath)
        {
            LoadStudents(filePath);
        }

        public void LoadStudents(string filePath)
        {
            IFormat format = GetFormat(filePath);
            IDataAccessor dataAccessor = new TextDataAccessor(filePath);
            ObjectHandler<Student> studentHandler = new ObjectHandler<Student>(dataAccessor, format);
            Students = studentHandler.Construct();
        }

        public void SaveStudents(string filePath, FileMode fileMode)
        {
            IFormat iFormat = GetFormat(filePath);
            IDataAccessor iDataAccessor = new TextDataAccessor(filePath);
            ObjectHandler<Student> studentHandler = new ObjectHandler<Student>(iDataAccessor, iFormat);
            studentHandler.Deconstruct(Students, fileMode);
        }

        public void Remove(string studentId)
        {
            Students = Students.Where(val => val.StudentId != studentId).ToArray();
        }

        public void Remove(int index)
        {
            if (index < 0 || index > Students.Length - 1)
                throw new IndexOutOfRangeException();

            Student[] buff = new Student[Students.Length - 1];
            for (int i = 0, j = 0; i < Students.Length; i++)
            {
                if (i != index)
                    buff[j++] = Students[i]; 
            }
            Students = buff;
        }

        public void Add(Student st)
        {
            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length - 1] = st;
        }

        public Student[] Find(ConditionDelegate condition)
        {
            int count = 0;
            foreach (var student in Students)
            {
                if (condition(student))
                    count++;
            }

            if (count == 0)
                return null;

            Student[] foundStudents = new Student[count];
            int i = 0;
            foreach (var student in Students)
            {
                if (condition(student))
                    foundStudents[i++] = student;
            }

            return foundStudents;
        }

        public Student[] FindStudentsAccordingToTask()  //TODO вынести в UI и передать в делегат
        {
            int count = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Gender.ToLower() == "female" &&
                    Students[i].Course == 5 &&
                    Math.Abs(Students[i].AverageGrade - 5.0) < 0.005)
                {
                    count++;
                }
            }

            Student[] foundStudents = new Student[count];
            for (int i = 0, index = 0; i < Students.Length; i++)
            {
                if (Students[i].Gender.ToLower() == "female" &&
                    Students[i].Course == 5 &&
                    Math.Abs(Students[i].AverageGrade - 5.0) < 0.005)
                {
                    foundStudents[index++] = Students[i];
                }
            }

            return foundStudents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Students.GetEnumerator();
        }
    }
}
