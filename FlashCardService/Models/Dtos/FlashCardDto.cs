namespace FlashCardService.Models.Dtos;

public class FlashCardDto
{
    public int Id { get; set; }
    public string FrontOfFlashCard { get; set; }
    public string BackOfFlashCard { get; set; }
    public string Category { get; set; }
}