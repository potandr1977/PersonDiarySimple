using System.Threading.Tasks;
using PersonDiary.Infrastructure.Domain.Models.FileStore;

namespace PersonDiary.Infrastucture.Domain.DataAccess
{
    public interface IDbExecutorMongo
    {
        Task<string> UploadFileAsync(UploadedFileModel file);
    }
}