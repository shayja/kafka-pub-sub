namespace ApacheKafkaProducer.Core.Extensions;

internal static class MongoDbExtensions
{
    public static bool IdValidObjectId(this string? id)
    {
        if (string.IsNullOrEmpty(id)) return false;

        if (ObjectId.TryParse(id, out _))
        {
            return true;
        }
        return false;
    }

}


