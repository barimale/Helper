# Helper


using LinqKit;

public IQueryable<Product> FilterProducts(IQueryable<Product> products, ProductFilter filter)
{
    var predicate = PredicateBuilder.New<Product>(true); // Start with a base predicate

    // Existing filters...
    if (!string.IsNullOrEmpty(filter.Category))
        predicate = predicate.And(p => p.Category == filter.Category);

    // Keyword search
    if (filter.Keywords != null && filter.Keywords.Any())
    {
        var keywordPredicate = PredicateBuilder.New<Product>(false); // Start with false for OR chaining

        foreach (var keyword in filter.Keywords)
        {
            string temp = keyword; // Avoid closure issues
            keywordPredicate = keywordPredicate
                .Or(p => p.Name.Contains(temp))
                .Or(p => p.Description.Contains(temp));
        }

        predicate = predicate.And(keywordPredicate);
    }

    return products.AsExpandable().Where(predicate);
}


var predicate = PredicateBuilder.New<Person>(true); // Start with a "true" predicate
if (filterByHappiness)
    predicate = predicate.And(p => p.IsHappy);
if (filterByName)
    predicate = predicate.And(p => p.Name.Contains("Alice"));

var result = people.AsQueryable().Where(predicate);

second solution:

Expression<Func<User, bool>> predicate = u => true;

if (!string.IsNullOrEmpty(name))
    predicate = predicate.And(u => u.Name.Contains(name));

if (minAge.HasValue)
    predicate = predicate.And(u => u.Age >= minAge.Value);

if (isActive.HasValue)
    predicate = predicate.And(u => u.IsActive == isActive.Value);

var users = session.Query<User>()
    .Where(predicate)
    .ToList();
