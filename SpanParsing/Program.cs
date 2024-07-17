namespace SpanParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input string:");
        
            var input = Console.ReadLine();
        
            foreach (var number in ParseInts(input, ','))
            {
                Console.WriteLine(number);
            }
        }

        private static List<int> ParseInts(ReadOnlySpan<char> textSpan, char separator)
        {
            var result = new List<int>();
        
            var remainderSpan = textSpan;
        
            int separatorIndex;
        
            while ((separatorIndex = remainderSpan.IndexOf(separator)) != -1)
            {
                // Index of separator is actually length of segmentSpan
                var segmentSpan = remainderSpan.Slice(0, separatorIndex);
            
                if (int.TryParse(segmentSpan, out var number))
                {
                    result.Add(number);
                }
            
                // Remainder span starts from element after separator
                remainderSpan = remainderSpan.Slice(separatorIndex + 1);
            }
        
            if (int.TryParse(remainderSpan, out var lastNumber))
            {
                result.Add(lastNumber);
            }
        
            return result;
        }
    }
}