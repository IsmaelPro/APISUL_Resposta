using APISUL_Resposta.Enum;
using APISUL_Resposta.Interface;
using APISUL_Resposta.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static APISUL_Resposta.Enum.EnumList;

namespace APISUL_Resposta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevadoresController : ControllerBase
    {
        private readonly IElevadorService _elevadorService;

        public ElevadoresController(IElevadorService elevadorService)
        {
            _elevadorService = elevadorService;
        }

        [HttpPost("AndarMenosUtilizado")]
        public ActionResult AndarMenosUtilizado([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.andarMenosUtilizado();
            return Ok(resultado);
        }

        [HttpPost("PeriodoMaiorUtilizacaoConjuntoElevadores")]
        public ActionResult PeriodoMaiorUtilizacaoConjuntoElevadores([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.periodoMaiorUtilizacaoConjuntoElevadores();
            return Ok(resultado);
        }

        [HttpPost("ElevadorMaisFrequentado")]
        public ActionResult ElevadorMaisFrequentado([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.elevadorMaisFrequentado();
            return Ok(resultado);
        }

        [HttpPost("periodoMaiorFluxoElevadorMaisFrequentado")]
        public ActionResult PeriodoMaiorFluxoElevadorMaisFrequentado([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.periodoMaiorFluxoElevadorMaisFrequentado();
            return Ok(resultado);
        }

        [HttpPost("ElevadorMenosFrequentado")]
        public ActionResult ElevadorMenosFrequentado([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.elevadorMenosFrequentado();
            return Ok(resultado);
        }

        [HttpPost("PeriodoMenorFluxoElevadorMenosFrequentado")]
        public ActionResult PeriodoMenorFluxoElevadorMenosFrequentado([FromBody] List<ElevadoresData> list)
        {
            _elevadorService.Elevadores = list;
            var resultado = _elevadorService.periodoMenorFluxoElevadorMenosFrequentado();
            return Ok(resultado);
        }

        [HttpPost("PercentualDeUsoElevador")]
        public ActionResult PercentualDeUsoElevador([FromBody] List<ElevadoresData> list, EElvadores elevador)
        {
            _elevadorService.Elevadores = list;
            var resultado = 0f;

            switch (elevador)
            {
                case EElvadores.A:
                    resultado = _elevadorService.percentualDeUsoElevadorA();
                    break;

                case EElvadores.B:
                    resultado = _elevadorService.percentualDeUsoElevadorB();
                    break;

                case EElvadores.C:
                    resultado = _elevadorService.percentualDeUsoElevadorC();
                    break;

                case EElvadores.D:
                    resultado = _elevadorService.percentualDeUsoElevadorD();
                    break;

                case EElvadores.E:
                    resultado = _elevadorService.percentualDeUsoElevadorE();
                    break;

                default:
                    break;
            }

            //return Ok(Math.Round(resultado, 2)+'%');
            return Ok(resultado.ToString("F")+'%');
        }
    }
}