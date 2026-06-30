namespace AdventureGuildApi.Dtos
{
    public class ValidationErrorResponseDto
    {
        public List<string> Errors { get; set; } = new();
    }
}
