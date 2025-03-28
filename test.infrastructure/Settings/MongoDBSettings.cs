using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.infrastructure.Settings
{
    public class MongoDBSettings
    {
        private static MongoDBSettings _instance;
        //public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; private set; }
        private MongoDBSettings(IConfiguration configuration) {
            ConnectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
        }

        //public static MongoDBSettings GetInstance()
        //{
        //    //if (_instance == null)
        //    //{
        //    //    _instance = new MongoDbSettings();
        //    //    _instance.ConnectionString = "mongodb://localhost:27017"; // Ejemplo
        //    //}
        //    if (_instance == null)
        //    {
        //        // Si la instancia no existe, la creamos
        //        _instance = new MongoDBSettings();
        //        // Cargamos la configuración desde la fuente proporcionada (appsettings.json, variables de entorno, etc.)
        //        _instance.ConnectionString = configuration.GetValue<string>("MongoDbSettings:ConnectionString");
        //    }

        //    return _instance;
        //}
        public static MongoDBSettings GetInstance(IConfiguration configuration)
        {
            if (_instance == null)
            {
                _instance = new MongoDBSettings(configuration);  // Creamos la instancia y pasamos la configuración
            }

            return _instance;
        }
    }
}
