using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Certificacion.Cmd
{
    public class Service
    {


        public void AddDataTable<T>(string dtName, List<T> elements, Action<DataTable> addColumns, Action<DataRow, T> dtRow) where T : class
        {
            var dtTable = new DataTable(dtName);
            if (elements.Any())
            {
                addColumns(dtTable);
            }
            
            foreach (var element in elements)
            {
                var row = dtTable.NewRow();
                dtRow(row, element);
                dtTable.Rows.Add(dtRow);
            }
        }

        private event EventHandler<MyArgs> onChange = delegate { };

        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }


        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }


        public delegate int Calculate(int x, int y);

        public delegate void Multicast();

        public readonly Action<int> actionName = (x) =>
        {
            if (x == 0)
                Console.WriteLine("neutro");
            else if (x > 0)
                Console.WriteLine("positive");
            else
                Console.WriteLine("negative");
        };

        public readonly Func<int, ToNumber> FuncToNumber = (x) => new ToNumber()
        {
            Number = x,
            Status = x == 0 ? "neutro" : x > 0 ? "positive" : "negative"
        };

        public readonly Func<int, int, int> funcToName = (x, y) =>
        {
            return Math.Max(x, y);
        };

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public void ShowYear()
        {
            Console.WriteLine(DateTime.Now.Year);
        }

        public void ShowDay()
        {
            Console.WriteLine(DateTime.Now.DayOfWeek);
        }

    }
}

public class ToNumber
{
    public int Number { get; set; }
    public string Status { get; set; }
}