namespace PersonDiary.Infrastructure.Domain.Models.FileStore
{
    public class UploadedFileModel
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public bool IsImage { get; set; }

        public string FileStorageId { get; set; }
    }
}