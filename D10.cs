/*

ASSIGNMENT RULES
- !!! Yesterday's Binary Search exercise should be completed FIRST !!!
- The solution must be pushed to the repository and be available for the tutors by the end of the day
- You can ask for tutor's help
- You can google / use StackOverflow for System.IO commands; for anything else, we suggest you to just use provided material
- Our "StriveEasierAlgorithms" [https://github.com/danielebanovaz/StriveEasierAlgorithms] should be an excellent starting point to understand how to structure this console application
- Test the code

ASSIGNMENT TOPIC
You have to build a simple Shell.
The shell can execute this commands:
- dir => Shows all the content of the current working directory
- ls => Same as dir
- cd => Print current directory
- pwd => Same as cd
- cd .. => goes up in the folder hierarchy
- cd FolderName => goes in the folder FolderName
- del FileName => delete a specific file called FileName
- mv FileName path => move the file FileName to Path
- quit => close the program
- exit => same as quit

[EXTRA]:
Using Arrow Up / Arrow Down, the user can select a previously used command from the history.

HINTS:
- SOLVE COMPILER ERRORS AS SOON AS THEY SHOW UP (don't let them pile up). Hovering the mouse over the underlined piece of code is enough to have a specific description of the problem.
- All the commands have the same features and therefore they could all derive from the same class (Command).
- Being all the commands implementing the same parent class, the history could be managed as array of Command (Command[])
- This is just a hint if you want to try messing up with Inheritance and Polymorphism. If it sounds too weird, please just ignore it.

*/