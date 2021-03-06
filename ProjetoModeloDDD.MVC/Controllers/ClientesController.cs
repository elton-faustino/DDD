﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        //
        // GET: /Clientes/

        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());

            return View(clienteViewModel);
        }

        //public ActionResult Especiais()
        //{
        //    //var clienteViewModel = Mapper.
        //}

        //
        // GET: /Clientes/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Clientes/Create

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);

                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //
        // POST: /Clientes/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Clientes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Clientes/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Clientes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Clientes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
