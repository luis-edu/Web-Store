
using MyOwnStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Login
{
    public class LoginCollaborator
    {
        private string _key = "Login.Collaborator";
        private Session.Session _session;
        public LoginCollaborator(Session.Session Session)
        {
            _session = Session;
        }
        public void LogIn(Collaborator collaborator)
        {
            string collaboratorJSONString = JsonConvert.SerializeObject(collaborator);
            _session.Register(_key, collaboratorJSONString);
        }
        public Collaborator GetClient()
        {
            if (_session.IsTrue(_key))
            {
                string collaboratorJSONString = _session.Search(_key);
                return JsonConvert.DeserializeObject<Collaborator>(collaboratorJSONString);
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
