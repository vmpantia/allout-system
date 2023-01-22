<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Http\Request;

class Brand extends Model
{
    use HasFactory;

    public const GET_ALL_DATA = '/Brand/GetBrands?clientID=';
    public const GET_DATA_BY_ID = '/Brand/GetBrandByID?clientID=';
    public const GET_DATA_BY_QUERY = '/Brand/GetBrandsByQuery?clientID=';
    public const STORE_DATA = '/Brand/SaveBrand';
    public const RETRIVE_DATA_BY_ID = '/Brand/GetBrandByID?clientID=';


    public function storeRequest($storeData) : array {
        return [
            'functionID' => $storeData['functionID'],
            'requestStatus' => 'A2',
            'client' => session('loginCredentials'),
            'inputBrand' => [
                'brandID' => isset($storeData['brandID']) ? $storeData['brandID'] : '00000000-0000-0000-0000-000000000000',
                'name' => $storeData['name'],
                'description' => $storeData['description'],
                'status' => 0,
                'createdDate' =>  isset($storeData['createdDate']) ? $storeData['createdDate'] : date('Y-m-d'),
                'modifiedDate' =>  isset($storeData['modifiedDate']) ? $storeData['modifiedDate'] : null,
            ]
        ];
    }

}
