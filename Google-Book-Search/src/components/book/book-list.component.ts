import { Component, OnInit, Input } from '@angular/core';

@Component ({
    selector: 'book-list',
    templateUrl: './book-list.component.html'
})

export class BookListComponent implements OnInit {
    @Input() books: any[];

    ngOnInit(): void {

    }

    openDetails(link: string) {
        window.open(link);
    }
}