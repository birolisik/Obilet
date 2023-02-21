using Microsoft.AspNetCore.Http;
using Obilet.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Obilet.Infrastructure.Repositories
{
    public class CookieManager:ICookieManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get(string key)
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies.Count > 0 ? _httpContextAccessor.HttpContext.Request.Cookies[key] : "";

            return cookieValueFromContext;
        }

        public void Set(string key, string value, DateTime? expireDate)
        {
            CookieOptions option = new CookieOptions();

            if (expireDate.HasValue)
                option.Expires = expireDate;
            else
                option.Expires = DateTime.Now.AddMinutes(1);

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }

        public T Get<T>()
        {
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies[typeof(T).Name];
            if (string.IsNullOrEmpty(cookieValueFromContext)) return default(T);

            return JsonSerializer.Deserialize<T>(cookieValueFromContext);
        }

        public void Set<T>(T model)
        {
            var json = JsonSerializer.Serialize(model);

            this.Set(typeof(T).Name, json, DateTime.Now.AddMonths(1));
        }
    }
}
