﻿using System;
using System.Web;
using System.Web.Mvc;
using NotesManager.Web.UI.BusinessServices;
using NotesManager.Web.UI.Controllers.Helpers;
using NotesManager.Web.UI.ViewModels;

namespace NotesManager.Web.UI.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            if (notesService == null)
            {
                throw new ArgumentNullException("notesService");
            }

            _notesService = notesService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var notes = _notesService.GetAllNotes();
            var notesViewModels = notes.ConvertToViewModel();
            return View(notesViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NoteViewModel note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _notesService.Add(note.ConvertToDomain());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}