using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    /// <summary>
    /// Represents a Doubly Linked List data structure that stores elements of type T.
    /// </summary>
    /// <typeparam name="T">The data type of elements to be stored in the list.</typeparam>
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private DLLNode<T>? HeadNode { get; set; }
        private DLLNode<T>? CurrentNode { get; set; }

        /// <summary>
        /// Adds a new node with the specified data to the end of the doubly linked list.
        /// If the list is empty, the data will become the head node.
        /// </summary>
        /// <param name="data">The value of type T to be added to the list.</param>
        /// <returns>A Result object indicating whether the operation was successful, along with a relevant message.</returns>
        public Result Add(T? data)
        {
            try
            {
                if (HeadNode != null)
                {
                    if (HeadNode.Next == null)
                    {
                        HeadNode.Next = new DLLNode<T>(HeadNode, data, null);
                        return new Result(true, $"{data} has been added.");
                    }
                    else
                    {
                        CurrentNode = HeadNode;
                        while (CurrentNode.Next != null)
                        {
                            CurrentNode = CurrentNode.Next;
                        }
                        CurrentNode.Next = new DLLNode<T>(CurrentNode, data, null);
                        return new Result(true, $"{data} has been added.");
                    }
                }
                HeadNode = new DLLNode<T>(null, data, null);
                return new Result(false, $"{data} has been added");
            }
            catch
            {
                return new Result(false, $"Adding of {data} unsuccessful.");
            }
        }

        /// <summary>
        /// Adds a new node with the specified newValue after the first occurrence of existingValue in the doubly linked list.
        /// If existingValue is not found, the operation is considered unsuccessful.
        /// </summary>
        /// <param name="existingValue">The value of type T after which the new node will be added.</param>
        /// <param name="newValue">The value of type T to be added to the list.</param>
        /// <returns>A Result object indicating whether the operation was successful, along with a relevant message.</returns>
        public Result AddAfter(T existingValue, T newValue)
        {
            if (HeadNode != null)
            {
                try
                {
                    CurrentNode = HeadNode;
                    while (!CurrentNode.Value.Equals(existingValue))
                    {
                        CurrentNode = CurrentNode.Next;
                        if(CurrentNode == null)
                        {
                            return new Result(false, $"{existingValue} not found.");
                        }
                    }
                    DLLNode<T> newNode = new DLLNode<T>(CurrentNode, newValue, CurrentNode.Next);
                    CurrentNode.Next = newNode;
                    CurrentNode.Next.Next.Previous = newNode;
                    return new Result(true, $"{newValue} has been added after {existingValue}.");
                }
                catch (Exception ex)
                {
                    return new Result(false, $"Adding of {newValue} has been unsuccessful.");
                }
            }
            return new Result(false, $"Adding of {newValue} has been unsuccessful.");
        }

        /// <summary>
        /// Adds a new node with the specified newValue before the first occurrence of existingValue in the doubly linked list.
        /// If existingValue is not found, the operation is considered unsuccessful.
        /// </summary>
        /// <param name="existingValue">The value of type T before which the new node will be added.</param>
        /// <param name="newValue">The value of type T to be added to the list.</param>
        /// <returns>A Result object indicating whether the operation was successful, along with a relevant message.</returns>
        public Result AddBefore(T existingValue, T newValue)
        {
            if (HeadNode != null)
            {
                try
                {
                    if(HeadNode.Value.Equals(existingValue))
                    {
                        DLLNode<T> newNode = new DLLNode<T>(null, newValue, HeadNode);
                        HeadNode.Previous = newNode;
                        HeadNode = newNode;
                        return new Result(true, $"{newValue} has been added before {existingValue}.");
                    }
                    else
                    {
                        CurrentNode = HeadNode;
                        while (!CurrentNode.Value.Equals(existingValue))
                        {
                            CurrentNode = CurrentNode.Next;
                            if (CurrentNode == null)
                            {
                                return new Result(false, $"{existingValue} not found.");
                            }
                        }
                        DLLNode<T> newNode = new DLLNode<T>(CurrentNode.Previous, newValue, CurrentNode);
                        DLLNode<T> prev = CurrentNode.Previous;
                        prev.Next = newNode;
                        CurrentNode.Previous = newNode;
                        return new Result(true, $"{newValue} has been added before {existingValue}.");
                    }
                }
                catch (Exception ex)
                {
                    return new Result(false, $"Adding of {newValue} unsuccessful: {ex.Message}"); 
                }

            }
            return new Result(false, $"Adding of {newValue} unsuccessful");
        }

        /// <summary>
        /// Updates the value of the first occurrence of oldValue in the doubly linked list with newValue.
        /// If oldValue is not found, the operation is considered unsuccessful.
        /// </summary>
        /// <param name="oldValue">The current value of type T to be updated.</param>
        /// <param name="newValue">The new value of type T to replace the old value.</param>
        /// <returns>A Result object indicating whether the operation was successful, along with a relevant message.</returns>
        public Result Update(T? oldValue, T? newValue)
        {
            if (HeadNode != null)
            {
                CurrentNode = HeadNode;
                while (!CurrentNode.Value.Equals(oldValue))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        return new Result(false, $"{oldValue} not found");
                    }
                }
                CurrentNode.Value = newValue;
                return new Result(true, $"{oldValue} updated to {newValue}");
            }
            return new Result(false, $"Update unsuccessful: list is empty");

        }

        /// <summary>
        /// Removes the first occurrence of value from the doubly linked list.
        /// If value is not found, the operation is considered unsuccessful.
        /// </summary>
        /// <param name="value">The value of type T to be removed from the list.</param>
        /// <returns>A Result object indicating whether the operation was successful, along with a relevant message.</returns>
        public Result Remove(T? value)
        {
            if (HeadNode != null)
            {
                CurrentNode = HeadNode;
                DLLNode<T>? nodeToBeDeleted;
                DLLNode<T>? nodeToAppend;
                if (CurrentNode.Value.Equals(value))
                {
                    HeadNode = CurrentNode.Next;
                    CurrentNode = null;
                    return new Result(true, $"{value} has been removed");
                }
                while (!CurrentNode.Value.Equals(value))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        return new Result(false, $"{value} has not been found");
                    }
                }
                if(CurrentNode.Next == null)
                {
                    CurrentNode.Previous.Next = null;
                    return new Result(true, $"{value} has been removed");
                }
                else
                {
                    nodeToBeDeleted = CurrentNode;
                    nodeToAppend = nodeToBeDeleted.Next;
                    nodeToBeDeleted.Previous.Next = nodeToAppend;
                    nodeToAppend.Previous = nodeToBeDeleted.Previous;
                    return new Result(true, $"{value} has been removed");
                }
            }
            return new Result(false, "List is empty");
        }

        /// <summary>
        /// Checks if the doubly linked list contains a node with the specified data.
        /// </summary>
        /// <param name="data">The value of type T to search for in the list.</param>
        /// <returns>
        /// A Result object indicating whether the operation was successful and if the data exists in the list.
        /// If the data is found, the Result object contains a success status (true) and a message indicating the matching value.
        /// If the data is not found, the Result object contains a failure status (false) and a message indicating the absence of the data.
        /// If the list is empty, the Result object contains a failure status (false) and a message indicating that the list is empty.
        /// </returns>
        public Result Contains(T? data)
        {
            if (HeadNode != null)
            {
                CurrentNode = HeadNode;
                while (!CurrentNode.Value.Equals(data))
                {
                    CurrentNode = CurrentNode.Next;
                    if (CurrentNode == null)
                    {
                        return new Result(false, $"{data} does not exist in the list");
                    }
                }
                return new Result(true, $"{CurrentNode.Value} matches with the search value: {data}");
            }
            return new Result(false, "List is empty");
        }

        /// <summary>
        /// Reverses the order of nodes in the doubly linked list.
        /// </summary>
        /// <returns>
        /// A Result object indicating the outcome of the operation.
        /// If the list is successfully reversed, the Result object contains a success status (true) and a message confirming the reversal.
        /// If the list contains only one item, the Result object contains a failure status (false) and a message stating that the operation is unnecessary.
        /// If the list is empty, the Result object contains a failure status (false) and a message indicating that the list is empty.
        /// </returns>
        public Result Reverse()
        {
            if(HeadNode != null)
            {
                DLLNode<T> tail = HeadNode;
                if(HeadNode.Next == null)
                {
                    return new Result(false, "Unnecessary Operation: list contains 1 item");
                }
                else
                {
                    CurrentNode = HeadNode;
                    DLLNode<T>? prev;
                    DLLNode<T>? next;
                    DLLNode<T>? head;

                    while (CurrentNode.Next != null)
                    {
                        CurrentNode = CurrentNode.Next;
                    }
                    head = CurrentNode;
                    HeadNode = head;
                    prev = CurrentNode.Next;
                    next = CurrentNode.Previous;
                    CurrentNode.Next = next;
                    CurrentNode.Previous = prev;
                    while (CurrentNode.Next != null)
                    {
                        if (CurrentNode == tail)
                        {
                            return new Result(true, "List has been reversed");
                        }
                        CurrentNode = CurrentNode.Next;
                        prev = CurrentNode.Next;
                        next = CurrentNode.Previous;
                        CurrentNode.Next = next;
                        CurrentNode.Previous = prev;
                    }
                    return new Result(true, "List has been reversed");
                }
            }
            return new Result(false, "list is empty");
        }

        /// <summary>
        /// Returns the number of nodes in the linked list.
        /// </summary>
        /// <returns>
        /// An integer representing the number of nodes in the linked list.
        /// </returns>
        public int GetLength()
        {
            int count = 0;
            CurrentNode = HeadNode;
            while (CurrentNode != null)
            {
                CurrentNode = CurrentNode.Next;
                count++;
            }
            return count;
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
    /// Represents a node of the Doubly Linked List data structure.
    /// Each node contains a value of type T and has references to the previous and next nodes in the list.
    /// </summary>
    /// <typeparam name="T">The data type of the node value.</typeparam>
    public class DLLNode<T>
    {
        public DLLNode<T>? Previous { get; set; }
        public T? Value { get; set; }
        public DLLNode<T>? Next { get; set;}

        /// <summary>
        /// Initializes a new instance of the DLLNode class with the specified previous, value, and next nodes.
        /// </summary>
        /// <param name="previous">The reference to the previous node in the list.</param>
        /// <param name="value">The value of the current node.</param>
        /// <param name="next">The reference to the next node in the list.</param>
        public DLLNode(DLLNode<T>? previous, T? value, DLLNode<T>? next)
        {
            Previous = previous;
            Value = value;
            Next = next;
        }
    }

    /// <summary>
    /// Represents the result of an operation performed in the Doubly Linked List data structure.
    /// It contains information about whether the operation was successful (IsSuccess) and an optional message (Message) explaining the outcome.
    /// </summary>
    public struct Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the Result struct with the specified success status and message.
        /// </summary>
        /// <param name="isSuccess">Indicates whether the operation was successful (true) or not (false).</param>
        /// <param name="message">The message providing additional information about the operation result.</param>
        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
