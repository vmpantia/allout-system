<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    use HasFactory;

    public const GET_ALL_DATA = '/Product/GetProducts?clientID=';
    public const GET_DATA_BY_ID = '/Product/GetProductByID?clientID=';
    public const GET_DATA_BY_QUERY = '/Product/GetProductsByQuery?clientID=';
    public const STORE_DATA = '/Product/SaveProduct';
    public const RETRIVE_DATA_BY_ID = '/Product/GetProductByID?clientID=';


    public function storeRequest($storeData) : array {
        return [
            'functionID' => $storeData['functionID'],
            'requestStatus' => 'A2',
            'client' => session('loginCredentials'),
            'inputProduct' => [
                'productID' => isset($storeData['productID']) ? $storeData['productID'] : '00000000-0000-0000-0000-000000000000',
                'brandID' => $storeData['brandID'],
                'categoryID' => $storeData['categoryID'],
                'name' => $storeData['name'],
                'description' => $storeData['description'],
                'reorderPoint' => $storeData['reorderPoint'],
                'price' => $storeData['price'],
                'status' => 0,
                'createdDate' =>  isset($storeData['createdDate']) ? $storeData['createdDate'] : date('Y-m-d'),
                'modifiedDate' =>  isset($storeData['modifiedDate']) ? $storeData['modifiedDate'] : null,
            ]
        ];
    }

}
