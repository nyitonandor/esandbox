using System;
using System.Collections.Generic;

namespace EClient.Helpers
{
    public static class Utils
    {
        public static string GetMotorcycleName()
        {
            var random = new Random();
            var list = new List<string> { "Yamaha", "Suzuki", "Kawasaki", "Harley" };
            int index = random.Next(list.Count);

            return list[index];
        }

        public static string CreateSerialNumber(string name, string id)
        {
            return $"{name.Substring(0, 3)}-{id}";
        }
    }
}
