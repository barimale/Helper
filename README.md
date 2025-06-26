# Helper
'''
// 1. Install NuGet packages:
//    NHibernate, FluentNHibernate (or NHibernate.Mapping.ByCode), 
//    Microsoft.Extensions.DependencyInjection

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

public static class NHibernateExtensions
{
    public static IServiceCollection AddNhSessionFactory(this IServiceCollection services, string connectionString)
    {
        // build the session‐factory once
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString)
                .ShowSql())
            .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<YourEntityMap>())
            .ExposeConfiguration(cfg => new SchemaExport(cfg)
                // false = write DDL to console; true = execute DDL
                .Create(false, false))
            .BuildSessionFactory();                      // heavy, thread‐safe

        // register as singleton
        services.AddSingleton<ISessionFactory>(sessionFactory);

        // register ISession as scoped: one session per request/scope
        services.AddScoped(factory =>
        {
            var sf = factory.GetRequiredService<ISessionFactory>();
            var session = sf.OpenSession();            // ISession is NOT thread‐safe
            session.FlushMode = FlushMode.Commit;      // optional tuning
            return session;
        });

        return services;
    }
}

'''
https://blog.nimblepros.com/blogs/automapper-madness-part-2/

https://docs.automapper.org/en/stable/Nested-mappings.html

https://medium.com/all-about-software-testing/the-importance-of-unit-testing-your-automapper-mappings-ecdb52916487

https://medium.com/codenx/automapper-in-net-core-778f9c874164
