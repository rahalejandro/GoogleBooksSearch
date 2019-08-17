import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { IBook } from '../../models/book';

@Component ({
    selector: 'search-root',
    templateUrl: './search.component.html'
})

export class SearchComponent implements  OnInit{
    Books: IBook[];
    errorMessage: string;
    bookSearch:string;
    isBlank: boolean = false;

    constructor(private _bookService: BookService) {

    }

    ngOnInit(): void {

    }

    searchBooks(search: string) {
        if(!this.bookSearch) {
            this.isBlank = true;
            return false;
        }
        else {
            this.isBlank = false;
            return this._bookService.getBooks(search)
                .subscribe(
                    (data: IBook[]) => this.setBooksModel(data),
                    (error: any) => this.errorMessage = <any>error,
                    () => console.log("Search Complete!")
                );
        }
    }

    setBooksModel(data) {
        if(data && data.length > 0) {
            this.Books = data;
        }
        this.errorMessage = "";
        console.log(this.Books);
    }

    /*setBooksModel(data) {
        if(data.items && data.items.length > 0) {
            this.Books = data.items;
        }
        console.log(this.Books);
    }*/

    clearResult() {
        this.Books = null;
        this.bookSearch = "";
        this.isBlank = false;
    }

    clearError() {
        this.errorMessage = "";
    }
}