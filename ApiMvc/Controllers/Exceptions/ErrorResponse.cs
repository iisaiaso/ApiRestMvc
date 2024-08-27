﻿namespace ApiMvc.Controllers.Exceptions
{
    public class ErrorResponse
    {
        public string? Message { get; set; }
        public IList<ErrorValidationModel> Errors { get; set; } = new List<ErrorValidationModel>();
    }
}
