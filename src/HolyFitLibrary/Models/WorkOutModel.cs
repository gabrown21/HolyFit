

namespace HolyFitLibrary.Models
{
    public class WorkOutModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]

        public string Id { get; set; }  
        public string sets { get; set; }

        public string reps { get; set; }

        public string name { get; set; }

        public string type { get; set; }

    }
}
