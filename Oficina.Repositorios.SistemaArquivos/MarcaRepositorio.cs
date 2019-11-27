﻿using Oficina.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio : RepositorioBase
    {
        public MarcaRepositorio() : base("caminhoArquivoMarca")
        {

        }

        public List<Marca> Obter()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(CaminhoArquivo))
            {
                var propriedades = linha.Split('|');

                var marca = new Marca();
                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Obter(int id)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(CaminhoArquivo))
            {
                var propriedades = linha.Split('|');

                var linhaId = Convert.ToInt32(propriedades[0]);

                if (id == linhaId)
                {
                    marca = new Marca();
                    marca.Id = linhaId;
                    marca.Nome = propriedades[1];

                    break;
                }
            }

            return marca;
        }
    }
}
