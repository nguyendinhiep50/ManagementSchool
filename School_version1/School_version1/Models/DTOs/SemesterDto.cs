﻿namespace School_version1.Models.DTOs
{
    public class SemesterDto
    {
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime SemesterDayBegin { get; set; }
        public DateTime SemesterDayEnd { get; set; }
    }
}
