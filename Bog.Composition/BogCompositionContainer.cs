namespace Bog.Composition
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;

    /// <summary>
    /// The bog composition container.
    /// </summary>
    public class BogCompositionContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BogCompositionContainer"/> class.
        /// </summary>
        public BogCompositionContainer()
        {
            this.Compose();
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        private CompositionContainer Container { get; set; }

        /// <summary>
        /// The compose.
        /// </summary>
        public void Compose()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            string binPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"));

            // Filter file list to only BOG dlls.
            catalog.Catalogs.Add(new DirectoryCatalog(binPath));
            this.Container = new CompositionContainer(catalog);
        }

        /// <summary>
        /// The get exported values.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<T> GetExportedValues<T>()
        {
            return this.Container.GetExportedValues<T>();
        }
    }
}
