﻿using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using SurveyPortal.Models;
using Microsoft.AspNetCore.Mvc;
using SurveyPortal.Repositories;
using SurveyPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SurveyPortal.Hubs;

namespace SurveyPortal.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SurveyRepository _surveyRepository;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;
        private readonly IHubContext<GeneralHub> _generalHub;

        public CategoryController(CategoryRepository categoryRepository, INotyfService notyf, SurveyRepository surveyRepository, IMapper mapper, IHubContext<GeneralHub> generalHub)
        {
            _categoryRepository = categoryRepository;
            _notyf = notyf;
            _surveyRepository = surveyRepository;
            _mapper = mapper;
            _generalHub = generalHub;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryModels = _mapper.Map<List<CategoryModel>>(categories);
            return View(categoryModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var category = _mapper.Map<Category>(model);
            category.Created = DateTime.Now;
            category.Updated = DateTime.Now;
            await _categoryRepository.AddAsync(category);

            int catCount = _categoryRepository.Where(c => c.IsActive == true).Count();
            await _generalHub.Clients.All.SendAsync("onCategoryAdd", catCount);
            _notyf.Success("Kategori Eklendi...");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryRepository.GetByIDAsync(id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return View(categoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var category = await _categoryRepository.GetByIDAsync(model.Id);
            category.Name = model.Name;
            category.IsActive = model.IsActive;
            category.Updated = DateTime.Now;
            await _categoryRepository.UpdateAsync(category);
            int catCount = _categoryRepository.Where(c => c.IsActive == true).Count();
            await _generalHub.Clients.All.SendAsync("onCategoryUpdate", catCount);
            _notyf.Success("Kategori Güncellendi...");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIDAsync(id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return View(categoryModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(CategoryModel model)
        {

            var surveys = await _surveyRepository.GetAllAsync();
            if (surveys.Count(c => c.CategoryId == model.Id) > 0)
            {
                _notyf.Error("Üzerinde Ürün Kayıtlı Olan Kategori Silinemez!");
                return RedirectToAction("Index");
            }

            await _categoryRepository.DeleteAsync(model.Id);
            int catCount = _categoryRepository.Where(c => c.IsActive == true).Count();
            await _generalHub.Clients.All.SendAsync("onCategoryDelete", catCount);
            _notyf.Success("Kategori Silindi...");
            return RedirectToAction("Index");

        }
    }
}
