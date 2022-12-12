using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.Models
{
    public class DayModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string days { get; set; }
    }
}
