using Git_Diff_Checker.Enums;
using System;

namespace Git_Diff_Checker
{
    //constructor for the list attributes that can be assigned to a single entry
    public class Change
    {
        public string Word { get; set; }
        public int Position { get; set; }
        public int LineNumber { get; set; }
        public Actions Action { get; set; }
        public ConsoleColor WordColour { get; set;} 
    }
}
