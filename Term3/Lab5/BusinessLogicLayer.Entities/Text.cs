using BusinessLogicLayer.Entities.MyLinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer.Entities
{
    public class Text
    {
        public delegate Row RowSelector(Row row1, Row row2);

        private MyLinkedList<Row> rows;

        public MyLinkedList<Row> Rows { get => rows; set => rows = value; }

        public void AddRow(string value)
        {
            Rows.Add(new Row(value));
        }

        public void RemoveRow(int index)
        {
            if (index < 0 || index > Rows.Count)
                throw new IndexOutOfRangeException();

            Rows.RemoveAt(index);
        }

        public Row Find(RowSelector selector)
        {
            if (Rows.Count < 0)
                throw new InvalidOperationException();

            Row desiredRow = Rows[0];
            for (int i = 0; i < Rows.Count; i++)
                desiredRow = selector(desiredRow, Rows[i]);
            return desiredRow;
        }

        public int GetPercentOf(Regex regex)
        {
            if (Rows.Count == 0)
                throw new InvalidOperationException();

            int count = 0;
            foreach (Row row in Rows)
                count += regex.Matches(row.Data).Count;
            return count;
        }

        public void Clear()
        {
            Rows.Clear();
        }
    }
}
