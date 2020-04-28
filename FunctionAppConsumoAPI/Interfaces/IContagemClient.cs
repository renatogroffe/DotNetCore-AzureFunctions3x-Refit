using System.Threading.Tasks;
using Refit;
using FunctionAppConsumoAPI.Models;

namespace FunctionAppConsumoAPI.Interfaces
{
    public interface IContagemClient
    {
         [Get("")]
         Task<ResultadoContador> GetResultado();             
    }
}