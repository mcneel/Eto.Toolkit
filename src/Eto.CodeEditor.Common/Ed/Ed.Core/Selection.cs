using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core
{
    class Selection
    {
        public Position Active { get; }
        public Position Anchor { get; }
        public Position Start { get; }
        public Position End { get; }
        public bool IsEmpty { get; }
        public bool IsReversed { get; }
        public bool IsSingleLine { get; }
    }
}
