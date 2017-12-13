using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core.Domain;
using Finances.Infrastructure.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Finances.Infrastructure.Services
{
    public class OperationTemplateProvider : IOperationTemplateProvider
    {
        private readonly IMemoryCache _cache;

        private readonly static string CacheKey = "OperationTemplate";

        private readonly static Dictionary<string, IEnumerable<OperationTemplateDetails>> operationTemplates =
           new Dictionary<string, IEnumerable<OperationTemplateDetails>>()
           {
               ["Food"] = new List<OperationTemplateDetails>()
               {
                   new OperationTemplateDetails("Dinner", 12M)
               },
               ["Books"] = new List<OperationTemplateDetails>()
               {
                   new OperationTemplateDetails("IT - King", 25M),
                   new OperationTemplateDetails("C#", 25M)
               },
               ["Games"] = new List<OperationTemplateDetails>()
               {
                   new OperationTemplateDetails("Witcher", 125M),
                   new OperationTemplateDetails("Witcher 2", 125M),
                   new OperationTemplateDetails("Witcher 3", 125M)
               }
           };

        public OperationTemplateProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<IEnumerable<OperationDTO>> BrowseAsync()
        {
            var operations = _cache.Get<IEnumerable<OperationDTO>>(CacheKey);
            if (operations == null)
            {
                operations = await GetAllAsync();
                _cache.Set(CacheKey, operations);
            }

            return operations;
        }

        private async Task<IEnumerable<OperationDTO>> GetAllAsync()
            => await Task.FromResult(operationTemplates.GroupBy(x => x.Key)
                .SelectMany(g => g.SelectMany(y => y.Value.Select(c => new OperationDTO
                {
                    Name = c.Name,
                    Value = c.Value
                }))));

        public async Task<OperationDTO> GetAsync(string category, string name)
        {
            if (!operationTemplates.ContainsKey(name))
            {
                throw new Exception($"Operation templates is empty for {category}");
            }
            var operations = operationTemplates[category];
            var operation = operations.SingleOrDefault(x => x.Name == name);
            if (operation == null)
            {
                throw new Exception($"Operation {name} for category {category} is not available");
            }

            return await Task.FromResult(new OperationDTO()
            {
                Name = name,
                Value = operation.Value
            });
        }

        private class OperationTemplateDetails
        {
            
            public string Name { get; }

            public decimal Value { get; }

            public OperationTemplateDetails(string name, decimal value)
            {
                Value = value;
                Name = name;
            }
        }
    }
}
