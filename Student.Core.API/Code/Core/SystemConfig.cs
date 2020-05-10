using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Core.API.Code.Core
{
    public class SystemConfig
    {
        /// <summary>
        /// 学生照片上传路径
        /// </summary>
        /// <returns></returns>
        public static string photosPath()
        {
            var photosPath = Path.Combine(uploadPath(), "StudentPhotos");
            if (!Directory.Exists(photosPath))
            {
                Directory.CreateDirectory(photosPath);
            }
            return photosPath;
        }

        private static string uploadPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Upload");
        }
    }
}
