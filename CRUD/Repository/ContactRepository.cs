using CRUD.Data;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Repository
{
    public class ContactRepository : IContactRepository
    {
       private readonly BankContext _bankContext;
        
        public ContactRepository(BankContext bankContext)
        {
            this._bankContext = bankContext;
        }
        public ContactModel ListById(int id)
        {
            return _bankContext.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactModel> SearchData()
        {
            return _bankContext.Contacts.ToList();
        }
        public ContactModel Add(ContactModel contact)
        {
            _bankContext.Contacts.Add(contact);
            _bankContext.SaveChanges();
            return contact;

        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = ListById(contact.Id);

            if (contactDB == null) throw new System.Exception("There was an error updating the contact");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Cell = contact.Cell;

            _bankContext.Contacts.Update(contactDB);
            _bankContext.SaveChanges();
            return contactDB;
        }

        public bool Delete(int id)
        {
            ContactModel contactDB = ListById(id);

            if (contactDB == null) throw new System.Exception("There was an error deleting the contact.");

            _bankContext.Contacts.Remove(contactDB);
            _bankContext.SaveChanges();

            return true;
        }
    }
}
