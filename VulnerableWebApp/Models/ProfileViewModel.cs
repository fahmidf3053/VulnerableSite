using Azure.Core;
using System;
using System.Collections.Generic;

namespace VulnerableWebApp.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            RequestToBeSent = new();
            IncomingRequest = new();
        }

        public string Name { get; set; }
        public List<User> RequestToBeSent { get; set; }
        public List<Request> IncomingRequest { get; set; }
    }
}
