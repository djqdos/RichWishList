import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { WishListItemComponent } from './components/wishlistitem/wishlistitem.component';
import { AddNew } from './components/addnew/addnew.component';
import { MethodCall } from './components/methodcall/methodcall.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms'

@NgModule({
  declarations: [
    AppComponent,
    AddNew,
    WishListItemComponent,
    MethodCall
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: MethodCall,
    multi: true

  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
