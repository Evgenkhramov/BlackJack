﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DataAccesLayer.Interfeces;


namespace DataAccesLayer.Service
{
    public class DirectoryAndFileOfHistoryService : IHistoryFileService
    {
        public string CreateDirectory(string path, string subpath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            string fullName = $@"{path}\{subpath}";
            DirectoryInfo nextDirInfo = new DirectoryInfo(fullName);
            if (!nextDirInfo.Exists)
            {
                dirInfo.CreateSubdirectory(subpath);
            }
            return fullName;
        }
        public string CreateFile(string filename, string directoryFullName)
        {
            string fullFileName = $@"{directoryFullName}\{filename}";
            if (File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
            }
            return fullFileName;
        }
    }
}
