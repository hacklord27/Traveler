﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Traveler.Models;

namespace Traveler.Design_pattern.Command_pattern
{
    public class EditTourCommand : ITourCommand
    {
        private readonly Tour _tour;
        private readonly TravelBookingEntities1 _context;

        public EditTourCommand(Tour tour, TravelBookingEntities1 context)
        {
            _tour = tour;
            _context = context;
        }

        public void Execute()
        {
            _context.Entry(_tour).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}