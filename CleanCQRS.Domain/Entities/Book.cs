using CleanCQRS.Domain.Common.Entities;
using CleanCQRS.Domain.Enums;
using System;

namespace CleanCQRS.Domain.Entities
{
    public class Book : BaseEntity
    {        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public BookCategory Category { get; set; }
    }
}
