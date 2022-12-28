using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOI.BOIApplications.Application.Contracts.Infrastructure
{
    public interface IHttpClientHelper
    {
        Task<T> GetAsync<T>(string endpoint, IDictionary<string, string> values);
        Task<List<T>> GetAllAsync<T>(string endpoint);
        Task<T> PostAsync<T, U>(string endpoint, U value);
        Task<T> GetAsync<T, U>(string endpoint, U value);
        Task<T> PostFormAsync<T>(string endpoint, IDictionary<string, string> values);
    }
}
