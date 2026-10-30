# Assignment 01 — Answers

Student name:  
Group / ID:

## Problems with the current design

## 1. Blocking Operations

**Problem:**

The original program used `Thread.Sleep()` to simulate delays. This blocks the current thread while waiting, preventing it from doing other useful work.




## 2. Sequential Processing

**Problem:**

The program processed orders one by one. Each order had to finish before the next order could start, making the export slow when there were many orders.

## What you changed

**Solution:**

I replaced `Thread.Sleep()` with `Task.Delay()` and used asynchronous file operations such as `File.ReadAllTextAsync()` and `File.WriteAllTextAsync()`.

This allows the thread to be used for other work while asynchronous operations are waiting.


**Solution:**

I used `async` and `await` for asynchronous operations and `Task.WhenAll()` to process multiple orders concurrently.

This allows independent orders to make progress at the same time instead of waiting for each order to finish before starting the next one.


## Conclusion

The main improvements are replacing blocking operations with asynchronous operations and using `Task.WhenAll()` to process independent orders concurrently.

Further improvements include removing unnecessary database queries, caching customer data, limiting concurrency, improving error handling, and preventing duplicate exports.

**Note:** Asynchronous operations do not automatically execute concurrently. `Task.WhenAll()` allows multiple tasks to make progress together when those tasks have been started before awaiting their combined completion.
