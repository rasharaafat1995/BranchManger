using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Xml;

namespace BranchManagement.API.Helpers
{
    public static class SerializationHelper
    {
        public static ActionResult SerializeObject(this object model)
        {
            var serialization = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return new ContentResult
            {
                Content = serialization,
                ContentType = "application/json"
            };
        }
    }
}
