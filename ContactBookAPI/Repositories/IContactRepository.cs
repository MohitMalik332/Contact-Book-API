using ContactBookAPI.Models;

namespace ContactBookAPI.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContact(); //Method for getting all the Contacts
        Contact GetContactnById(int id); //Method for getting one contact by Id
        void AddContact(Contact contact); //Method for adding a contact
        bool UpdateContact(int id ,Contact contact); //for Updating a contact
        bool DeleteContact(int id); // delete a contact.
    }
}
