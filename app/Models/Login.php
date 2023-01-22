<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Facades\Hash;

class Login extends Model
{
    use HasFactory;

    public const LOGIN_USER = '/User/LoginUser';
    public const REGISTER_USER = '/User/SaveUser';



    public function loginDataRequest($data) : array {
        return [
            'logonName' => $data['logonName'],
            'password' => base64_encode($data['password']),
            'browser' => '',
            'ipAddress' => '',
            'windowsVersion' => ''
        ];
    }

    public function register($data) : array {

        return [
            "functionID" => "00A01",
            "requestStatus" => "A2",
            "client" => [
                "clientID" => "00000000-0000-0000-0000-000000000000",
                "userID" => "00000000-0000-0000-0000-000000000000",
                "name" => "",
                "browser" => "",
                "ipAddress" => "",
                "windowsVersion" => "",
                "status" => "1",
                "createdDate" =>  date('Y-m-d'),
            ],
            "inputUser" => [
                "userID" => "00000000-0000-0000-0000-000000000000",
                "email" => $data['email'],
                "username" => $data['username'],
                "password" => base64_encode($data['password']),
                "firstName" => $data['firstName'],
                "middleName" => $data['middleName'],
                "lastName" => $data['lastName'],
                "isEmailConfirmed" => true,
                "permission" => 0,
                "status" => 0,
                "createdDate" => date('Y-m-d'),
                "modifiedDate" => date('Y-m-d'),
            ]
        ];
    }

}
