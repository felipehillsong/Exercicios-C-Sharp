using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WEB_EF.Conexao
{
    public class ConfiguracaoDoEntity:DbConfiguration
    {
        public ConfiguracaoDoEntity()
        {
            SetProviderServices(System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName, System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }
    }
}