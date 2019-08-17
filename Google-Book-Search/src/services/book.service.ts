import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { IBook } from '../models/book'

@Injectable ()

export class BookService {
    private API_URL: string = environment.API_URL;
    private API_KEY: string = environment.API_KEY;
    private URL: string;

    constructor(private _http: HttpClient) {

    }

    getBooks(query: string): Observable<IBook[]> {
        this.URL = this.API_URL;
        const header = new HttpHeaders().set('key', this.API_KEY);
        const param = new HttpParams().set('query', query);
        return this._http.get<IBook[]>(this.URL, {headers: header, params: param }).pipe(
            catchError(this.handleError)
        );
    }

    handleError(err: HttpErrorResponse) {
        // logs error to the console
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          // client side error
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          // backend error
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError('An error occurred. Please try again.');
    }

    /*getBooks(strSearch) {
        this.URL = this.API_URL + strSearch + this.API_MAX_RESULTS;
        console.log(this.URL);
        return this._http.get(this.URL)
               .pipe(map(res => res));
    }*/
}