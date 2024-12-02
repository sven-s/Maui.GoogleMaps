using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.GoogleMaps.Clustering
{
    public interface IClusteredMap : IView
    {
        public string GeoJson { get; set; }

    }
}
