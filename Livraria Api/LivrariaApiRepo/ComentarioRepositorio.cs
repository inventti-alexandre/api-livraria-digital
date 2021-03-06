﻿using LivrariaApiModel.Dtos;
using LivrariaApiModel.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaApiRepo
{
    public class ComentarioRepositorio : RepositorioBase
    {
        public static List<Comentario> Comentarios = new List<Comentario>(new Comentario[] {
                                                            new Comentario{
                                                                Id = 1,
                                                                IdLivro = 1,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 1"
                                                            },
                                                            new Comentario{
                                                                Id = 2,
                                                                IdLivro = 1,
                                                                IdUsuario = 2,
                                                                Conteudo = "Comentario 2"
                                                            },
                                                            new Comentario{
                                                                Id = 3,
                                                                IdLivro = 2,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 3"
                                                            },
                                                            new Comentario{
                                                                Id = 4,
                                                                IdLivro = 1,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 4"
                                                            },
                                                            new Comentario{
                                                                Id = 5,
                                                                IdLivro = 1,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 5"
                                                            },
                                                            new Comentario{
                                                                Id = 6,
                                                                IdLivro = 2,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 6"
                                                            },
                                                            new Comentario{
                                                                Id = 7,
                                                                IdLivro = 2,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 7"
                                                            },
                                                            new Comentario{
                                                                Id = 8,
                                                                IdLivro = 2,
                                                                IdUsuario = 1,
                                                                Conteudo = "Comentario 8"
                                                            }
        });

        public static List<Comentario> Listar(int pagina, int itensPorPagina)
        {
            if(pagina < 1 || itensPorPagina < 1 || pagina * itensPorPagina > Comentarios.Count)
            {
                return null;
            }
            return Comentarios.Where(c => c != null).Skip((pagina-1) * itensPorPagina).Take(itensPorPagina).ToList();
        }

        public static Comentario ObterPeloId(int id)
        {
            return RepositorioBase.ObterPeloId<Comentario>(Comentarios, id);
        }

        public static int InserirNovoItem(ComentarioDto novoComentarioDto)
        {
            var comentario = new Comentario
            {
                IdLivro = novoComentarioDto.Livro.Id,
                IdUsuario = novoComentarioDto.Usuario.Id,
                Conteudo = novoComentarioDto.Conteudo
            };
            return RepositorioBase.InserirNovoItem<Comentario>(Comentarios, comentario);
        }

        public static ComentarioDto GerarDto(Comentario comentario)
        {
            var livro = LivroRepositorio.ObterPeloId(comentario.IdLivro);
            var usuario = UsuarioRepositorio.ObterPeloId(comentario.IdUsuario);
            return new ComentarioDto
            {
                Id = comentario.Id,
                Livro = LivroRepositorio.GerarDto(livro),
                Usuario = UsuarioRepositorio.GerarDto(usuario),
                Conteudo = comentario.Conteudo
            };
        }

        public static List<ComentarioDto> GerarDto(List<Comentario> comentarios)
        {
            var comentariosDto = new List<ComentarioDto>();
            foreach (var comentario in comentarios)
            {
                var livro = LivroRepositorio.ObterPeloId(comentario.IdLivro);
                var usuario = UsuarioRepositorio.ObterPeloId(comentario.IdUsuario);
                comentariosDto.Add(new ComentarioDto
                {
                    Id = comentario.Id,
                    Livro = LivroRepositorio.GerarDto(livro),
                    Usuario = UsuarioRepositorio.GerarDto(usuario),
                    Conteudo = comentario.Conteudo
                });
            }
            return comentariosDto;
        }
    }
}
