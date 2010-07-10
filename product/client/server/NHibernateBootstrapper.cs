using System.Data.SqlServerCe;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using gorilla.commons.utility;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using presentation.windows.server.orm.mappings;
using Environment = System.Environment;

namespace presentation.windows.server
{
    public class NHibernateBootstrapper : Query<ISessionFactory>
    {
        private string database_path;
        private string connection_string;

        public NHibernateBootstrapper()
        {
            database_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca\momoney\default.sdf");
            connection_string = string.Format("Data Source='{0}'; Password=;Persist Security Info=True", database_path);
        }

        public ISessionFactory fetch()
        {
            var configuration = new Configuration();
            return Fluently
                .Configure(configuration)
                .Database(MsSqlCeConfiguration.Standard
                              .ConnectionString(connection_string)
                              .AdoNetBatchSize(500)
                              //.ShowSql()
                              .ProxyFactoryFactory<ProxyFactoryFactory>()
                )
                .Mappings(x => { x.FluentMappings.AddFromAssemblyOf<MappingAssembly>(); })
                .ExposeConfiguration(x => export(x)).BuildSessionFactory();
        }

        private void export(Configuration configuration)
        {
            using (var engine = new SqlCeEngine(connection_string))
            {
                if (File.Exists(database_path)) File.Delete(database_path);
                engine.CreateDatabase();
            }
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}