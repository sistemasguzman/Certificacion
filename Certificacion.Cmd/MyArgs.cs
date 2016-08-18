using System;

namespace Certificacion.Cmd
{
    public class MyArgs : EventArgs
    {
        public int Value { get; set; }
        public MyArgs(int value)
        {
            Value = value;
        }

    }
}