using System;
using System.Collections.Generic;
using System.Text;

namespace Marvel.Service
{
    public interface IHashService
    {
        string CreateMd5Hash(string input);
    }
}
