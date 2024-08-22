namespace Entity.Dto.SecurityDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public uint? document { get; set; }
        public string? type_document { get; set; }
        public string? direction { get; set; }
        public string? phone { get; set; }
        public DateTime? birthday { get; set; }
        public bool state { get; set; }
        public DateTime? create_at { get; set; }
        public int cityId { get; set; }
    }
}
