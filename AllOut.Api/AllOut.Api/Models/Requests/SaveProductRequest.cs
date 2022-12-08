﻿using AllOut.Api.DataAccess.Models;

namespace AllOut.Api.Models.Requests
{
    public class SaveProductRequest
    {
        //Request Information
        public Guid UserID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }

        //Product Information
        public Product inputProduct { get; set; }
    }
}