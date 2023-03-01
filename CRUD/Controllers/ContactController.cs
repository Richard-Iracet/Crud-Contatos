using CRUD.Models;
using CRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUD.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.SearchData();

            return View(contacts);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                    bool deleted = _contactRepository.Delete(id);

                    if (deleted)
                    {
                        TempData["SuccessMessage"] = "Contato apagado com sucesso!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Não foi possível apagar o contato!";
                    }
                    return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Não foi possível apagar o contato, detalhes do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Add(ContactModel contact)
        {
          try
          {
              if (ModelState.IsValid)
              {
                  _contactRepository.Add(contact);
                  TempData["SuccessMessage"] = "Contato cadastrado com sucesso!";
                  return RedirectToAction("Index");
              }

              return View(contact);
          }
          catch (System.Exception error)
          {
                TempData["ErrorMessage"] = $"Não foi possível cadastrar o contato, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Edit", contact);
            }
            catch (System.Exception error)
            {
                TempData["ErrorMessage"] = $"Não foi possível alterar o contato, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
