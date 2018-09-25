﻿
using System.Collections.Generic;

namespace LivrariaApiModel.Dtos
{
    public class PedidoDto : DtoBase
    {
        public List<LivroDto> Livros { get; set; }
        public float Valor { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
