using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedikalSozluk.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string adminUserName = (string)Session["AdminUserName"];
            var messagelistin = mm.GetListInbox(adminUserName);
            ViewBag.unRead = mm.GetCountUnreadMessage(adminUserName);
            return View(messagelistin);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelistsend = mm.GetListSendbox(p);
            return View(messagelistsend);

        }
        // Daha sonradan çöp kutusu ve taslak eklemek istersek şimdilik gereksiz.29.11
        //public ActionResult Draft(string p)
        //{
        //    var list = mm.GetListDraft(p);
        //    return View(list);
        //}

        //public ActionResult Trash(string p)
        //{
        //    var list = mm.GetListTrash(p);
        //    return View(list);

        //}

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            if (!values.IsRead)
            {
                values.IsRead = true;
                mm.MessageUpdate(values);
            }
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult IsRead(int id) //Bu alan gelen mesajlarindaki okundu butonundan gelen degeri database yazar
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsRead)
            {
                messageValue.IsRead = false;
            }
            else
            {
                messageValue.IsRead = true;
            }
            mm.MessageUpdate(messageValue);
            return RedirectToAction("Inbox");
        }

    }
}