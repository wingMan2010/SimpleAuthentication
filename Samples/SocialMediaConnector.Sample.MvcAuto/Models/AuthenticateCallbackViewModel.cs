﻿using System;
using SocialMediaConnector.Core;

namespace SocialMediaConnector.MvcAuto.Models
{
    public class AuthenticateCallbackViewModel
    {
        public IAuthenticatedClient AuthenticatedClient { get; set; }
        public Exception Exception { get; set; }
        public string ReturnUrl { get; set; }
    }
}