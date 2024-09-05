using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRUDMVC.DTOs;
using CRUDMVC.Interface;
using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace CRUDMVC.Controllers
{
    [Route("[controller]")]
    public class CompanyController(ICompanyRepository companyRepository, IUserRepository userRepository, IMapper mapper) : Controller
    {

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var companyList = await companyRepository.GetAsync();

            return View(companyList);
        }


        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var company = await companyRepository.GetByIdAsync(id);

            if (company == null) return NotFound();

            return View(company);
        }

        [HttpGet("Add")]
        public async Task<IActionResult> Add()
        {
            var users = await userRepository.GetAsync();

            ViewBag.users = new SelectList(users, "Id", "Name");

            return View();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddCompanyDTO addCompanyDTO)
        {
            var user = await userRepository.GetByIdAsync(addCompanyDTO.UserId);

            if (user == null) return NotFound();

            var company = mapper.Map<Company>(addCompanyDTO);
            company.UserId = addCompanyDTO.UserId;

            if (ModelState.IsValid)
            {
                await companyRepository.CreateAsync(company);
                await companyRepository.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var company = await companyRepository.GetByIdAsync(id);

            if (company == null) return NotFound();

            var updateCompanyDTO = mapper.Map<UpdateCompanyDTO>(company);

            return View(updateCompanyDTO);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(UpdateCompanyDTO updateCompanyDTO)
        {
            var company = await companyRepository.GetByIdAsync(updateCompanyDTO.Id);

            if (company != null)
            {
                mapper.Map(updateCompanyDTO, company);

                await companyRepository.UpdateAsync(company);

                await companyRepository.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await companyRepository.GetByIdAsync(id);

            if (company == null) return NotFound();

            await companyRepository.DeleteAsync(company);

            await companyRepository.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}