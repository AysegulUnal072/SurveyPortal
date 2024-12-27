using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyPortal.Models;
using SurveyPortal.Repositories;
using SurveyPortal.ViewModels;

namespace SurveyPortal.Controllers 
{
    public class SurveyController : Controller
    {
        private readonly SurveyRepository _surveyRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        public SurveyController(SurveyRepository surveyRepository, CategoryRepository categoryRepository, IMapper mapper, INotyfService notyf)
        {
            _surveyRepository = surveyRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            var surveys = await _surveyRepository.GetAllAsync();
            var surveyModels = _mapper.Map<List<SurveyModel>>(surveys);
            return View(surveyModels);
        }
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesSelectList = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Categories = categoriesSelectList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(SurveyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var survey = _mapper.Map<Survey>(model);
            await _surveyRepository.AddAsync(survey);
            _notyf.Success("Ürün Eklendi...");
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesSelectList = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Categories = categoriesSelectList;
            var survey = await _surveyRepository.GetByIDAsync(id);
            var surveyModel = _mapper.Map<SurveyModel>(survey);
            return View(surveyModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SurveyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var survey = await _surveyRepository.GetByIDAsync(model.Id);
            survey.Title = model.Title;
            survey.Questions = model.Questions;
            survey.IsActive = model.IsActive;
            survey.CategoryId = model.CategoryId;

            await _surveyRepository.UpdateAsync(survey);
            _notyf.Success("Ürün Güncellendi...");
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(int id)
        {
            var survey = await _surveyRepository.GetByIDAsync(id);
            var surveyModel = _mapper.Map<SurveyModel>(survey);
            return View(surveyModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SurveyModel model)
        {
            await _surveyRepository.DeleteAsync(model.Id);
            _notyf.Success("Ürün Silindi...");
            return RedirectToAction("Index");
        }

    }


}



    











