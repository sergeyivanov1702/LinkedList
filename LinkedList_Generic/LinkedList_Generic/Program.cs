using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }

    //реализация обобщенного двусвязного списка
    class LinkedList<T> : System.Collections.Generic.ICollection<T>
    {
        private Node<T> tail;
        private Node<T> head;

        public void AddFisrt(T value)
        {
            Node<T> _node = new Node<T>(value);

            if (Count == 0)
            {
                Head = _node;
                Tail = _node;
            }
            else
            {
                Head.Previous = _node;
                _node.Next = Head;
                Head = _node;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> _node = new Node<T>(value);

            if (Count == 0)
            {
                Tail = _node;
                Head = _node;
            }
            else
            {
                Tail.Next = _node;
                _node.Previous = Tail;
                Tail = _node;
            }

            Count++;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }

                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {


                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    Tail = Tail.Previous;
                    Tail.Next = null;
                }

                Count--;
            }
        }

        public bool Remove(T _value)
        {
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(_value))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            Tail = current.Previous;
                        }
                        else
                        {
                            current.Next.Previous = current.Previous;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public bool Contains(T item)
        {
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            Node<T> current = Head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }



        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public void PrintList()
        {
            if (Count == 0)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            Node<T> node = Head;

            while (node != null)
            {
                Console.Write(node.Value + " ");
                node = node.Next;
            }
            Console.WriteLine();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Count { get; private set; }

        public Node<T> Tail
        {
            get { return tail; }
            private set { tail = value; }
        }

        public Node<T> Head
        {
            get { return head; }
            private set { head = value; }
        }
    }


    class Student
    {
        public Student(uint age, string name, string group)
        {
            Age = age;
            Name = name;
            Group = group;
        }

        public uint Age { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }


        public override string ToString()
        {
            return "Name: " + Name + "\nAge: " + Age + "\nGroup" + Group + "\n\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student st = (Student)obj;

            return (Age == st.Age) && (Name == st.Name) && (Group == st.Group);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> intList = new LinkedList<int>();
            LinkedList<string> strList = new LinkedList<string>();
            LinkedList<Student> stdList = new LinkedList<Student>();


            stdList.Add(new Student(3, "Vasya", "odin_33"));
            stdList.Add(new Student(4, "Petya", "odin_44"));
            stdList.AddFisrt(new Student(2, "Kolya", "odin_22"));
            stdList.AddFisrt(new Student(1, "Oleg", "odin_11"));
            stdList.AddFisrt(new Student(0, "Sergey", "odin_00"));
            stdList.AddLast(new Student(5, "Jerry", "odin_55"));
            stdList.PrintList();

            Console.WriteLine("\n\n\n\n");

            stdList.Remove(new Student(3, "Vasya", "odin_33"));
            stdList.RemoveFirst();
            stdList.RemoveLast();
            stdList.PrintList();

            stdList.Clear();
        }
    }
}
