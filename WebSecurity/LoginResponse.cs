using System;
using System.Collections.Generic;
using System.Text;

namespace WebSecurity
{
    public class LoginResponse
    {
        public LoginResponse() { }

        public LoginStatus Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public enum LoginStatus
    {
        Locked = 0,
        AccountLocked = 1,
        InvalidCredential = 2,
        Succeded = 3,
        TimeoutLocked = 4,
        Failed = 5
    }
}
