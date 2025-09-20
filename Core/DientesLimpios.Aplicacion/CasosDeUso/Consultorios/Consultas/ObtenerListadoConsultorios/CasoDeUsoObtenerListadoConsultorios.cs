using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Aplicacion.Contratos.Repository;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios
{
    public class CasoDeUsoObtenerListadoConsultorios
        : IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>
    {
        private readonly IRepositoryConsultorios repositorio;
        public CasoDeUsoObtenerListadoConsultorios(IRepositoryConsultorios _repository)
        {
            this.repositorio = _repository;
        }
        

        public async Task<List<ConsultorioListadoDTO>> Handle(ConsultaObtenerListadoConsultorios request)
        {
            var consultorios = await this.repositorio.ObtenerTodos();
            var dtos = consultorios.Select(c => c.ADto()).ToList();
            return dtos;

        }
    }
}
