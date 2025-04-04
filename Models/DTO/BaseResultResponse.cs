﻿namespace Models.DTO;
public class BaseResultResponse<T>
{
	public bool Success { get; set; }
	public string? Message { get; set; }
	public T? Data { get; set; }
}