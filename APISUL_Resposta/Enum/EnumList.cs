using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APISUL_Resposta.Enum
{
    public class EnumList
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EElvadores
        {
            A = 'A',
            B = 'B',
            C = 'C',
            D = 'D',
            E = 'E',
        }
    }
}