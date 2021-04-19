using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {

        private static string directory = Environment.CurrentDirectory + @"\wwwroot";
        private static string path = @"\Images\";

        public static IResult Add(IFormFile file)
        {
            if (file.Length > 0)
            {

                var name = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(file.FileName);
                using (FileStream stream = File.Create(directory + path + name + extension))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
                return new SuccessResult(name + extension);

            }
            return new ErrorResult();

        }

        public static IResult Delete(string file)
        {
            File.Delete((directory + path + file));
            return new SuccessResult();
        }

        public static IResult Update(IFormFile file, string imagePath)
        {
            if (file.Length > 0)
            {
                var guidName = Guid.NewGuid().ToString();
                var type = Path.GetExtension(file.FileName);
                FileHelper.Delete(imagePath);
                FileHelper.Add(file);
                return new SuccessResult((guidName + type));
            }
            return new ErrorResult();
        }

    }
}
