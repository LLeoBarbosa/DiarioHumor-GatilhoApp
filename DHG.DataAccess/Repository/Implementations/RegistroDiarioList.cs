using DHG.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DHG.DataAccess.Repository.Implementations
{
    public class RegistroDiarioList
    {

        public List<RegistroDiario> GetRegistroDiarios()
        {
            return DataSource();
        }

        //******************************************************************************
        //******************************************************************************

        public RegistroDiario? GetRegistroDiarioById(int id)
        {
            return DataSource().Where(rg => rg.Id == id).FirstOrDefault();
        }

        //******************************************************************************
        //******************************************************************************

        public int AddRegistroDiario(RegistroDiario registroDiario)
        {
            int valor = 0;

            if (registroDiario == null)
            {
                return valor;
            }

            DataSource().Add(registroDiario);

            valor = 1;

            return valor;

        }

        //******************************************************************************
        //******************************************************************************

        public bool EditRegistroDiario(RegistroDiario registroDiario)
        {
            var registro = GetRegistroDiarioById((int)registroDiario.Id);

            if (registro == null)
            {
                return false;
            }

            registro.DataRegistro = registroDiario.DataRegistro;
            registro.NivelIntensidade = registroDiario.NivelIntensidade;
            registro.EmocaoPrincipal = registroDiario.EmocaoPrincipal;
            registro.DescricaoGatilho = registroDiario?.DescricaoGatilho;
            registro.NotasAdicionais = registroDiario?.NotasAdicionais;

            return true;         
        }

        //******************************************************************************
        //******************************************************************************

        public List<RegistroDiario> DataSource()
        {
            return new List<RegistroDiario>()
            {

                new RegistroDiario()
                {
                    Id = 1000,
                    DataRegistro = DateTime.Now,
                    EmocaoPrincipal = "Ansiedade",
                    NivelIntensidade = 7,
                    DescricaoGatilho = "Aguardando proposta de emprego",
                    NotasAdicionais = "Já aguardando a reposta de um projeto entregue e da entrevista tecnica."
                },

                new RegistroDiario()
                {
                    Id = 1001,
                    DataRegistro = DateTime.Now,
                    EmocaoPrincipal = "Alegria",
                    NivelIntensidade = 9,
                    DescricaoGatilho = "Tive a noticia de que serei Pai",
                    NotasAdicionais = "Esposa disse que esta gravida e eu receni a noticia numa viagem de negócios."
                },

                new RegistroDiario()
                {
                    Id = 1002,
                    DataRegistro = DateTime.Now,
                    EmocaoPrincipal = "Medo",
                    NivelIntensidade = 7,
                    DescricaoGatilho = "Tive meu celular roubado.",
                    NotasAdicionais = "Eu conheço o ladrão, é um antigo colega de escola, se perdeu na vida."
                },

                new RegistroDiario()
                {
                    Id = 1003,
                    DataRegistro = DateTime.Now,
                    EmocaoPrincipal = "Ansiedade",
                    NivelIntensidade = 5,
                    DescricaoGatilho = "Comprei uma pedaleira nova",
                    NotasAdicionais = "Esta demorando a chegar, vem da China."
                }

            };
        }

        //******************************************************************************
        //******************************************************************************

    }

}
