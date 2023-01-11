using AllOut.Api.Contractors;
using AllOut.Api.DataAccess;
using AllOut.Api.DataAccess.Models;
using AllOut.Api.Models.Requests;
using AllOut.Api.Common;
using Microsoft.EntityFrameworkCore;
using Puregold.API.Exceptions;
using AllOut.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;

namespace AllOut.Api.Services
{
    public class InventoryService
    {
        private readonly AllOutDbContext _db;
        public InventoryService(AllOutDbContext context)
        {
            _db = context;
        }
    }
}
