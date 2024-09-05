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
using Microsoft.Extensions.Logging;

namespace CRUDMVC.Controllers
{
    [Route("[controller]")]
    public class UserController(IUserRepository userRepository, IMapper mapper) : Controller
    {

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var userList = await userRepository.GetAsync();
            
            return View(userList);
        }

        [HttpGet("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddUserDTO addUserDTO)
        {
            var user = mapper.Map<AppUser>(addUserDTO);

            if (ModelState.IsValid)
            {
                await userRepository.CreateAsync(user);
                await userRepository.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View();
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null) return NotFound();

            var userDto = mapper.Map<UpdateUserDTO>(user);

            return View(userDto);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(UpdateUserDTO updateUser)
        {
            var user = await userRepository.GetByIdAsync(updateUser.Id);

            if (user != null)
            {
                mapper.Map(updateUser, user);
                await userRepository.UpdateAsync(user);
                await userRepository.SaveChangesAsync();
            }

            return RedirectToAction("List");

        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null) return NotFound();

            await userRepository.DeleteAsync(user);

            await userRepository.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}