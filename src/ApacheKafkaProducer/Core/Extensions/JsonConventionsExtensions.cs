namespace ApacheKafkaProducer.Core.Extensions;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Conventions;

internal static class JsonConventionsExtensions
{
    internal static void AddJsonConventions(this IServiceCollection services)
    {
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            MaxDepth = 10,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };
        serializerOptions.Converters.Add(new JsonStringEnumConverter());
        services.AddSingleton(s => serializerOptions);

        var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        //var conventionPack = new ConventionPack();
        //conventionPack.AddMemberMapConvention("snakeCase", m => m.SetElementName(m.MemberName.ToSnakeCase()));
        ConventionRegistry.Register("conventions", conventionPack, t => true);
    }
}
