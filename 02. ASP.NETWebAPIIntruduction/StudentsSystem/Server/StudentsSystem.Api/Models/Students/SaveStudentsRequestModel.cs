namespace StudentsSystem.Api.Models.Students
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SaveStudentsRequestModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(450)]
        [Index(IsUnique = true)]
        public string Number { get; set; }
    }
}