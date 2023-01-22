@extends('adminlte::page')

@section('title', 'Dashboard')

@section('content')
    <div id="app">
        <pos-component></pos-component>
    </div>
@stop

@section('css')
    <link rel="stylesheet" href="/css/admin_custom.css">
@stop

@section('js')
    <script src="{{ asset('js/app.js') }}"></script>
@stop