<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class Category extends Model
{
    use HasFactory;
    
    public const GET_ALL_DATA = '/Category/GetCategories?clientID=';
    public const GET_DATA_BY_ID = '/Category/GetCategoryByID?clientID=';
    public const GET_DATA_BY_QUERY = '/Category/GetCategoriesByQuery?clientID=';
    public const STORE_DATA = '/Category/SaveCategory';
    public const RETRIVE_DATA_BY_ID = '/Category/GetCategoryByID?clientID=';


    public function storeRequest($storeData) : array {
        return [
            'functionID' => $storeData['functionID'],
            'requestStatus' => 'A2',
            'client' => session('loginCredentials'),
            'inputCategory' => [
                'categoryID' => isset($storeData['categoryID']) ? $storeData['categoryID'] : '00000000-0000-0000-0000-000000000000',
                'name' => $storeData['name'],
                'description' => $storeData['description'],
                'status' => 0,
                'createdDate' =>  isset($storeData['createdDate']) ? $storeData['createdDate'] : date('Y-m-d'),
                'modifiedDate' =>  isset($storeData['modifiedDate']) ? $storeData['modifiedDate'] : null,
            ]
        ];
    }

}
