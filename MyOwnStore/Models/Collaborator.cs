using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class Collaborator
    {
        /* PK */
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        /*
         *Types
         * - N = Normal
         * - M = Manager
         */
         public string Type { get; set; }
    }
}
