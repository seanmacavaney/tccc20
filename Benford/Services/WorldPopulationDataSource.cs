using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Benford.Services
{
    public class WorldPopulationDataSource : IBenfordDataSource, IDisposable
    {
        private StreamReader reader;

        public string Name { get { return "World Populations"; } }

        public WorldPopulationDataSource()
        {
            reader = File.OpenText(@"C:\data\populations.csv");
        }

        public IEnumerable<double> GetData()
        {
            var csv = new CsvReader(reader);
            while (csv.Read())
            {
                yield return csv.GetField<double>(@"Value");
            }
        }

        public void Dispose()
        {
            this.reader.Dispose();
        }
    }
}
