using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCSharp.Context;
using ApiCSharp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public ContactController(ScheduleContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            //Retorna o contato e a url para requisitar o contato criado
            return  CreatedAtAction(nameof (GetByID), new {id = contact.Id}, contact);
            //Retorna apenas o contato
            // return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet("getByName")]
        public IActionResult GetByName(string name)
        {
            //Retorna todos os contatos que contém no Name os caracteres passados como parâmetro
            var contacts = _context.Contacts.Where(item => item.Name.Contains(name));

            return Ok(contacts);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var requestedContact = _context.Contacts.Find(id);

            if(requestedContact == null)
                return NotFound();

            requestedContact.Name = contact.Name;
            requestedContact.Telephone = contact.Telephone;
            requestedContact.Active = contact.Active;

            _context.Contacts.Update(requestedContact);
            _context.SaveChanges();

            return Ok(requestedContact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var requestedContact = _context.Contacts.Find(id);

            if(requestedContact == null)
                return NotFound();

            _context.Contacts.Remove(requestedContact);
            _context.SaveChanges();

            return NoContent();
        }
    }
}