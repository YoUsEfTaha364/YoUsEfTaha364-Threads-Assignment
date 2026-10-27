# Assignment 05 — Answers

Student name:  
Group / ID:

## Failures you observed

- observed that it is trying add the same key to dictionary this is wrong 
- race condition between checking the queue and dequeuing an email job

## What you changed

- use ConcurrentDictionary -> manipulate multiple threads 
- use ConcurrentQueue -> only one thread can dequeue safely 

## Collection safety vs business-rule safety

- This means a collection can safely handle simultaneous operations from multiple threads
  wthout corrupting its internal state 
- This means your application preserves its actual requirements
