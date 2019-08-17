import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule  } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchComponent } from './search.component';
import { BookListComponent } from '../book/book-list.component';

@NgModule ({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        RouterModule.forChild([
            {path: 'search', component: SearchComponent}
        ])
    ],
    declarations: [
        SearchComponent,
        BookListComponent
    ]
})

export class SearchModule {

}
