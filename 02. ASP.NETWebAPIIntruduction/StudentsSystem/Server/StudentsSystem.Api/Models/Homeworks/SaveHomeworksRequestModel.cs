namespace StudentsSystem.Api.Models.Homeworks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SaveHomeworksRequestModel
    {
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}