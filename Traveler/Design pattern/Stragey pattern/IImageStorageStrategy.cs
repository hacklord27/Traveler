using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Traveler.Design_pattern.Stragey_pattern
{
    internal interface IImageStorageStrategy
    {
        void SaveImage(HttpPostedFileBase image, string imagePath);
    }
}
