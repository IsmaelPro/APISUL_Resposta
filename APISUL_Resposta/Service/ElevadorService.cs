using APISUL_Resposta.Interface;
using APISUL_Resposta.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISUL_Resposta.Service
{
    public class ElevadorService : IElevadorService
    {
        public List<ElevadoresData> Elevadores { get; set; }

        public List<int> andarMenosUtilizado()
        {
            var entrada = Elevadores.Select(x => x.Andar).ToList();

            var index = 0;
            var menorRepetição = 0;
            var resultadoFinal = new List<int>();
            entrada.ForEach(x =>
            {
                var contagem = entrada.Where(y => y == x).Count();
                if (index == 0)
                {
                    menorRepetição = contagem;
                }
                if (contagem < menorRepetição)
                {
                    menorRepetição = contagem;
                }
                index++;
            });
            entrada.ForEach(x =>
            {
                if (entrada.Where(o => o == x).Count() == menorRepetição && !resultadoFinal.Contains(x))
                {
                    resultadoFinal.Add(x);
                }
            });
            return resultadoFinal.Distinct().ToList();
        }

        public List<char> elevadorMaisFrequentado()
        {
            var frequênciaDeUso = Elevadores.Select(x => x.Elevador).ToList();

            return MaiorOcorrencia(frequênciaDeUso).Distinct().ToList();
        }

        public List<char> elevadorMenosFrequentado()
        {
            var frequênciaDeUso = Elevadores.Select(x => x.Elevador).ToList();
            return MenorOcorrencia(frequênciaDeUso).Distinct().ToList();
        }

        public float percentualDeUsoElevadorA()
        {
            float entrada = Elevadores.Where(x => x.Elevador.Equals('A')).Count();
            float percentual = (entrada / Elevadores.Count()) * 100;
            return percentual;
        }

        public float percentualDeUsoElevadorB()
        {
            float entrada = Elevadores.Where(x => x.Elevador.Equals('B')).Count();
            float percentual = (entrada / Elevadores.Count()) * 100;
            return percentual;
        }

        public float percentualDeUsoElevadorC()
        {
            float entrada = Elevadores.Where(x => x.Elevador.Equals('C')).Count();
            float percentual = (entrada / Elevadores.Count()) * 100;
            return percentual;
        }

        public float percentualDeUsoElevadorD()
        {
            float entrada = Elevadores.Where(x => x.Elevador.Equals('D')).Count();
            float percentual = (entrada / Elevadores.Count()) * 100;
            return percentual;
        }

        public float percentualDeUsoElevadorE()
        {
            float entrada = Elevadores.Where(x => x.Elevador.Equals('E')).Count();
            float percentual = (entrada / Elevadores.Count()) * 100;
            return percentual;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            var maisFrequentadoList = elevadorMaisFrequentado();
            var entrada = new List<char>();

            maisFrequentadoList.ForEach(x =>
            {
                var fluxoPorElevadorList = Enumerable.Where(this.Elevadores, o => o.Elevador.Equals(x)).Select(o => o.Turno).ToList();
                entrada.Add(MaiorOcorrencia(fluxoPorElevadorList).FirstOrDefault());
            });

            return entrada.Distinct().ToList();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var entrada = Elevadores.Select(x => x.Turno).ToList();
            var resultadoFrequencia = MaiorOcorrencia(entrada);
            return resultadoFrequencia.Distinct().ToList();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            var menosFrequentadoList = elevadorMenosFrequentado();
            var entrada = new List<char>();

            menosFrequentadoList.ForEach((Action<char>)(x =>
            {
                var fluxoPorElevadorList = Enumerable.Where<ElevadoresData>(this.Elevadores, (Func<ElevadoresData, bool>)(o => (bool)o.Elevador.Equals((char)x))).Select(o => o.Turno).ToList();
                entrada.Add(MenorOcorrencia(fluxoPorElevadorList).FirstOrDefault());
            }));

            return entrada.Distinct().ToList();
        }

        private static List<char> MenorOcorrencia(List<char> frequênciaDeUso)
        {
            var index = 0;
            var menorRepetição = 0;
            var resultadoFinal = new List<char>();
            frequênciaDeUso.ForEach(x =>
            {
                var contagem = frequênciaDeUso.Where(y => y == x).Count();
                if (index == 0)
                {
                    menorRepetição = contagem;
                }
                if (contagem < menorRepetição)
                {
                    menorRepetição = contagem;
                }
                index++;
            });

            frequênciaDeUso.ForEach(x =>
            {
                if (frequênciaDeUso.Where(o => o == x).Count() == menorRepetição && !resultadoFinal.Contains(x))
                {
                    resultadoFinal.Add(x);
                }
            });
            return resultadoFinal;
        }

        private static List<char> MaiorOcorrencia(List<char> frequênciaDeUso)
        {
            var resultadoFinal = new List<char>();
            var ocorrenciasMaior = -1;
            for (var i = 0; i < frequênciaDeUso.Count; i++)
            {
                var ocorrencias = 1;
                for (var t = i + 1; t < frequênciaDeUso.Count; t++)
                    if (frequênciaDeUso[i] == frequênciaDeUso[t])
                        ocorrencias++;

                if (ocorrencias > ocorrenciasMaior)
                {
                    ocorrenciasMaior = ocorrencias;
                }
            }

            frequênciaDeUso.ForEach(x =>
            {
                if (frequênciaDeUso.Where(o => o == x).Count() == ocorrenciasMaior)
                {
                    resultadoFinal.Add(x);
                }
            });
            return resultadoFinal;
        }
    }
}