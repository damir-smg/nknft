using System.ComponentModel.DataAnnotations;

namespace StudentAccount.Orchestrators.Student.Contract;

public class UpdateStudentRequest
{
    [Required] 
    public string FirstName { get; set; }

    [Required] 
    public string LastName { get; set; }
}