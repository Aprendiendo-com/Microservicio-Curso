﻿using Capa.Aplication.Services.Base;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.Entities;
using Capa.Domain.Queries;
using Capa.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Aplication.Services
{
    public class CursoService : GenericService, ICursoService
    {
        private readonly ICursoRepository repository;
        public CursoService(ICursoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public CursoRespuestaDTO AddCurso(CursoDTO cursoDTO)
        {
            var Curso = new Curso()
            {
                Cantidad = cursoDTO.Cantidad,
                Descripcion = cursoDTO.Descripcion,
                Nombre = cursoDTO.Nombre,
                CategoriaId = cursoDTO.CategoriaId,
                ProfesorId = cursoDTO.ProfesorId
            };

            this.Repository.Add(Curso);

            return new CursoRespuestaDTO { CursoId = Curso.CursoId, CategoriaId = Curso.CategoriaId, ProfesorId = Curso.ProfesorId, Nombre = Curso.Nombre};
        }



        //MODIFICADO
        public async Task<CursoCompletoDTO> GetCursoById(int idCurso)
        {
            Curso curso = repository.Traer<Curso>().FirstOrDefault(x => x.CursoId == idCurso);
            CursoCompletoDTO cursoCompleto = new CursoCompletoDTO()
            {
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                Cantidad = curso.Cantidad,
                ProfesorId = curso.ProfesorId,
                CategoriaId = curso.CategoriaId
            };
            List<Clase> clases = repository.Traer<Clase>().Where(x => x.CursoId == idCurso).ToList();
            List<ClaseConCuestionarioDTO> clasesCompletas = new List<ClaseConCuestionarioDTO>();
            foreach (Clase clase in clases)
            {
                clasesCompletas.Add(await GetByIdConCuestionarios(clase.ClaseId));
            }
            cursoCompleto.ClasesNavegacion = clasesCompletas;
            return cursoCompleto;
        }

        public async Task<ClaseConCuestionarioDTO> GetByIdConCuestionarios(int id)
        {
            Clase clase = repository.Traer<Clase>().FirstOrDefault(x => x.ClaseId == id);

            ClaseConCuestionarioDTO claseCompleta = repository.GetClaseByIdConCuestionarios(clase);

            claseCompleta.Cuestionario = await GetCuestionarioDeClase(id);
            return claseCompleta;
        }

        public async Task<CuestionarioTodoDTO> GetCuestionarioDeClase(int idClase)
        {
            using (var http = new HttpClient())
            {
                string link = "https://localhost:44326/api/Cuestionario/GetPorClase?idClase=" + idClase;
                var Uri = new Uri(link);

                HttpResponseMessage response = await http.GetAsync(Uri);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                CuestionarioTodoDTO cuestionarioDeClase = JsonConvert.DeserializeObject<CuestionarioTodoDTO>(stringContentAsync);


                return cuestionarioDeClase;
            }
        }
    }
}
