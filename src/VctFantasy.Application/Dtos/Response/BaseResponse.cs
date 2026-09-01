using System;
using System.Collections.Generic;
using System.Text;

namespace VctFantasy.Application.Dtos.Response
{
    public class BaseResponse<T>
    {
        public List<T>? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public static BaseResponse<T> OkList(List<T> data, string? message = null) =>
            new() { Success = true, Data = data, Message = message };

        public static BaseResponse<T> Ok(T data, string? message = null) =>
            new() { Success = true, Data = new List<T> { data }, Message = message };

        public static BaseResponse<T> Fail(string error, List<string>? errors = null) =>
            new() { Success = false, Errors = errors ?? [error] };
    }
}
