using SourceControlSystem.Common.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SourceControlSystem.Models
{
    public class SoftwareProject
    {
        private ICollection<Commit> commits;
        private ICollection<User> users;

        public SoftwareProject()
        {
            this.users = new HashSet<User>();
            this.commits = new HashSet<Commit>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxProjectName)]
        public string Name { get; set; }

        public bool Private { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(ValidationConstants.MaxProjectDescription)]
        public string Description { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }
        }

        public virtual ICollection<Commit> Commits
        {
            get
            {
                return this.commits;
            }
        }
    }
}
