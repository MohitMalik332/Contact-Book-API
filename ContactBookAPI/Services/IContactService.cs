using ContactBookAPI.Models;

namespace ContactBookAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);

        void AddContact(Contact contact);
        bool UpdateContact (int id, Contact contact);
        bool DeleteContact(int id);
    }
}
