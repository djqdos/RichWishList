import { Component } from '@angular/core';

@Component({
  selector: 'pm-root',
  template: `<div>
    <h1>{{ pageTitle}}</h1>


    <pm-addnew></pm-addnew>
    <pm-wishlistitem></pm-wishlistitem>
    <pm-methodcall></pm-methodcall>
  </div>`

 })

export class AppComponent {
  pageTitle: string = 'RichWishList Angular';
}