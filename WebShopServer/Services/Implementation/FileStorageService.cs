using AutoMapper;
using Microsoft.Extensions.Options;
using WebShop.Data;
using WebShop.Models.Dbo;
using WebShop.Models.Dto;
using WebShop.Services.Interface;
using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Implementation
{
    public class FileStorageService : IFileStorageService
    {
        private readonly ApplicationDbContext db;
        private readonly AppConfig appConfig;
        private IWebHostEnvironment env;
        private IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public FileStorageService(ApplicationDbContext db,
            IOptions<AppConfig> appConfig, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.db = db;
            this.appConfig = appConfig.Value;
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        public async Task<FileStorageViewModel> AddFileToStorage(IFormFile file)
        {

            var dbo = new FileStorage();
            db.FileStorage.Add(dbo);
            await db.SaveChangesAsync();
            var savedFile = await AddToLocalStorage(file, dbo.Id);

            mapper.Map(savedFile,dbo);
            await db.SaveChangesAsync();
            return mapper.Map<FileStorageViewModel>(dbo);
        }



        private async Task<FileStorageViewModel> AddToLocalStorage(IFormFile file, long fileuploadId)
        {
            if (file == null)
            {
                return null;
            }
            string folderPath = env.ContentRootPath + @"\WebShop\upload\" + fileuploadId;
            Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, file.FileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            var url = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";

            var response = new FileStorageViewModel
            {
                DownloadUrl = url + "/shared/files/" + fileuploadId,
                PhysicalPath = filePath,
            };


            return response;
        }
    }
}
