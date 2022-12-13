
using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIT_Api_Examples.Helper
{
    public static class Fajlovi
    {
        public static void Snimi(this byte[] nova_slika, string filename)
        {
            using var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            fs.Write(nova_slika, 0, nova_slika.Length);
        }

        public static byte[] Ucitaj(string filename)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(filename);
                return bytes;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
