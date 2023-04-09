namespace ApacheKafkaConsumer.Core.Extensions;

internal static class JsonConventionsExtensions
{
    internal static void AddJsonConventions(this IServiceCollection services)
    {
        var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        //var conventionPack = new ConventionPack();
        //conventionPack.AddMemberMapConvention("snakeCase", m => m.SetElementName(m.MemberName.ToSnakeCase()));
        ConventionRegistry.Register("conventions", conventionPack, t => true);
    }
}
