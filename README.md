This class library is developed in C#, it provides 5 implemenations of Priority Queue.

------------ Added Implementations ---------------

1. Unordered Array
2. Sorted Array
3. Unordered Linked List
4. Sorted Linked List
5. Binary Heap

-------------------------------------------------

Each class has the following :

Add(Item, Priority) - Insert item and its priority
Head() - Get the highest priority item
Remove() - Removes the highest priority item
isEmpty() - Check if the queue has any items within it

--------------------------------------------------

All testing is carried out via NUnit. There are 40 tests total, with 8 per implemenetation.

They test a range of things from :

1. Does the queue start empty
2. Does it throw an overflow error if it goes over it's allocated memory

-------------------------------------------------
