using Finances.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDTO jwt)
            => cache.Set(GetJwtKey(tokenId), jwt, TimeSpan.FromSeconds(5));

        public static JwtDTO GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDTO>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}
