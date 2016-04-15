using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Benford.Services
{
    public class WorldPopulationDataSource : IBenfordDataSource
    {
        public string Name { get { return "World Populations"; } }

        public IEnumerable<double> GetData()
        {
            using (StreamReader reader = File.OpenText(@"C:\data\populations.csv"))
            {
                var csv = new CsvHelper.CsvReader(reader);
                while (csv.Read())
                {
                    yield return csv.GetField<double>(@"Value");
                }
            }
        }
    }
}
