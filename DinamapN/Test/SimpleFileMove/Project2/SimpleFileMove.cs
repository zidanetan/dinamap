using System;
using System.Collections.Generic;
using System.Text;

// Simple file move operations with no user interface.

public class SimpleFileMove
{
    static void Main()
    {
       
        string sourceFile = @"C:\Users\Public\TestFolder\test2.txt";
        string destinationFile = @"C:\Users\Public\TestFolder\SubDir\test2.txt";

        // To move a file or folder to a new location:
        System.IO.File.Move(sourceFile, destinationFile);
        
        

        // To move an entire directory. 
        // To programmatically modify or combine
        // path strings
        //System.IO.Directory.Move(@"C:\Users\Public\public\test\", @"C:\Users\Public\private");
    }
}
