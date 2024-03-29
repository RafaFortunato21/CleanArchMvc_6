﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
                return NotFound();


            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null)
                return NotFound();

            return View(categoryDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDTO);
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception($"Erro:{ex.Message}");
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);
        }


        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                NotFound();

            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) NotFound();

            return View(categoryDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
                return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if(categoryDto == null) return NotFound();

            return View(categoryDto);
        }

    }
}
