using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Model
{
    public record Address(string StreetNumber, string ZipCode, string city, string country)
    {
        // TODO: Logik ... lassen wir uns noch einfallen
    }
}
