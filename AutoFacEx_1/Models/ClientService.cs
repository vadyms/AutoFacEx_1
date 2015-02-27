using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacEx_1.Models
{
    public class ClientService : IClientService
    {
        List<Client> clients = new List<Client>();

        public List<Client> GetClients()
        {
            clients.Add( new Client( 1, "N1" ) );
            clients.Add( new Client( 2, "N2" ) );
            return clients;
        }
        public bool Add( Client client )
        {
            bool added = false;
            try
            {
                clients.Add( client );
            }
            catch
            {
                // exception
            }
            return added;
        }



        public List<Client> FindById( int id )
        {
            List<Client> result = new List<Client>();
            foreach (Client c in clients)
            {
                if (c.Id == id)
                {
                    result.Add( c );
                }
            }
            return result;
        }
    }
}