using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Junkosoft
{
    public class FileHashes
    {
        private string _filePath;

        public FileHashes(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Gets the MD5 for the specified file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>MD5 as a btye array</returns>
        public byte[] MD5
        {
            get
            {
                // Get the file and create a new instance of the MD5 object.
                FileInfo file = new FileInfo(_filePath);
                MD5 md5Hasher = System.Security.Cryptography.MD5.Create();

                // Convert the input string to a byte array and compute the hash.
                using (FileStream fs = file.OpenRead())
                {
                    return md5Hasher.ComputeHash(fs);
                }
            }
        }

        /// <summary>
        /// Gets the SHA1 for the specified file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>SHA1 as a byte array</returns>
        public byte[] SHA1
        {
            get
            {
                // Get the file and create a new instance of the SHA1 object.
                FileInfo file = new FileInfo(_filePath);
                SHA1 sha1Hasher = System.Security.Cryptography.SHA1.Create();

                // Convert the input string to a byte array and compute the hash.
                using (FileStream fs = file.OpenRead())
                {
                    return sha1Hasher.ComputeHash(fs);
                }
            }
        }
    }
}
