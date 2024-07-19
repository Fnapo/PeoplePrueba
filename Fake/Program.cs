using DatosSakila;
using DatosSakila.Datos;
using DatosSakila.Modelos;

namespace Fake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonasContext context = new PersonasContext();
            int contador = context.Actors.Count();

            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            if (contador > 0) 
            {
                List<Actor> actores = context.Actors.ToList();

                for (int indice = 0; indice < 3; indice++)
                {
                    int elegido = Random.Shared.Next(contador);

                    Console.WriteLine($"{actores[elegido].LastName}, {actores[elegido].FirstName}.");
                }
            }

        }
    }
}
