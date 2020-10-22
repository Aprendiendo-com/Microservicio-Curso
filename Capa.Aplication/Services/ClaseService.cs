using Capa.Aplication.Services.Base;
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
    public class ClaseService : GenericService, IClaseService
    {
        private readonly IClaseRepository repository;

        public ClaseService(IClaseRepository _repository): base(_repository)
        {
            this.repository = _repository;
        }

        public ClaseRespuestaDTO AddClase(ClaseDTO claseDTO)
        {
            var clase = new Clase()
            {
                Tema = claseDTO.Tema,
                CursoId = claseDTO.CursoId,
                Descripcion = claseDTO.Descripcion,
            };

            this.Repository.Add(clase);

            var videoDto = claseDTO.Video;
            var foroDto = claseDTO.Foro;

            var video = new Video()
            {
                ClaseId = clase.ClaseId,
                Descripcion = videoDto.Descripcion,
                Link = videoDto.Link
            };

            this.Repository.Add(video);

            var foro = new Foro
            {
                ClaseId = clase.ClaseId,
                Texto = foroDto.Texto
            };

            this.Repository.Add(foro);

            return new ClaseRespuestaDTO() { ClaseId = clase.ClaseId, Tema = claseDTO.Tema};

        }
        /*
        public ClaseDTO GetById(int id)
        {
            Clase clase = repository.Traer<Clase>().FirstOrDefault(x => x.ClaseId == id);
            return repository.GetClaseById(clase);
        }


        public async Task<List<ClaseConCuestionarioDTO>> GetClasesDeCurso(int idCurso)
        {
            List<ClaseConCuestionarioDTO> clasesDeCurso = new List<ClaseConCuestionarioDTO>();
            var clases = this.Repository.Traer<Clase>().Where(x => x.CursoId == idCurso);
            foreach (Clase clase in clases)
            {
                clasesDeCurso.Add(await GetByIdConCuestionarios(clase.ClaseId));
            }
            return clasesDeCurso;
        }


        public async Task<ClaseConCuestionarioDTO> GetByIdConCuestionarios(int id)
        {
            Clase clase = repository.Traer<Clase>().FirstOrDefault(x => x.ClaseId == id);

            ClaseConCuestionarioDTO claseCompleta = repository.GetClaseByIdConCuestionarios(clase);

            claseCompleta.Cuestionario = await GetCuestionarioDeClase(id);
            return claseCompleta;
        }

        //TRAE CUESTIONARIOS FILTRADOS POR CLASE
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
        */


    }
}
