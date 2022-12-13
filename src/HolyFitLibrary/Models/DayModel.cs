

namespace HolyFitLibrary.Models
{
    public class DayModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]

        public string Id { get; set; }
        public string days { get; set; }
    }
}
