using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.AloMalo.DomainModel.Error
{
    public readonly record struct Error
    {
        public string Code { get; }

        public string Description { get; }

        public static Error Failure(
            string code = "General.Failure",
            string description = "A failure has occurred.") =>
                new(code, description);

        private Error(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
