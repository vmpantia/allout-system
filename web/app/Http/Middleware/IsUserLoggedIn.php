<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;

class IsUserLoggedIn
{
    /**
     * Handle an incoming request.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  \Closure(\Illuminate\Http\Request): (\Illuminate\Http\Response|\Illuminate\Http\RedirectResponse)  $next
     * @return \Illuminate\Http\Response|\Illuminate\Http\RedirectResponse
     */
    public function handle(Request $request, Closure $next)
    {
        $credentials = $request->session()->get('loginCredentials');

        if(!isset($credentials['clientID'])) {
            return redirect('login');
        }

        return $next($request);
    }
}
