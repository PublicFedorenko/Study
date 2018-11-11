using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities.MyLinkedList
{
    public class Node<T> 
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }

        public Node(T value)
        {
            Value = value;
        } 

        public override string ToString() => Value.ToString();
    }
}
