using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("groups")]
    public class Group:DbEntity
    {

        [Column("name")]
        [MaxLength(64)]
        public string Name { get; set; }

        [Column("facultyId")]
        public Guid FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public List<Student> Students { get; set; }
    }
}
