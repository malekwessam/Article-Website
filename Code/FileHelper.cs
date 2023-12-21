using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ArticleProject.Code
{
    public class FileHelper
    {
        private readonly IWebHostEnvironment webHost;

        public FileHelper(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }


        //upload files عشان الصور 

        public string UploadFile (IFormFile file,string folder)
        {
            if (file != null)
            {
                var fileDir=Path.Combine(webHost.WebRootPath, folder);
                var fileName=Guid.NewGuid()+ "_" +file.FileName;
                var filePath=Path.Combine(fileDir,fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create)) 
                {
                    file.CopyTo(fileStream);
                    return fileName;
                }
            }
            else {
                return string.Empty;
            }
        }
    }
}
