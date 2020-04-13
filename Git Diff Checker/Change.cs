using Git_Diff_Checker.Enums;

namespace Git_Diff_Checker
{
    public class Change
    {
        public string Word { get; set; }
        public int Position { get; set; }
        public int LineNumber { get; set; }
        public Actions Action { get; set; }
    }
}
