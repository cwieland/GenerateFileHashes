using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Junkosoft
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Program app = new Program(args[0]);
            }
            else
            {
                // Show a usage screen
                Console.WriteLine("Usage:");
                Console.WriteLine();
                Console.WriteLine("GenerateMD5.exe <filename>");
            }
        }

        public Program(string filename)
        {
            FileInfo file = new FileInfo(filename);
            if (file.Exists)
            {
                ProcessFile(file);
            }
            else
            {
                DirectoryInfo directory = new DirectoryInfo(filename);
                if (directory.Exists)
                {
                    ProcessFolder(directory);
                }
                else
                {
                    Console.WriteLine(file + " does not exist.");
                }
            }
        }

        /// <summary>
        /// Processes a file
        /// </summary>
        /// <param name="file">File to process</param>
        private void ProcessFile(FileInfo file)
        {
            FileHashes f = new FileHashes(file.FullName);
            Console.WriteLine(file.FullName);
            Console.Write("MD5\t");
            byte[] md5 = f.MD5;
            Console.WriteLine(GetByteString(md5));

            Console.Write("SHA1\t");
            byte[] sha1 = f.SHA1;
            Console.WriteLine(GetByteString(sha1));
            Console.WriteLine();
        }

        /// <summary>
        /// Processes files in a directory and sub-directories
        /// </summary>
        /// <param name="directory">Directory to process</param>
        private void ProcessFolder(DirectoryInfo directory)
        {
            foreach (FileInfo file in directory.GetFiles())
            {
                ProcessFile(file);
            }

            foreach (DirectoryInfo subdir in directory.GetDirectories())
            {
                ProcessFolder(subdir);
            }
        }

        /// <summary>
        /// Returns the specified byte array as a string containing HEX values for each byte
        /// </summary>
        /// <param name="value">byte array</param>
        /// <returns></returns>
        private string GetByteString(byte[] data)
        {
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
