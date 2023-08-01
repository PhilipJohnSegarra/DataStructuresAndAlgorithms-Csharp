using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// A generic singly linked list implementation.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the linked list.</typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T>? HeadNode { get; set; }
        private static Node<T>? CurrentNode { get; set; }

        /// <summary>
        /// Adds a new node with the specified value to the end of the linked list.
        /// </summary>
        /// <param name="newValue">The value of the new node.</param>
        public void Add(T newValue)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node<T> { Value = newValue, Next = null };
            }
            else
            {
                CurrentNode = HeadNode;
                while (CurrentNode.Next != null)
                {
                    CurrentNode = CurrentNode.Next;
                }
                CurrentNode.Next = new Node<T> { Value = newValue, Next = null };
            }
        }

        /// <summary>
        /// Adds a new node with the specified value after the first occurrence of the existing value in the linked list.
        /// </summary>
        /// <param name="existingValue">The value after which the new node will be inserted.</param>
        /// <param name="newValue">The value of the new node.</param>
        public void AddAfter(T existingValue, T newValue)
        {
            if(HeadNode != null)
            {
                CurrentNode = HeadNode;
                while(!CurrentNode.Value.Equals(existingValue))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        return;
                    }
                }
                CurrentNode.Next = new Node<T> { Value =  newValue, Next = CurrentNode.Next };
            }
            return;
        }

        /// <summary>
        /// Adds a new node with the specified value before the first occurrence of the existing value in the linked list.
        /// If the existing value is not found, the new node is not added.
        /// </summary>
        /// <param name="existingValue">The value before which the new node will be inserted.</param>
        /// <param name="newValue">The value of the new node.</param>
        public void AddBefore(T existingValue, T newValue)
        {
            if (HeadNode != null)
            {
                Node<T> prevNode = new();
                if (HeadNode.Value.Equals(existingValue))
                {
                    var newNode = new Node<T> { Value = newValue, Next = HeadNode };
                    HeadNode = newNode;
                }
                else
                {
                    CurrentNode = HeadNode;
                    while (!CurrentNode.Value.Equals(existingValue))
                    {
                        prevNode = CurrentNode;
                        CurrentNode = CurrentNode.Next;
                    }
                    prevNode.Next = new Node<T> { Value = newValue, Next = CurrentNode };
                }
            }
            return;
        }

        /// <summary>
        /// Updates the value of the first node containing the old value with the new value.
        /// If the old value is not found, no update is performed.
        /// </summary>
        /// <param name="oldValue">The value to be updated.</param>
        /// <param name="newValue">The new value to be set.</param>
        public void Update(T? oldValue, T? newValue)
        {
            if (HeadNode != null)
            {
                CurrentNode = HeadNode;
                while (!CurrentNode.Value.Equals(oldValue))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        break;
                    }
                }
                CurrentNode.Value = newValue;
            }
            return;
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the linked list.
        /// If the value is not found, no removal is performed.
        /// </summary>
        /// <param name="value">The value to be removed.</param>
        public void Remove(T? value)
        {
            if(HeadNode != null)
            {
                CurrentNode = HeadNode;
                Node<T>? nodeToBeDeleted;
                Node<T>? nodeToAppend;
                if (CurrentNode.Value.Equals(value))
                {
                    HeadNode = null;
                    return;
                }
                while (!CurrentNode.Next.Value.Equals(value))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        break;
                    }
                }
                nodeToBeDeleted = CurrentNode.Next;
                if(nodeToBeDeleted.Next != null)
                {
                    nodeToAppend = nodeToBeDeleted.Next;
                    CurrentNode.Next = nodeToAppend;
                }
                else
                {
                    CurrentNode.Next = null;
                }
            }
            return;
        }

        /// <summary>
        /// Checks if the linked list contains the specified value.
        /// </summary>
        /// <param name="value">The value to be searched for.</param>
        /// <returns>True if the value is found; otherwise, false.</returns>
        public bool Contains(T? value)
        {
            if(HeadNode != null)
            {
                CurrentNode = HeadNode;
                while (!CurrentNode.Value.Equals(value))
                {
                    CurrentNode = CurrentNode.Next;
                    if(CurrentNode == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Returns the number of nodes in the linked list.
        /// </summary>
        /// <returns>The number of nodes in the linked list.</returns>
        public int GetLength()
        {
            int count = 0;
            CurrentNode = HeadNode;
            while(CurrentNode != null)
            {
                CurrentNode = CurrentNode.Next;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Reverses the order of nodes in the linked list.
        /// </summary>
        public void Reverse()
        {
            if (HeadNode == null || HeadNode.Next == null)
            {
                return;
            }

            Node<T>? previousNode = null;
            CurrentNode = HeadNode;
            Node<T>? nextNode;

            while (CurrentNode != null)
            {
                nextNode = CurrentNode.Next;
                CurrentNode.Next = previousNode;
                previousNode = CurrentNode;
                CurrentNode = nextNode;
            }

            HeadNode = previousNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            CurrentNode = HeadNode;
            while (CurrentNode != null)
            {
                yield return CurrentNode.Value;
                CurrentNode = CurrentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Represents a node in the linked list.
    /// </summary>
    /// <typeparam name="T">The type of the value stored in the node.</typeparam>
    public class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next = null;
    }
}
