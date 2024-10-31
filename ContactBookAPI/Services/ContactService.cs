using ContactBookAPI.Models;
using ContactBookAPI.Repositories;

namespace ContactBookAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContact();
        }

        // public List<Contact> GetAllContacts() => _repository.GetAllContacts();  {Both GetAllContacts are Same}


        public Contact GetContactById(int id)
        {
            return _contactRepository.GetContactnById(id);
        }



        public void AddContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
        }

        
        public bool UpdateContact(int id, Contact contact)
        {
            return _contactRepository.UpdateContact(id, contact);
        }


        public bool DeleteContact(int id)
        {
            return _contactRepository.DeleteContact(id);
        }


    }
}
