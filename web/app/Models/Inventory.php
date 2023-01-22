<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Inventory extends Model
{
    use HasFactory;

    public const GET_ALL_DATA = '/Inventory/GetInventories?clientID=';
    public const GET_DATA_BY_QUERY = '/Inventory/GetInventoryByQuery?clientID=';
    public const STORE_DATA = '/Inventory/SaveInventory';
    public const RETRIVE_DATA_BY_ID = '/Inventory/GetInventoryByID?clientID=';


    public function storeRequest($storeData) : array {
        return [
            'functionID' => $storeData['functionID'],
            'requestStatus' => 'A2',
            'client' => session('loginCredentials'),
            'inputInventory' => [
                'inventoryID' => isset($storeData['inventoryID']) ? $storeData['inventoryID'] : '',
                'productID' => $storeData['productID'],
                'quantity' => $storeData['quantity'],
                'status' => 0,
                'createdDate' =>  isset($storeData['createdDate']) ? $storeData['createdDate'] : date('Y-m-d'),
                'modifiedDate' =>  isset($storeData['modifiedDate']) ? $storeData['modifiedDate'] : null,
            ]
        ];
    }

}
