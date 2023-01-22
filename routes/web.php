<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/


Auth::routes(['middleware' => 'auth']);



Route::get('login', [App\Http\Controllers\LoginController::class, 'index'])->name('login');
Route::post('login/verify', [App\Http\Controllers\LoginController::class, 'verifty'])->name('verify');
Route::post('login/register', [App\Http\Controllers\LoginController::class, 'register'])->name('register');
Route::get('logout', [App\Http\Controllers\LoginController::class, 'logout']);

Route::group(['middleware' => 'isLoggedIn'], function() {

    Route::get('/', function () { return view('welcome'); })->name('home');

    ####################### CATEGORY #######################

    Route::get('category', [App\Http\Controllers\CategoryController::class, 'index']);
    Route::get('category/getData', [App\Http\Controllers\CategoryController::class, 'getData']);
    Route::post('category/store', [App\Http\Controllers\CategoryController::class, 'store']);
    Route::get('category/edit/{id}', [App\Http\Controllers\CategoryController::class, 'edit']);
    Route::get('category/delete/{id}', [App\Http\Controllers\CategoryController::class, 'delete']);
    Route::get('category/search/{keyword}', [App\Http\Controllers\CategoryController::class, 'search']);

    ####################### BRAND #######################

    Route::get('brand', [App\Http\Controllers\BrandController::class, 'index']);
    Route::get('brand/getData', [App\Http\Controllers\BrandController::class, 'getData']);
    Route::post('brand/store', [App\Http\Controllers\BrandController::class, 'store']);
    Route::get('brand/edit/{id}', [App\Http\Controllers\BrandController::class, 'edit']);
    Route::get('brand/delete/{id}', [App\Http\Controllers\BrandController::class, 'delete']);
    Route::get('brand/search/{keyword}', [App\Http\Controllers\BrandController::class, 'search']);

    ####################### PRODUCTS #######################

    Route::get('product', [App\Http\Controllers\ProductController::class, 'index']);
    Route::get('product/getData', [App\Http\Controllers\ProductController::class, 'getData']);
    Route::post('product/store', [App\Http\Controllers\ProductController::class, 'store']);
    Route::get('product/edit/{id}', [App\Http\Controllers\ProductController::class, 'edit']);
    Route::get('product/delete/{id}', [App\Http\Controllers\ProductController::class, 'delete']);
    Route::get('product/search/{keyword}', [App\Http\Controllers\ProductController::class, 'search']);

    
    ####################### INVENTORY #######################

    Route::get('inventory', [App\Http\Controllers\InventoryController::class, 'index']);
    Route::get('inventory/getData', [App\Http\Controllers\InventoryController::class, 'getData']);
    Route::post('inventory/store', [App\Http\Controllers\InventoryController::class, 'store']);
    Route::get('inventory/edit/{id}', [App\Http\Controllers\InventoryController::class, 'edit']);
    Route::get('inventory/delete/{id}', [App\Http\Controllers\InventoryController::class, 'delete']);
    Route::get('inventory/search/{keyword}', [App\Http\Controllers\InventoryController::class, 'search']);


        
    ####################### POINT OF SALES #######################
    
    Route::get('pos', [App\Http\Controllers\PointOfSaleController::class, 'index']);
    Route::post('pos/store', [App\Http\Controllers\PointOfSaleController::class, 'store']);



    
    


});





