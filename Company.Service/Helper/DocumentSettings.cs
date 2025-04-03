using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file,string folderName)
        {
            // 1. Get FolderPath

            //var folderPath = @"C:\\Users\\Ahmed Yassin\\source\\repos\\Company.Web\\Company.Web\\wwwroot\\File\\Images\\";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Files", folderName);

            // 2. Get File Name
            var fileName=$"{Guid.NewGuid()}_{file.FileName}";

            // 3. Combine FolderPath + FilePath
            var filePath=Path.Combine(folderPath, fileName);

            //4. Save File
            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
