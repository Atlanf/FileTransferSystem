using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferSystem.Logic.Helper
{
    public class FileSplitter
    {
        public int FilePortionSize { get; private set; }
        public int FileSize { get; private set; }

        public FileSplitter(int filePortionSize)
        {
            FilePortionSize = filePortionSize;
        }

        public async Task<byte[,]> SplitFileAsync(string filePath)
        {
            var fileAsBytes = await File.ReadAllBytesAsync(filePath);
            FileSize = fileAsBytes.Length;

            var portionsCount = (int)Math.Ceiling((double)(FileSize / FilePortionSize));

            return new byte[portionsCount, FilePortionSize];
        }
    }
}
