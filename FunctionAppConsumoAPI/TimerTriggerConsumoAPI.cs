using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FunctionAppConsumoAPI.Interfaces;
using Refit;

namespace FunctionAppConsumoAPI
{
    public class TimerTriggerConsumoAPI
    {
        public readonly IContagemClient _contagemClient;

        public TimerTriggerConsumoAPI(IContagemClient contagemClient)
        {
            _contagemClient = contagemClient;
        }

        [FunctionName("TimerTriggerConsumoAPI")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                var resultado = _contagemClient.GetResultado().Result;
                log.LogInformation($"Retorno JSON: {JsonSerializer.Serialize(resultado)}");
                log.LogInformation($"Valor do contador: {resultado.ValorAtual}");
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is ApiException apiException)
                    log.LogError($"Erro durante chamada à API de contagem: {apiException.StatusCode}");
                else
                    log.LogError($"Ocorreu um erro: {ex.GetType().FullName}");
            }

            log.LogInformation($"TimerTriggerConsumoAPI executada em: {DateTime.Now}");
        }
    }
}