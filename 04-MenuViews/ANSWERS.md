# Assignment 04 — Answers

Student name:  
Group / ID:

## Why Expected and Actual disagree

- because threads odes not work on atomic 
 views++ make three operation read ,increment and write 

## What you changed

- used Interlocked  this make it atomic -> only obe operation

## When would you protect the update differently

- 2. When the update depends on complex business logic or conditions

    so i ned lock first 
