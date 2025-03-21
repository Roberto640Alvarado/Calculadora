using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculadoraMatematica.Models;

namespace CalculadoraMatematica.Controllers
{
    public class CalculadoraController
    {
        public static async Task<string> Calcular(string expresion)
        {
            return await MathApiService.EvaluarExpresion(expresion);
        }
    }

}
