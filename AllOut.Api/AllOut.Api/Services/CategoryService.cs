using AllOut.Api.Commons;
using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;

namespace AllOut.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AllOutDbContext _db;
        private readonly IRequestService _request;
        public CategoryService(AllOutDbContext context, IRequestService request)
        {
            _db = context;
            _request = request;
        }

        public async Task<IEnumerable<Category>> GetCategorysAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIDAsync(Guid CategoryID)
        {
            var category = await _db.Categories.FindAsync(CategoryID);

            if (category == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND, Constants.OBJECT_CATEGORY));

            return category;
        }

        public async Task<string> SaveCategoryAsync(SaveCategoryRequest request)
        {
            //Check if Request is NULL
            if (request == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_REQUEST_NULL, Constants.OBJECT_CATEGORY));

            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);

            if (requestID == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_ID_NULL, Constants.OBJECT_CATEGORY));

            switch (request.FunctionID)
            {
                case Constants.FUNCTION_ID_ADD_CATEGORY_BY_ADMIN: //Add Category
                    request.inputCategory.CategoryID = Guid.NewGuid();
                    request.inputCategory.CreatedDate = Globals.EXEC_DATETIME;
                    await InsertCategory(request.inputCategory);
                    break;
                case Constants.FUNCTION_ID_CHANGE_CATEGORY_BY_ADMIN: //Change Category
                    request.inputCategory.ModifiedDate = Globals.EXEC_DATETIME;
                    await UpdateCategory(request.inputCategory);
                    break;
                default: //Delete Category
                    await DeleteCategory(request.inputCategory.CategoryID);
                    break;
            }

            //Insert Transaction
            await InsertCategory_TRN(request.inputCategory, requestID.ToString());
            //Save Changes
            await _db.SaveChangesAsync();

            return requestID;
        }

        private async Task InsertCategory(Category inputCategory)
        {
            await _db.Categories.AddAsync(inputCategory);
        }

        private async Task UpdateCategory(Category inputCategory)
        {
            var currentCategory = await _db.Categories.FindAsync(inputCategory.CategoryID);

            if (currentCategory == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_CHANGE, Constants.OBJECT_CATEGORY));

            //currentCategory.CategoryID = inputCategory.CategoryID;
            currentCategory.Name = inputCategory.Name;
            currentCategory.Description = inputCategory.Description;
            currentCategory.Status = inputCategory.Status;
            //currentCategory.CreatedDate = inputCategory.CreatedDate;
            currentCategory.ModifiedDate = Globals.EXEC_DATETIME;
        }

        private async Task DeleteCategory(Guid CategoryID)
        {
            var currentCategory = await _db.Categories.FindAsync(CategoryID);

            if (currentCategory == null)
                throw new ServiceException(string.Format(Constants.ERROR_OBJECT_NOT_FOUND_DELETE, Constants.OBJECT_CATEGORY));

            _db.Remove(currentCategory);
        }

        private async Task InsertCategory_TRN(Category inputCategory, string requestID)
        {
            var newTrn = new Category_TRN
            {
                RequestID = requestID,
                CategoryID = inputCategory.CategoryID,
                Name = inputCategory.Name,
                Description = inputCategory.Description,
                Status = inputCategory.Status,
                CreatedDate = inputCategory.CreatedDate,
                ModifiedDate = inputCategory.ModifiedDate
            };

            await _db.Category_TRN.AddAsync(newTrn);
        }
    }
}
