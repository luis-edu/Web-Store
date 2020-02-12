using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Session
{
    public class Session
    {
        private IHttpContextAccessor _context;
        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }
        /* 
         * CRUD Cadastrar/Atualizar/Consultar/Remover - RemoverTodos/ Verificar se existe
         */
        public void Register(string key, string value)
        {
            _context.HttpContext.Session.SetString(key, value);
        }

        public void Update(string key, string value)
        {
            if (IsTrue(key))
            {
                _context.HttpContext.Session.Remove(key);
            }
             _context.HttpContext.Session.SetString(key, value);
        }
        public void Delete(string key)
        {
            _context.HttpContext.Session.Remove(key);
        }
        public string Search(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }
        public bool IsTrue(string key)
        {
            if(_context.HttpContext.Session.GetString(key) != null)
            {
                return true;
            }return false;
        }
        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
