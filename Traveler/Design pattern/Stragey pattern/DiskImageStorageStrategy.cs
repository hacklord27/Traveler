using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Traveler.Design_pattern.Stragey_pattern
{
    public class DiskImageStorageStrategy : IImageStorageStrategy
    {
        public void SaveImage(HttpPostedFileBase image, string imagePath)
        {
            if (image != null)
            {
                var fileName = Path.GetFileName(image.FileName);
                var path = Path.Combine(imagePath, fileName);
                image.SaveAs(path);
            }
        }
    }

    public class CloudImageStorageStrategy : IImageStorageStrategy
    {
        public void SaveImage(HttpPostedFileBase image, string imagePath)
        {
            // Implement logic to save image to cloud storage
        }
    }
}