using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Heap<T> where T : IHeapItem<T>
{
    private T[] items;
    private int currentItemCount = 0;

    public Heap(int maxHeapSize)
    {
        items = new T[maxHeapSize];
    }
    public void Add(T item)
    {
        item.HeapIndex = currentItemCount;
        items[currentItemCount] = item;
        SortUp(item);
        currentItemCount++;
    }
    public T RemoveFirst()
    {
        T firstItem = items[0];
        currentItemCount--;
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return firstItem;
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
    }

    public int Count
    {
        get
        {
            return currentItemCount;
        }
    }

    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }

    public void SortDown(T item)
    {
        while (true)
        {
            int childLeftIndex = item.HeapIndex * 2 + 1;                                // Get index of left child
            int childRightIndex = item.HeapIndex * 2 + 2;                               // Get index of right child
            int swapIndex = 0;

            if (childLeftIndex < currentItemCount)                                      // Check to see if left child exists
            {
                swapIndex = childLeftIndex;                                             // if yes, set swapindex to left child
                if (childRightIndex < currentItemCount)                                 // Check to see if right child exists
                {
                    if (items[childLeftIndex].CompareTo(items[childRightIndex]) < 0)    // if yes check to see which child has higher priority
                    {
                        swapIndex = childRightIndex;                                    // if right has higher priority, set swap index to right child
                    }
                }
                if (item.CompareTo(items[swapIndex]) < 0)                               // Check if item has lower priority than selected child
                {
                    Swap(item, items[swapIndex]);                                       // If yes, swap child with parent
                }
                else
                {
                    return;                                                             // Else items are in correct place
                }
            }
            else
            {
                return;
            }
        }
    }

    public void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex - 1) / 2;
        while (true)
        {
            T parentItem = items[parentIndex];
            if (item.CompareTo(parentItem) > 0)
            {
                Swap(parentItem, item);
            }
            else
            {
                break;
            }
            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }
    public void Swap(T itemA, T itemB)
    {
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;
        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }
}
public interface IHeapItem<T> : IComparable<T>
{
    int HeapIndex
    {
        get;
        set;
    }
}
