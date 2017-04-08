using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Jimismith.Versioning.Example
{
    public static class ActionDescriptorExtensions
    {
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {
            return actionDescriptor?.Properties
                .Where((kvp) => (kvp.Key as Type).Equals(typeof(ApiVersionModel)))
                .Select(kvp => kvp.Value as ApiVersionModel).FirstOrDefault();
        }
    }
}