using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Common
{
    public interface IUploadImageKoi
    {
        Task<string> UploadFileToFireBase(IFormFile file, string folderName);
    }
}
