using System;
using System.Collections.Generic;
using System.Text;

namespace Ed.Core
{
    public class Position
    {
        public Position(int line, int character)
        {
            Line = line;
            Character = character;
        }

        public int Character { get; private set; }
        public int Line { get; private set; }
    }
}
