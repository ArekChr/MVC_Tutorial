﻿using KursMVC.Models;
using System;
using System.Collections.Generic;

namespace KursMVC.ViewModels
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> PozycjeKoszyka { get; set; }
        public decimal CenaCalkowita { get; set; }
    }
}