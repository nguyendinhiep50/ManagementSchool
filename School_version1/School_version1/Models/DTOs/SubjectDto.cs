﻿namespace School_version1.Models.DTOs
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectCredit { get; set; }
        public bool SubjectMandatory { get; set; }
    }
}
