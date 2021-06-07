using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KabadaAPI.DataSource.Repositories {
  public class TexterRepository : BaseRepository {
        public TexterRepository(Microsoft.Extensions.Configuration.IConfiguration configuration, Microsoft.Extensions.Logging.ILogger logger =null) : base(configuration, logger) { }
    }
  }
