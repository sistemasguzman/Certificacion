using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.Script.Serialization;


namespace Certificacion.Cmd
{
    class Program
    {

        static void Main(string[] args)
        {
            int myInt = 12;
            object obj = myInt;      // boxing
            int myInt2 = (int)obj;


            var numbers = new[] { 1, 2, -1, 0, 3, 4, 5 };
            
            var name = new Name
            {
                FirstName = "esteban",
                LastName = "guzman",
                Values = new[] { 1, 2, 3 }
            };

            var json = new JavaScriptSerializer();
            var rs = json.Serialize(name);


            name = json.Deserialize<Name>(rs);


            GeCons<Data> da = new GeCons<Data>();


            ConstructorChaining chaining = new ConstructorChaining();
            Console.WriteLine();

            var service = new Service();
            Service.Calculate calculate = service.Add;
            service.OnChange += (sender, myArgs) => Console.WriteLine("new data {0} from raise", myArgs.Value);

            service.Raise();

            var data = numbers.Select(service.FuncToNumber).ToList();

            Console.WriteLine(calculate(12, 12));
            calculate = service.Multiply;
            Console.WriteLine(calculate(12, 12));


            Service.Multicast multicast = service.ShowYear;
            multicast += service.ShowDay;

            multicast();

            Service.Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(1, 4));
            calc = (x, y) =>
            {
                Console.WriteLine("multiply");
                return x * y;
            };
            Console.WriteLine(calc(1, 4));

            Action<int, int> calcAction = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
            calcAction(5, 6);

            Func<int, int, int> calcFunc = (x, y) => x * y;
            Console.WriteLine(calcFunc(1, 2));

            Console.ReadKey();
        }
    }
}
