using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benford.Services
{
    public interface IBenfordDataSource
    {
        string Name { get; }
        IEnumerable<double> GetData();
    }
}
