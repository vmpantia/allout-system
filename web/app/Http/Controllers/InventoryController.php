<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Inventory;
use Illuminate\Support\Facades\Http;

class InventoryController extends Controller
{
    public function API_BASE() {
        return config('api_base.API.BASE_URL');
    }

    public function getClientID() {
        return session('loginCredentials')['clientID'];
    }


    public function getData() {
        $data = new Inventory();
        $apiRequest = $this->API_BASE() . $data::GET_ALL_DATA . $this->getClientID();
        return Http::get($apiRequest)->getBody()->getContents();
    }

    public function index() {
        return view('inventory.inventory');
    }

    public function store(Request $request) {
        $data = new Inventory();
        $response = Http::post($this->API_BASE() . $data::STORE_DATA, $data->storeRequest($request->all()));
        return response()->json(['data' => $response->getBody()->getContents()], $response->getStatusCode());
    }
    
    public function search($keyword) {
        $data = new Inventory();
        $response = Http::get($this->API_BASE() . $data::GET_DATA_BY_QUERY . $this->getClientID() . '&Query=' . strtoupper($keyword));
        return response()->json(['data' => $response->getBody()->getContents()], $response->getStatusCode());
    }

    public function edit($id) {
        $data = new Inventory();
        $response = Http::get($this->API_BASE() . $data::RETRIVE_DATA_BY_ID . $this->getClientID() . '&ID=' . $id);
        return response()->json(['data' => $response->getBody()->getContents()], $response->getStatusCode());
    }
}
