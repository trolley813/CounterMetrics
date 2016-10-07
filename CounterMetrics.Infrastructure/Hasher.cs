﻿using System.Security.Cryptography;
using System.Text;

namespace CounterMetrics.Infrastructure
{
    internal class Hasher : IHasher
    {
        private readonly MD5 engine = MD5.Create();

        public string Hash(string source)
        {
            //throw new NotImplementedException();
            var data = engine.ComputeHash(Encoding.UTF8.GetBytes(source));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var stringBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
                stringBuilder.Append(data[i].ToString("x2"));

            // Return the hexadecimal string.
            return stringBuilder.ToString();
        }
    }
}