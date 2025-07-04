# Helper

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
