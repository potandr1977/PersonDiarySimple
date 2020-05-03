using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.Business;
using PersonDiary.Dto.Person;
using PersonDiary.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonDiary.Angular.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonFileController : ControllerBase
    {
        private readonly PersonService personService;
        private readonly IHostingEnvironment hostingEnvironment;

        public PersonFileController(PersonService personService, IHostingEnvironment hostingEnvironment)
        {
            this.personService = personService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var bytes = await personService.DownloadAsync(new GetPersonRequest() { Id = id });
            return File(bytes, "application/octet-stream", "biographi.docx");
        }
        
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<PersonUploadResponse> Post(string json)
        {
            PersonUploadRequest request = JsonConvert.DeserializeObject<PersonUploadRequest>(json);
            return await UploadBiography(request);
        }
        
        [HttpPut("{id}")]
        public async Task<PersonUploadResponse> Put(int id)
        {
            return await UploadBiography(new PersonUploadRequest() { PersonId = id });
        }
        
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return await personService.DeleteBiographyAsync(new DeletePersonRequest() { Id = id });
        }
        
        private async Task<PersonUploadResponse> UploadBiography(PersonUploadRequest request)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length == 0) return new PersonUploadResponse().AddMessage(new Dto.Message("Zero files proveided"));
                if (!file.FileName.Contains(".doc")) return new PersonUploadResponse().AddMessage(new Dto.Message("Only .doc/docx file types allowed"));
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    request.Biography = binaryReader.ReadBytes((int)file.Length);
                    return await personService.UploadAsync(request);
                }
            }
            catch (Exception e)
            {
                return new PersonUploadResponse().AddMessage(new Dto.Message(e.Message));
            }
        }


    }
}
