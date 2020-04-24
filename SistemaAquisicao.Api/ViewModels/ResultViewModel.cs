namespace SistemaAquisicao.Api.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object EntityModel { get; set; }
        public string ErrorMessage { get; set; }
    }
}
