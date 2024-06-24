using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Orchestrators.Discipline.Contract;

public class UpdateDisciplineRequest
{
    [Required] 
    public string Name { get; set; }

    [Required]
    [Range(typeof(int), "0", "100")]
    public int Mark { get; set; }
}