﻿using WebShopCommon.Models.ViewModel;

namespace WebShop.Services.Interface
{
    public interface IFileStorageService
    {
        Task<bool> DeleteFile(int id);
        Task<FileStorageViewModel> AddFileToStorage(IFormFile file);
        Task<FileStorageExpendedViewModel> GetFile(long id);
    }
}