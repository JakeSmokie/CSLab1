﻿using System;

namespace CSLab1.Operations
{
    class Exit : IOperation
    {
        public char OperatorChar { get => 'q'; }
        public bool Run(MathBuffer mathBuffer)
        {
            Console.Beep(880, 1000);
            return true;
        }
    }
}
