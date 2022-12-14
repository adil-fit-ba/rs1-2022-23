using System;

namespace FIT_Api_Examples.Helper
{
    public class Fajlovi
    {
        public static byte[] Ucitaj(string path)
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
    }
}
