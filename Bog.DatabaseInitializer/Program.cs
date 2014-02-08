namespace Bog.DatabaseInitializer
{
    using System;

    using Bog.Data.EntityFramework;

    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            Console.WriteLine("Initializing Database...");

            BogContext context = new BogContext();
            context.Database.Initialize(true);

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        #endregion
    }
}