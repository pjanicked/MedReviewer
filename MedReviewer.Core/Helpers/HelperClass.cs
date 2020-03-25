using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedReviewer.Core.Helpers
{
    public static class HelperClass
    {
        public static class UserSession
        {
            public static string OktaUserId { get; set; }
            public static string UserName { get; set; }
            public static string UserEmail { get; set; }
        }

        public static string classToJson(Object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T jsonToClass<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
