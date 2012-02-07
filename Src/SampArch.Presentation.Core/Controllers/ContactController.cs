using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SampArch.Presentation.Core.Models;
using SampArch.Domain.Common;

namespace SampArch.Presentation.Core.Controllers
{
    public class ContactController : Controller
    {
        private IInternalMessageRepository _repository;

        public ContactController(IInternalMessageRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            ContactMessage message = new ContactMessage();
            return View(message);
        }

        [HttpPost]
        public ActionResult SendMessage(ContactMessage cm)
        {
            if (ModelState.IsValid)
            {
               // FakeContactRepository.Send(message);
                _repository.Add(new InternalMessage() { Author = cm.Name, Content = cm.Message, CreationDate = cm.CreationDate });
                return RedirectToAction("MessageSent", cm);
            }
            else
            {
                return View(cm);
            }
        }

        public ActionResult MessageSent(ContactMessage message)
        {
            return View(message);
        }

        [Authorize(Roles="Admin")]
        public ActionResult ViewMessages()
        {
            //var messages = FakeContactRepository.GetCurrentMessages().OrderByDescending(x => x.CreationDate);
            var messages = _repository.GetAll();
            return View(messages);
        }
    }

    //for demo purposes only!
    public static class FakeContactRepository
    {
        private static void InitMessages()
        {
            _messages = new List<ContactMessage>();
            _messages.Add(new ContactMessage
            {
                CreationDate = DateTime.Now.AddDays(-2),
                Name = "Jimmy",
                Message = "Hello, can you send me the slides of your session? thx"
            });

            _messages.Add(new ContactMessage
            {
                CreationDate = DateTime.Now.AddDays(-2),
                Name = "Robert",
                Message = "good to see you!"
            });


        }
        private static List<ContactMessage> _messages;

        private static List<ContactMessage> _Messages
        {
            get
            {
                if (_messages == null)
                {
                    InitMessages();
                }
                return _messages;
            }
        }
        public static void Send(ContactMessage message)
        {
            _messages.Add(message);
        }

        public static IEnumerable<ContactMessage> GetCurrentMessages()
        {
            return _messages;
        }
    }
}