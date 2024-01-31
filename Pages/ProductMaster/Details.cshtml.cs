﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Joke_App.Data;
using Joke_App.Models;

namespace Joke_App.Pages.ProductMaster
{
    public class DetailsModel : PageModel
    {
        private readonly Joke_App.Data.ApplicationDbContext _context;

        public DetailsModel(Joke_App.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Task { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FirstOrDefaultAsync(m => m.ID == id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                Task = task;
            }
            return Page();
        }
    }
}
