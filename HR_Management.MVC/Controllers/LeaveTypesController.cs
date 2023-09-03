﻿using HR_Management.MVC.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
	public class LeaveTypesController : Controller
	{
		private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
			_leaveTypeService = leaveTypeService;
		}
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
		{
			var leaveTypes = await _leaveTypeService.GetLeaveTypes();
			return View(leaveTypes);
		}

		// GET: LeaveTypesController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			return View();
		}

		// GET: LeaveTypesController/Create
		public async Task<ActionResult> Create()
		{
			return View();
		}

		// POST: LeaveTypesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: LeaveTypesController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			return View();
		}

		// POST: LeaveTypesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: LeaveTypesController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			return View();
		}

		// POST: LeaveTypesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}