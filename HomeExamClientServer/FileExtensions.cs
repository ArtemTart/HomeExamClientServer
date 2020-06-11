using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HomeExamClientServer
{
 public static  class FileExtensions
    {

        //extension method to delte async ,delete operation is not taling much time but anyway 
        public static Task DeleteAsync(this FileInfo fi)
        {
            return Task.Factory.StartNew(() => fi.Delete());
        }
    }
}
