using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labiki678
{
    //будь ты проклят, OurList D:
    class OurList<T>:IEnumerable<T>
    {
        Node<T> head; // головной/первый элемент
        Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public int IndexOf(T data)
        {
            Node<T> current = head;
            int i = 0;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return i;
                current = current.Next;
                i++;
            }
            return -1;
        }
        public void Insert(T data, int position)
        {
            Node<T> node = new Node<T>(data);
            Node<T>? prev = null;
            Node<T>? next = null;

            Node<T> current = head;
            int i = 0;
            while (current != null)
            {
                if(i==position)
                {
                    prev= current;
                }
                else if (i == position + 1)
                {
                    next=current;
                    prev.Next = node;
                    node.Next=next;
                }
                current = current.Next;
                i++;
            }
        }
        // добавление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = head;
            Node<T> previous = null;
            int i = 0;

            while (current != null && i < index)
            {
                previous = current;
                current = current.Next;
                i++;
            }

            if (current == null)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (previous == null)
                head = current.Next;
            else
                previous.Next = current.Next;

            if (current.Next == null)
                tail = previous;

            count--;
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
