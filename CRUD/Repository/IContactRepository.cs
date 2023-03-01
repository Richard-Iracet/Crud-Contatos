using CRUD.Models;
using System.Collections.Generic;

namespace CRUD.Repository
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> SearchData();
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);
    }
}
