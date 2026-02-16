namespace HospitalMangement.API.Models;

public class Patient
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public DateTime DateOfAdmit { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }

    public User User { get; set; }
}
