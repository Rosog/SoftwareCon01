# Priority Queue Class Library - Assessment 1 Starting Repo

This repository serves as the starting repository for **Assessment 1** of the **BSc Computing** program at the **University of the Highlands and Islands (UHI)**. 
This repository is part of the module **UG409765 - Software Construction** and serves as the foundation for the Priority Queue class library assignment.

## **Overview**
This repository provides the initial codebase for the Priority Queue class library. Students are tasked with completing and extending this codebase by 
implementing four additional Priority Queue data structures, thoroughly testing them, and reflecting on the development process. 

---

## **Repository Structure**

- `Person.cs`: A class used as a type for testing priority queues with the provided driver program.
- `PriorityItem.cs`: A class representing individual items within the priority queue. It includes properties for the item and its priority.
- `PriorityQueue.cs`: An interface defining the required methods for all Priority Queue implementations. This interface must not be modified.
- `QueueManager.cs`: A driver program implemented as a Windows Form application. It allows users to interact with and test different Priority Queue implementations.
- `QueueOverflowException.cs`:  A custom exception class for handling scenarios where the queue exceeds its defined capacity.
- `QueueUnderflowException.cs`: A custom exception class for handling scenarios where an operation is attempted on an empty queue.
- `SortedArrayPriorityQueue.cs`: A complete implementation of the Priority Queue using a sorted array. This serves as an example and a reference for creating additional implementations.

---

## **Submission**
1. Fork this repository and work on your own copy.
2. Push all changes to your forked repository.
3. Please don't create public clones containing solutions.

---

## **Important Notes**
- Keep track of your development process using Git version control.
- Regularly commit your progress with meaningful and descriptive messages.
- Refer to the assessment brief for detailed requirements and marking criteria.

### **Contact**
For any issues or questions, please reach out to your module instructor.