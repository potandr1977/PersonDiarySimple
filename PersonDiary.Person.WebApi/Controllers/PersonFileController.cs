using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.Infrastructure.Dto;
using PersonDiary.Person.Business;
using PersonDiary.Person.Dto;
using System;
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
            var bytes = await personService.DownloadAsync(new GetPersonRequestDto() { Id = id });
            return File(bytes, "application/octet-stream", "biographi.docx");
        }
        
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<PersonUploadResponseDto> Post(string json)
        {
            PersonUploadRequestDto request = JsonConvert.DeserializeObject<PersonUploadRequestDto>(json);
            return await UploadBiography(request);
        }
        
        [HttpPut("{id}")]
        public async Task<PersonUploadResponseDto> Put(int id)
        {
            return await UploadBiography(new PersonUploadRequestDto() { PersonId = id });
        }
        
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponseDto> Delete(int id)
        {
            return await personService.DeleteBiographyAsync(new DeletePersonRequestDto() { Id = id });
        }
        
        private async Task<PersonUploadResponseDto> UploadBiography(PersonUploadRequestDto request)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length == 0) return new PersonUploadResponseDto().AddMessage(new Message("Zero files proveided"));
                if (!file.FileName.Contains(".doc")) return new PersonUploadResponseDto().AddMessage(new Message("Only .doc/docx file types allowed"));
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    request.Biography = binaryReader.ReadBytes((int)file.Length);
                    return await personService.UploadAsync(request);
                }
            }
            catch (Exception e)
            {
                return new PersonUploadResponseDto().AddMessage(new Message(e.Message));
            }
        }


    }
}
