import { Component, Injectable, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { IWishListItem } from './wishlist.interface';
import { WishListService } from './wishlist.service';
import { Guid } from 'guid-typescript';


@Injectable()

@Component({
    selector: 'pm-wishlistitem',
    templateUrl: './wishlistitem.component.html'
})

export class WishListItemComponent implements OnInit, OnDestroy { 
    items: IWishListItem[] = [];
    errorMessage: string = '';
    sub! : Subscription

    constructor(private wishlistService : WishListService) {}

    increase(id: string) : void {
        console.log(`Increase clicked! ID = ${id}`);

        const itemById = this.items.filter(x => x.id === id)[0];
        console.log("Got Item: ", itemById);
        this.wishlistService.increaseQuantity(itemById);
    }

    decrease(id: string) : void {
        console.log(`decrease clicked  ID = ${id}`);
        const itemById = this.items.filter(x => x.id === id)[0];

        this.wishlistService.decreaseQuantity(itemById);
    }

    deleteItem(id: string) : void {
        console.log(`deleteItem clicked  ID = ${id}`);
        this.wishlistService.deleteItem(id);
    }

    getItems(): void {
        
    }



    ngOnInit(): void {
        this.sub = this.wishlistService.getWishListItems().subscribe({
            next: items => {
                this.items = items;
            },
            error: err => this.errorMessage = err
        });
    }
    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
