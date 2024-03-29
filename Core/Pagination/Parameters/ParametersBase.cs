﻿namespace Core.Pagination.Parameters;

public class ParametersBase
{
    public string? OrderByParam { get; set; }
    public string? OrderByDirection { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}