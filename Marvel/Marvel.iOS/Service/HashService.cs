using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Foundation;
using Marvel.iOS.Service;
using Marvel.Service;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(HashService))]
namespace Marvel.iOS.Service
{
    class HashService : IHashService
    {
        public string CreateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashed = md5.ComputeHash(inputBytes);

            var hex = new StringBuilder(hashed.Length * 2);
            foreach (var b in hashed)
                hex.Append($"{b:x2}");

            var result = hex.ToString();

            return result;
        }
    }
}