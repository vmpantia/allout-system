<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class PointOfSale extends Model
{
    use HasFactory;

    public const STORE_DATA = '/Sales/SaveSales';

    public function storeRequest($storeData) : array {
        $storeData['inputSales']['salesID'] = $storeData['inputSales']['salesID'] ?? '';
        $storeData['inputSales']['userID'] = session('loginCredentials')['userID'];
        $defaultArr = [
            'functionID' => $storeData['inputSales']['salesID'] ? '05C00' : '05A00',
            'requestStatus' => 'A2',
            'client' => session('loginCredentials'),
        ];
        return array_merge($defaultArr, $storeData);
    }
}
