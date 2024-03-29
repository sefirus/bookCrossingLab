﻿using Core.Enums;

namespace Core.ViewModels.BookViewModels;

public class SearchBookViewModel
{
    public int InternalId { get; set; }
    public string GoogleApiId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Authors { get; set; } = string.Empty;
    public string? ThumbnailLink { get; set; } = string.Empty;
    public SearchResultType SearchResultType { get; set; } = SearchResultType.GoogleBookApi;
}