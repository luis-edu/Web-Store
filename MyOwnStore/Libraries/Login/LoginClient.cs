using MyOwnStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Login
{
    public class LoginClient
    {
        private string _key = "Login.Client";
        private Session.Session _session;
        public LoginClient(Session.Session Session)
        {
            _session = Session;
        }
         public void LogIn(Client client)
        {
            string clientJSONString = JsonConvert.SerializeObject(client);
            _session.Register(_key, clientJSONString);
        }
        public Client GetClient()
        {
            if (_session.IsTrue(_key))
            {
                string clientJSONString = _session.Search(_key);
                return JsonConvert.DeserializeObject<Client>(clientJSONString);
            }
            else
            {
                return null;
            }
            
        }

        public void LogOut()
        {
            _session.RemoveAll();
        }
    }
}
