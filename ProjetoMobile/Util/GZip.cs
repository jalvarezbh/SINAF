using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ProjetoMobile.Util
{
    public class GZip
    {
        public static void Compactar(FileInfo fi)
        {
            using (FileStream inFile = fi.OpenRead())
            {
                using (FileStream outFile = File.Create(fi.FullName + ".gz"))
                {
                    using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                    {
                        byte[] buffer = new byte[4096];
                        int numRead;
                        while ((numRead = inFile.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            Compress.Write(buffer, 0, numRead);
                        }
                    }
                }
            }
        }

        public static void Descompactar(FileInfo fi)
        {
            try
            {

                using (FileStream inFile = fi.OpenRead())
                {
                    string curFile = fi.FullName;
                    string origName = curFile.Remove(curFile.Length - fi.Extension.Length, fi.Extension.Length);

                    using (FileStream outFile = File.Create(origName))
                    {
                        using (GZipStream Decompress = new GZipStream(inFile, CompressionMode.Decompress))
                        {
                            byte[] buffer = new byte[4096];
                            int numRead;
                            while ((numRead = Decompress.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                outFile.Write(buffer, 0, numRead);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
