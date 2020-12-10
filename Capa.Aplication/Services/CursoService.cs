using Capa.Aplication.Services.Base;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.DTO.CursoResponseDTO;
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
                ProfesorId = cursoDTO.ProfesorId,
                Imagen = cursoDTO.Imagen
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
                CategoriaId = curso.CategoriaId,
                Imagen = curso.Imagen
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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var http = new HttpClient(clientHandler))
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





        public async Task<List<CursoCompletoDTO>> GetCursoByIdLista(List<int> idCursos)
        {
            //GET CURSO BY ID LISTA
            Curso curso;
            CursoCompletoDTO cursoCompleto;
            List<Clase> clases;
            List<ClaseConCuestionarioDTO> clasesCompletas;
            List<CursoCompletoDTO> cursosCompletos = new List<CursoCompletoDTO>();
            foreach (int idCurso in idCursos)
            {
                curso = repository.Traer<Curso>().FirstOrDefault(x => x.CursoId == idCurso);
                cursoCompleto = new CursoCompletoDTO()
                {
                    CursoId = curso.CursoId,
                    Nombre = curso.Nombre,
                    Descripcion = curso.Descripcion,
                    Cantidad = curso.Cantidad,
                    ProfesorId = curso.ProfesorId,
                    CategoriaId = curso.CategoriaId,
                    Imagen = curso.Imagen
                };
                clases = repository.Traer<Clase>().Where(x => x.CursoId == idCurso).ToList();
                clasesCompletas = new List<ClaseConCuestionarioDTO>();
                foreach (Clase clase in clases)
                {
                    clasesCompletas.Add(await GetByIdConCuestionarios(clase.ClaseId));
                }
                cursoCompleto.ClasesNavegacion = clasesCompletas;
                cursosCompletos.Add(cursoCompleto);
            }
            return cursosCompletos;
        }






        public List<CursoCustomDTO> GetAll()
        {
            return this.repository.GetCursosConCategoria();
        }

        public List<CategoriaDTOs> ObtenerCategorias()
        {
            return this.repository.ObtenerCategorias();
        }

        public List<CursoSimpleDTO> CursoSimple()
        {
            var cursoDb = this.repository.Traer<Curso>();

            var ListCursos = new List<CursoSimpleDTO>();

            foreach (var c in cursoDb)
            {
                var dto = new CursoSimpleDTO()
                {
                    CursoId = c.CursoId,
                    ProfesorId = c.ProfesorId
                };

                ListCursos.Add(dto);
            }

            return ListCursos;
        }




        public CursoResponseAsyncDTO RestarCupoById(RequestIdCursoDTO curso_id)
        {
            Curso curso = repository.Traer<Curso>().FirstOrDefault(x => x.CursoId == curso_id.CursoId);
            curso.Cantidad--;
            this.repository.Update(curso);

            var cursoUpdate = new CursoResponseAsyncDTO()
            {
                CursoId = curso.CursoId
            };
            return cursoUpdate;
        }



        public List<ClaseResponseDTO> GetClasesByIdClase(int claseId)
        {
            var cursoId = repository.Traer<Clase>().FirstOrDefault(x => x.ClaseId == claseId).CursoId;
            var clasedb = this.repository.Traer<Clase>().Where(x => x.CursoId == cursoId);

            var ListClases = new List<ClaseResponseDTO>();

            foreach (var c in clasedb)
            {
                var dto = new ClaseResponseDTO()
                {
                    ClaseId = c.ClaseId,
                    CursoId = c.CursoId
                };

                ListClases.Add(dto);
            }

            return ListClases;
        }
    }
}
