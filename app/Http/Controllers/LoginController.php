<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Http\Requests\LoginRequest;
use App\Models\Login;
use Illuminate\Support\Facades\Http;
use Illuminate\Support\Facades\Hash;

class LoginController extends Controller
{

    public function API_BASE() {
        return config('api_base.API.BASE_URL');
    }

    public function index() {
        return view('adminlte::auth.login');
    }

    public function verifty(LoginRequest $request) {
       
        $login = new Login();
        $response = Http::post($this->API_BASE() . $login::LOGIN_USER, $login->loginDataRequest($request->all()));
        if($response->getStatusCode() === 200) {
            $request->session()->put('loginCredentials', json_decode($response->getBody()->getContents(),true));
            return redirect('/');
        } else {
            dd($response->getBody()->getContents());
        }
       
    }

    public function register(Request $request) {

        $login = new Login();
        $response = Http::post($this->API_BASE() . $login::REGISTER_USER, $login->register([
            'email' => $request->email,
            'username' => $request->lastName . '.' . $request->firstName,
            'password' => $request->password,
            'firstName' => $request->firstName,
            'middleName' => $request->middleName,
            'lastName' => $request->lastName
        ]));

        return redirect('login');

    }

    public function logout() {
        session()->invalidate();
        return redirect('login');
    }   


}
