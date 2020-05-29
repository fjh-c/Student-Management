using Microsoft.OpenApi.Models;
using Student.DTO.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Student.Core.API.Code.Filters
{
    public class IgnorePropertyRequestBodyFilter : IRequestBodyFilter
    {
        public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
        {
            if (requestBody.Content.Keys.Contains("multipart/form-data"))
            {
                var pro = typeof(SchemaRepository).GetField("_reservedIds", BindingFlags.NonPublic | BindingFlags.Instance);
                if (pro == null)
                    return;

                var schemaTypes = (Dictionary<Type, string>)pro.GetValue(context.SchemaRepository);
                var pros = requestBody.Content["multipart/form-data"].Schema.Properties;

                foreach (var schema in pros)
                {
                    var s = context.FormParameterDescriptions.FirstOrDefault(p => p.Name == schema.Key);
                    var displayAttr = s?.ModelMetadata.DisplayName;
                    var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(s.PropertyInfo(), typeof(DescriptionAttribute));
                    var ignoreProperties = (IgnorePropertyAttribute)Attribute.GetCustomAttribute(s.PropertyInfo(), typeof(IgnorePropertyAttribute));
                    if(ignoreProperties != null)
                    {
                        pros.Remove(schema.Key);
                        continue;
                    }

                    if (displayAttr != null)
                    {
                        schema.Value.Description = displayAttr;
                        continue;
                    }
                    if (descAttr != null && descAttr.Description.NotNull())
                    {
                        schema.Value.Description = descAttr.Description;
                    }
                }
            }
            
        }
    }
}
