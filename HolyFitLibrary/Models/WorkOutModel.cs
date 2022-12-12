using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.Models
{
    public class WorkOutModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]

        public string sets { get; set; }

        public string reps { get; set; }

        public string name { get; set; }

        public string type { get; set; }

    }
}
