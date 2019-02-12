using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Interfeces
{
    public interface IHistoryFileService
    {
        string CreateDirectory(string path, string subpath);
        string CreateFile(string filename, string directoryFullName);
    }
}
