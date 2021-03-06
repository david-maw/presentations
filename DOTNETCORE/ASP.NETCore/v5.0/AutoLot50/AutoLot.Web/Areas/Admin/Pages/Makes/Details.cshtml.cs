﻿using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class DetailsModel : PageModel
    {
        private readonly IMakeRepo _repo;

        public DetailsModel(IMakeRepo repo)
        {
            _repo = repo;
        }

        public Make Make { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Make = _repo.Find(id.Value);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
