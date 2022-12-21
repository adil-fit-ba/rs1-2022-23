using System;
using System.IO;

namespace FIT_Api_Examples.Helper
{
    public class Fajlovi
    {
        public static byte[]? Ucitaj(string path)
        {
            try
            {
                return System.IO.File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void Snimi(byte[] bajtoviBytes, string path)
        {
            var directoryName = Path.GetDirectoryName(path);
            if (directoryName != null)
                System.IO.Directory.CreateDirectory(directoryName);

            using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            fs.Write(bajtoviBytes, 0, bajtoviBytes.Length);
            fs.Close();
        }
    }
}