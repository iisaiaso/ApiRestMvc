namespace ApiMvc.Controllers.Exceptions
{
    public class ErrorValidationModel: ErrorModel
    {
        public string? FieldName { get; set; }
    }
}
