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

            var folderPath = @"C:\Users\ahmed\Source\Repos\C43-G02-MVC03\Company.Web\wwwroot\File\Images\";

            //var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Files", folderName);

            // 2. Get File Name
            var fileName=$"{Guid.NewGuid()}-{file.FileName}";

            // 3. Combine FolderPath + FilePath
            var filePath=Path.Combine(folderPath, fileName);

            //4. Save File
            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
