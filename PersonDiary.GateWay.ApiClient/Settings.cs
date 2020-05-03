using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.GateWay.ApiClient
{
    public static class Settings
    {
        public static string LifeEventMicroServiceUrl { get; } = "https://localhost:44300";
        public static string PersonMicroServiceUrl { get; } = "https://localhost:44393";
    }
}
