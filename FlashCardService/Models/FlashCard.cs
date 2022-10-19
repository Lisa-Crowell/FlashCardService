using System.ComponentModel.DataAnnotations;

namespace FlashCardService.Models;

public class FlashCard
{
    [Required]
    public int Id { get; set; }
    public string FrontOfFlashCard { get; set; }
    public string BackOfFlashCard { get; set; }
    public string Category { get; set; }
}