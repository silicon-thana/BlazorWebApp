﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Data;

public class FileEntity
{
    [Key]
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string? ContentType { get; set; }
    public string? ContainerName { get; set; }

}