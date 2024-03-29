﻿namespace Core.Entities;

public class Comment
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; } 
    public bool Edited { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Content { get; set; } 
    public int Rate { get; set; }
    public int? ShelfId { get; set; }
    public Shelf Shelf { get; set; }
    public int? BookCopyId { get; set; }
    public BookCopy BookCopy { get; set; }
    public int? BookId { get; set; }
    public Book Book { get; set; }
}