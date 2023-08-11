﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Responses
{
    public class BaseCommandResponses
    {
        public int Id { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public List<string> Errors { get; set; }
    }
}
