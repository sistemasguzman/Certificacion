namespace Certificacion.Cmd
{
    public class GenericStruct<T> where T : struct
    {

    }

    public class GeCons<T> where T : new()
    {
        public string Name { get; set; }
    }

    public class Data
    {
        public string Name => "Esteban";

        public Data()
        {

        }
    }
}

public class Name
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int[] Values { get; set; }
}


