using ContactBookAPI.Models;
using ContactBookAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }



        [HttpGet]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            return Ok(_service.GetAllContacts());
        }


        [HttpGet("{id}")]
        public ActionResult<Contact> GetContantById(int id)
        {
            var contact = _service.GetContactById(id);
            return contact != null ? Ok(contact) : NotFound();
        }


        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _service.AddContact(contact);
            return Ok("Contact Added Successfully");
        }


        [HttpPost("{id}")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            return _service.UpdateContact(id, contact) ? Ok("Contact Updated Successfully") : NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteContact (int id)
        {
            return _service.DeleteContact(id) ? Ok("Contact Deleted Successfully") : NotFound();
        }
    }
}
