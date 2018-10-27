using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Entities;
using BusinessLogicLayer.Formats;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class TeacherDataHandler : BaseDataHandler, IEnumerable
    {
        public Teacher[] Teachers;

        public delegate bool ConditionDelegate(Teacher st);

        public TeacherDataHandler(string filePath)
        {
            LoadTeachers(filePath);
        }

        public void LoadTeachers(string filePath)
        {
            IFormat format = GetFormat(filePath);
            IDataAccessor dataAccessor = new TextDataAccessor(filePath);
            ObjectHandler<Teacher> teacherHandler = new ObjectHandler<Teacher>(dataAccessor, format);
            Teachers = teacherHandler.Construct();
        }

        public void SaveTeachers(string filePath, FileMode fileMode)
        {
            IFormat iFormat = GetFormat(filePath);
            IDataAccessor iDataAccessor = new TextDataAccessor(filePath);
            ObjectHandler<Teacher> teacherHandler = new ObjectHandler<Teacher>(iDataAccessor, iFormat);
            teacherHandler.Deconstruct(Teachers, fileMode);
        }

        public void Remove(string internalId)
        {
            Teachers = Teachers.Where(val => val.InternalId != internalId).ToArray();
        }

        public void Remove(int index)
        {
            if (index < 0 || index > Teachers.Length - 1)
                throw new IndexOutOfRangeException();

            Teacher[] buff = new Teacher[Teachers.Length - 1];
            for (int i = 0, j = 0; i < Teachers.Length; i++)
            {
                if (i != index)
                    buff[j++] = Teachers[i];
            }
            Teachers = buff;
        }

        public void Add(Teacher st)
        {
            Array.Resize(ref Teachers, Teachers.Length + 1);
            Teachers[Teachers.Length - 1] = st;
        }

        public Teacher[] Find(ConditionDelegate condition)
        {
            int count = 0;
            foreach (var teacher in Teachers)
            {
                if (condition(teacher))
                    count++;
            }

            if (count == 0)
                return null;

            Teacher[] foundTeachers = new Teacher[count];
            int i = 0;
            foreach (var teacher in Teachers)
            {
                if (condition(teacher))
                    foundTeachers[i++] = teacher;
            }

            return foundTeachers;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Teachers.GetEnumerator();
        }
    }
}
