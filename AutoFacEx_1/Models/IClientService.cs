using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacEx_1.Models
{
    public interface IClientService
    {
        List<Client> GetClients();
        bool Add( Client client );
        List<Client> FindById( int id );
    }
}
