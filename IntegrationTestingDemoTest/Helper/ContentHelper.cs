using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTestingDemoTest.Helper
{
    internal class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
           => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
