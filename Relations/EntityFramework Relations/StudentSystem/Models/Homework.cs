﻿namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;


    public enum ContentType
    {
        application,
        zip,
        pdf
    }
    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}