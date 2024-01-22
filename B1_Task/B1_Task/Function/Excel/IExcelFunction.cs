﻿using Microsoft.AspNetCore.Mvc;

namespace B1_Task.Function.Excel
{
    public interface IExcelFunction
    {
        Task<List<List<object>>> UploadExcelFile(IFormFile file);
        Task<List<List<object>>> ReadExcelData(string filePath);
        Task<List<string>> ProcessExcelFile(IFormFile file);

    }
}