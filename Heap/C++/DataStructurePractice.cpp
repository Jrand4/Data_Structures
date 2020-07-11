// DataStructurePractice.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
using namespace std;
class Heap {
private:
	int * items;
	int currentSize;
	int maxSize;
public:
	Heap(int _maxSize);
	int parent(int i) { return (i - 1) / 2; }
	int leftChild(int i) { return (i * 2) + 1; }
	int rightChild(int i) { return (i * 2) + 2; }
	int removeFirst();
	void add(int k);
	void swap(int *x, int * y);
};

Heap::Heap(int _max) {
	currentSize = 0;
	maxSize = _max;
	items = new int[maxSize];
}

void Heap::add(int k) {
	if (currentSize == maxSize)
		return;
	currentSize++;
	int i = currentSize - 1;
	items[i] = k;
	while (i != 0 && items[parent(i)] > items[i]) {
		swap(&items[parent(i)], &items[i]);
		i = parent(i);
	}
}

int Heap::removeFirst() {
	int i = 0;
	int swapIndex = 0;
	int v = items[i];
	items[i] = items[currentSize - 1];
	currentSize--;
	while (true) {
		if (leftChild(i) < currentSize) {
			swapIndex = leftChild(i);
			if (rightChild(i) < currentSize && items[leftChild(i)] > items[rightChild(i)]) {
				swapIndex = rightChild(i);
			}
			if (items[i] > items[swapIndex]) {
				swap(&items[i], &items[swapIndex]);
				i = swapIndex;
			}
			else {
				break;
			}
		}
		else {
			break;
		}
	}
	return v;
}

void Heap::swap(int * a, int * b) {
	int t = *a;
	*a = *b;
	*b = t;
}

int main()
{
	Heap heap = Heap(10);
	heap.add(9);
	heap.add(7);
	heap.add(5);
	heap.add(3);
	heap.add(1);
	heap.add(10);
	heap.add(8);
	heap.add(6);
	heap.add(4);
	heap.add(2);

	for (int i = 0; i < 10; i++)
	{
		int v = heap.removeFirst();
		cout << v << "\n";
	}
    
}
