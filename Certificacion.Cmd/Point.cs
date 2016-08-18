using System;

namespace Certificacion.Cmd
{
    public struct Point
    {
        public int x, y;

        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}
class ConstructorChaining
{
    private int _p;
    public ConstructorChaining() : this(3) { }
    public ConstructorChaining(int p)
    {
        this._p = p;
    }
}