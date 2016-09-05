using System;

namespace Certificacion.Cmd
{
    public class User
    {
        public User(int id)
        {
            Console.WriteLine(id);
        }

        public User()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}