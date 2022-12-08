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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByQueryAsync(string query)
        {
            var categories = await _db.Categories.Where(data => data.Name.Contains(query) || data.Description.Contains(query))
                                                 .Where(data => data.Status != Constants.INT_STATUS_DELETION).ToListAsync();

            return categories;
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

        public async Task<string> UpdateCategoryStatusByIDsAsync(UpdateStatusByIDsRequest request)
        {
            var requestID = await _request.InsertRequest(_db, request.UserID,
                                                              request.FunctionID,
                                                              request.RequestStatus);
            var count = 0;
            foreach (var id in request.IDs)
            {
                count++;
                var category = await _db.Categories.FindAsync(id);
                if (category != null)
                {
                    category.Status = request.newStatus;
                    category.ModifiedDate = DateTime.Now;
                    await InsertCategory_TRN(category, requestID.ToString(), count);
                }
            }

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

        private async Task InsertCategory_TRN(Category inputCategory, string requestID, int number = 1)
        {
            var newTrn = new Category_TRN
            {
                RequestID = requestID,
                Number = number,
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
