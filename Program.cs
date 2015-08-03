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
                FileHashes f = new FileHashes(file.FullName);
                Console.Write("Calculating MD5...");
                byte[] md5 = f.MD5;
                Console.WriteLine();

                Console.Write("Calulating SHA1...");
                byte[] sha1 = f.SHA1;
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(string.Format("MD5:\t{0}", GetByteString(md5)));
                Console.WriteLine(string.Format("SHA1:\t{0}", GetByteString(sha1)));
            }
            else
            {
                Console.WriteLine(file + " does not exist.");
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
