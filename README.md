# Helper

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
