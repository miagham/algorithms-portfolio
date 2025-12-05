# Fisher Yates Shuffle — Algorithms Portfolio

## Overview
I learned how the Fisher Yates Shuffle works.
To show that I understand it, I made a C# console app that reads items from a text file and shuffles them.

## What is the Fisher-Yates Shuffle?
It's a shuffle algorithm that makes sure every item has an equal chance of ending up anywhere in the list.  
It works by:
- Looping from the end of the list backwards  
- Picking a random index from 0 to the current index  
- Swapping those two items  

## What My App Does
- Reads data from data.txt  
- Shows the original order  
- Shuffles the list using Fisher Yates  
- Shows the new, shuffled order  
 
## Files
- Program.cs — my shuffle code  
- data.txt — list of items to shuffle  
- README.md — this file  

## How to Run
1. Open the project in Visual Studio  
2. Make sure data.txt is set to “Copy Always”  
3. Run the program  
4. The console will show the list before and after shuffling  
