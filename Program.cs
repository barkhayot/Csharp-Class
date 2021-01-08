using System;

namespace array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] movies={"Harry Potter", "Secret Garden", "Narnia", "Lord of the Rings", "The Hobbit", "Pirates"};

            for (int i = 0; i < movies.Length; i++)
            {
                int rank = i + 1;
                Console.WriteLine(rank + ". " + movies[i]);
            }
        }
    }
}
