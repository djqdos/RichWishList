import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder } from '@angular/forms'
import { Subscription } from 'rxjs';
import { IWishListItem } from '../wishlistitem/wishlist.interface'
import { WishListService } from '../wishlistitem/wishlist.service';
import { Guid } from 'guid-typescript';


@Component(
    {
        selector: 'pm-addnew',
        templateUrl: './addnew.component.html'
    }
)
export class AddNew implements OnInit, OnDestroy {


    addNewItemForm = this.formBuilder.group({
        itemName: '',
        quantity: 0
    })

    constructor(private formBuilder: FormBuilder, private wishlistService: WishListService) {}

    onSubmit(): void {
        console.log("Forms value =", this.addNewItemForm.value);

        let newItem: IWishListItem = {
            id: Guid.create().toString(),
            itemName: this.addNewItemForm.get('itemName')?.value,
            quantity: this.addNewItemForm.get('quantity')?.value
        };
        
        console.log("new item = ", newItem);

        this.wishlistService.addNewItem(newItem);
        this.wishlistService.getWishListItems();

    }

    ngOnInit(): void {
        
    }
    ngOnDestroy(): void {
        
    }

}