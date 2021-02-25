using Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("students")]
    public class Student:DbEntity
    {
        [Column("firstName")]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Column("groupId")]
        public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}
