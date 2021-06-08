using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core
{
    public class Range
    {
        public Range(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        public Position Start { get; set; }
        public Position End { get; set; }
    }
}
