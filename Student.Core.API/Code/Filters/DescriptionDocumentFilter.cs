﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Student.Core.API.Code.Filters
{
    /// <summary>
    /// 控制器和方法的描述信息处理
    /// </summary>
    public class DescriptionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            SetControllerDescription(swaggerDoc, context);
            SetActionDescription(swaggerDoc, context);
            SetModelDescription(swaggerDoc, context);
        }

        /// <summary>
        /// 设置控制器的描述信息
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        private void SetControllerDescription(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Tags == null)
                swaggerDoc.Tags = new List<OpenApiTag>();

            foreach (var apiDescription in context.ApiDescriptions)
            {
                if (apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) && methodInfo.DeclaringType != null)
                {
                    var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo.DeclaringType, typeof(DescriptionAttribute));
                    if (descAttr != null && descAttr.Description.NotNull())
                    {
                        var controllerName = methodInfo.DeclaringType.Name;
                        controllerName = controllerName.Remove(controllerName.Length - 10);
                        if (swaggerDoc.Tags.All(t => t.Name != controllerName))
                        {
                            swaggerDoc.Tags.Add(new OpenApiTag
                            {
                                Name = controllerName,
                                Description = descAttr.Description
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置方法的说明
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        private void SetActionDescription(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var path in swaggerDoc.Paths)
            {
                if (path.Value != null && path.Value.Operations != null && path.Value.Operations.Any())
                {
                    foreach (var operation in path.Value.Operations)
                    {
                        if (TryGetActionDescription(path.Key, operation.Key, context, out OpenApiOperation oper))
                        {
                            operation.Value.Description = oper.Description;
                            operation.Value.OperationId = oper.OperationId ?? oper.Description;
                            foreach (var param in oper.Parameters)
                            {
                                var obj = operation.Value.Parameters.FirstOrDefault(p => p.Name.ToLower() == param.Name.ToLower());
                                if(obj != null)
                                {
                                    obj.Description = param.Description;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置模型属性描述信息
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        private void SetModelDescription(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pro = typeof(SchemaRepository).GetField("_reservedIds", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pro == null)
                return;

            var schemaTypes = (Dictionary<Type, string>)pro.GetValue(context.SchemaRepository);

            foreach (var schema in context.SchemaRepository.Schemas)
            {
                var type = schemaTypes.FirstOrDefault(m => m.Value.EqualsIgnoreCase(schema.Key)).Key;
                if (type == null || !type.IsClass)
                    continue;

                var properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    var propertySchema = schema.Value.Properties.FirstOrDefault(m => m.Key.EqualsIgnoreCase(propertyInfo.Name)).Value;
                    if (propertySchema != null)
                    {
                        var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(DescriptionAttribute));
                        if (descAttr != null && descAttr.Description.NotNull())
                        {
                            propertySchema.Title = descAttr.Description;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取说明
        /// </summary>
        private bool TryGetActionDescription(string path, OperationType type, DocumentFilterContext context, out OpenApiOperation oper)
        {
            oper = new OpenApiOperation();
            foreach (var apiDescription in context.ApiDescriptions)
            {
                var apiPath = "/" + apiDescription.RelativePath.ToLower();
                var method = apiDescription.HttpMethod.ToLower();
                if (apiPath.Equals(path.ToLower()) && method.Equals(type.ToString().ToLower()) && apiDescription.TryGetMethodInfo(out MethodInfo methodInfo))
                {
                    var descAttr = (DescriptionAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(DescriptionAttribute));
                    var operAttr = (OperationIdAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(OperationIdAttribute));
                    var paramAttrs = Attribute.GetCustomAttributes(methodInfo, typeof(ParametersAttribute));
                    if (descAttr != null && descAttr.Description.NotNull())
                    {
                        oper.Description = descAttr.Description;
                    }
                    if (operAttr !=null && operAttr.OperationId.NotNull())
                    {
                        oper.OperationId = operAttr.OperationId;
                    }

                    foreach (ParametersAttribute paramAttr in paramAttrs)
                    {
                        if (paramAttr != null && paramAttr.name.NotNull())
                        {
                            oper.Parameters.Add(new OpenApiParameter() { Name = paramAttr.name, Description = paramAttr.param });
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
