using DIGITAL_PERSON.Models.Dto;

namespace Entity.Dto
{
    public class Response: IResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
