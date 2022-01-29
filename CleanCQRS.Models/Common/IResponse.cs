using System;

namespace CleanCQRS.Models.Common
{
    public interface IResponse//<T>
    {
        //T Data { get; set; }
        string[] Errors { get; set; }
        Exception Exception { get; set; }
        string Message { get; set; }
        bool Succeeded { get; set; }
        bool Warning { get; set; }
    }
}