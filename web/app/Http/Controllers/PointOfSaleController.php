<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\PointOfSale;
use Illuminate\Support\Facades\Http;

class PointOfSaleController extends Controller
{
    public function index() {
        return view('sales.pos');
    }

    public function API_BASE() {
        return config('api_base.API.BASE_URL');
    }

    public function getClientID() {
        return session('loginCredentials')['clientID'];
    }

    public function store(Request $request) {
        $data = new PointOfSale();
        $dataToStore = $request->all();

        if($dataToStore['inputSales']['salesID'] == null) {
            $dataToStore['inputSales']['createdDate'] = date('Y-m-d');
        }

        foreach($dataToStore['inputSalesItems'] as &$item)
        {
            if($item['salesID'] === null) {
                $item['salesID'] = '';
            }
        }

        foreach($dataToStore['inputOtherCharges'] as &$item)
        {
            if($item['salesID'] === null) {
                $item['salesID'] = '';
            }
        }


        $response = Http::post($this->API_BASE() . $data::STORE_DATA, $data->storeRequest($dataToStore));
        return response()->json(['data' => $response->getBody()->getContents()], $response->getStatusCode());  
    }
}
