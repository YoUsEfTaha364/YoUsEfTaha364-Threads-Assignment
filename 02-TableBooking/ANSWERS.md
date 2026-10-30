# Assignment 02 — Answers

Student name:  
Group / ID:

## What is wrong

The original `Book()` method is not thread-safe. Multiple threads can call it at the same time and attempt to book the same remaining tables.

The problem is that checking `TablesLeft` and updating `TablesLeft` and `Booked` are separate operations that are not protected against concurrent access.

For example, if only one table remains, two threads might both check `TablesLeft > 0` before either thread decreases the count. Both threads could then book a table even though only one is available.

This is called a **race condition**.

## How you fixed it



I introduced a private lock object and used the `lock` statement to protect the entire booking operation.

