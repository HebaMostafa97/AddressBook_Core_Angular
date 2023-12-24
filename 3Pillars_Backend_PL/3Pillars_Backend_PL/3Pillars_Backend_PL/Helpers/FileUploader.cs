using _3Pillars_Backend_DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.Helpers
{
    public class FileUploader
    {
        public static string UploadFile(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {


            try
            {

                var FolderPath = Path.Combine(webHostEnvironment.WebRootPath, "Images");

                string FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);

                string FinalPath = Path.Combine(FolderPath, FileName);

                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    file.CopyTo(Stream);
                }
                return "Images/" + FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public static void DeleteFile(string PhotoUrl, IWebHostEnvironment webHostEnvironment)
        {
            var filepath = Path.Combine(webHostEnvironment.WebRootPath, PhotoUrl);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }


    }
}
