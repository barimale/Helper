# Helper
CreateMap(typeof(TempMapViewModel), typeof(MapViewModel)) .IgnoreAllNonExisting() .IgnoreAllNonExistingSource()
public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)

{

    var sourceType = typeof(TSource);

    var destinationType = typeof(TDestination);

    var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)

        && x.DestinationType.Equals(destinationType));

    foreach (var property in existingMaps.GetUnmappedPropertyNames())

    {

        expression.ForMember(property, opt => opt.Ignore());

    }

    return expression;

}



    public static IMappingExpression IgnoreAllNonExisting(this IMappingExpression expression)
    {
        foreach (var property in expression.TypeMap.GetUnmappedPropertyNames())
        {
            expression.ForMember(property, opt => opt.Ignore());
        }
        return expression;
    }

    public static IMappingExpression IgnoreAllNonExistingSource(this IMappingExpression expression)
    {
        foreach (var property in expression.TypeMap.GetUnmappedPropertyNames())
        {
            expression.ForSourceMember(property, opt => opt.Ignore());
        }
        return expression;
    }

https://blog.nimblepros.com/blogs/automapper-madness-part-2/

https://docs.automapper.org/en/stable/Nested-mappings.html

https://medium.com/all-about-software-testing/the-importance-of-unit-testing-your-automapper-mappings-ecdb52916487

https://medium.com/codenx/automapper-in-net-core-778f9c874164
