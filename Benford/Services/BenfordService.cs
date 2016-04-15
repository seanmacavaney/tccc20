using Benford.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benford.Services
{
    public interface IBenfordService
    {
        BenfordResult Analyze();
    }

    public class BenfordService : IBenfordService
    {
        public IBenfordDataSource DataSource { get; set; }

        public BenfordService()
        {
            this.DataSource = new WorldPopulationDataSource();
        }

        public BenfordResult Analyze()
        {
            var data = this.DataSource.GetData();
            var count = data.Count();
            return new BenfordResult()
            {
                Name = this.DataSource.Name,
                Actual = (from d in data
                          let orderOfMag = Math.Floor(Math.Log10(d))
                          let leadingDigit = (byte)Math.Floor(d / Math.Pow(10, orderOfMag))
                          group data by leadingDigit into g
                          orderby g.Key
                          select g.Count() / (double)count
                         ).ToArray()
            };
        }
    }
}
