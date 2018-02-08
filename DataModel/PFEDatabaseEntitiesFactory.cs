using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    class PFEDatabaseEntitiesFactory :IDbContextFactory<PFEDatabaseEntities>
{
    public PFEDatabaseEntities Create()
    {
            //return new PFEDatabaseEntities("metadata=res://*/DataBaseModel.csdl|res://*/DataBaseModel.ssdl|res://*/DataBaseModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=pfeserver.database.windows.net;initial catalog=PFEDatabase;persist security info=True;user id=floppy;password=l4nceWilson;MultipleActiveResultSets=True");
            return new PFEDatabaseEntities();
        }
}
}
