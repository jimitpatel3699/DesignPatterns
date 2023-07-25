using DataAccessLayerP22.Data;
using DataAccessLayerP22.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerP22.Singleton
{
    public sealed class SingletonClass
    {
        private SingletonClass() { }
        private static ApplicationContext _context = null;
        public static ApplicationContext GetDbInstance()
        {
            if(_context == null)
            {
                _context = new ApplicationContext();
            }
            return _context;
        }
        private static Logger _logger = null;
        public static Logger GetLoggerInstance() 
        {
            if(_logger == null) {
                _logger = new Logger();
            }
            return _logger;
        }
    }
}
