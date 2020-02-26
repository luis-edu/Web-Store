using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.Validation
{
    public class UniqueCollaboratorEmail: ValidationAttribute
    {
        protected virtual ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Email = value as string;

            ICollaboratorRepository _cRepo = (ICollaboratorRepository)validationContext.GetService(typeof(ICollaboratorRepository));
            List<Collaborator> collaborator =(List<Collaborator>)_cRepo.GetByEmail(Email);

            Collaborator objCollaborator = (Collaborator)validationContext.ObjectInstance;

            if (collaborator.Count > 1)
            {
                return new ValidationResult("Este E-mail já está cadastrado");
            }
            else if (collaborator.Count == 1 && objCollaborator.Id != collaborator[0].Id)
            {
                return new ValidationResult("Este E-mail já está cadastrado");
            }
            return base.IsValid(value, validationContext);
        }
    }
}
