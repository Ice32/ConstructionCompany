﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionCompanyDataLayer.Models
{
    public class WorkerTask
    {
        public string WorkDescription { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
