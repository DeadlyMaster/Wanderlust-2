using System;
using System.Collections.Generic;
using System.Text;

namespace Wanderlust.Services
{
    public class ServiceAuthentificationException : Exception
    {
        public string Content { get; set; }
        public ServiceAuthentificationException(string content)
        {
            Content = content;
        }
    }
}
