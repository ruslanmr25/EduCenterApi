namespace EduCenterApi.Domain.Entities;

public class StudentPaymentSycle
{
    public int Id { get; set; }

    public Student Student { get; set; }

    public int StudentId { get; set; }


    public int Amount { get; set; }

    public int AmountPaid { get; set; }

    public string Status { get; set; } = "inactive";


    public DateTime SycleBeginDate { get; set; }
    public DateTime SycleEndDate { get; set; }

    public List<Group> Groups { get; set; } 


}
