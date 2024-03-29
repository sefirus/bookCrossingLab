﻿using Core.ViewModels.BookCopyViewModels;
using Core.ViewModels.CommentViewModels;

namespace Core.ViewModels.ShelfViewModels;

public class ReadShelfViewModel : ShelfVmBase
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public PagedViewModel<ReadCommentViewModel> PagedComments { get; set; }
    public PagedViewModel<ReadBookCopyViewModel> PagedBookCopies { get; set; }
    public IEnumerable<string> Pictures { get; set; }
}