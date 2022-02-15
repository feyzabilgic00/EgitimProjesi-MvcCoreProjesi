using System;
using System.Collections.Generic;

namespace CoreApp102.Mvc.DTOs
{
    public class ErrorDto
    {
        public ErrorDto() => Errors = new List<string>();
        public List<String> Errors { get; set; }
        public int Status { get; set; }

    }
}
