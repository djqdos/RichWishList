import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Guid } from 'guid-typescript';
import { BehaviorSubject, Observable, ReplaySubject, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { IWishListItem } from "./wishlist.interface";

@Injectable({
    providedIn: 'root'    
})
export class WishListService {
    private serviceUrl = 'https://localhost:44348/WishList';  
    
    
    private _wishlistitems = new BehaviorSubject<IWishListItem[]>([]);
    wishlistitems = this._wishlistitems.asObservable();


    constructor(private http: HttpClient) { }
    
    getWishListItems(): Observable<IWishListItem[]> {

        // return this.http.get<IWishListItem[]>(this.serviceUrl)
        //     .pipe( 
        //         tap(data => console.log("Service Data = ", JSON.stringify(data))),
        //         catchError(this.handleError)
        //     );


        const response = this.http.get<IWishListItem[]>(this.serviceUrl).pipe(tap(data => {  return data; }));
        console.log("RESPONSE = ", response);
        
        return this.http.get<IWishListItem[]>(this.serviceUrl)
            .pipe( 
                tap(data => console.log("Service Data = ", JSON.stringify(data))),
                catchError(this.handleError)
            );

    }

    addNewItem(item: IWishListItem) : void {
        console.log("addNewItem called", item);
        this.http.post<IWishListItem>(this.serviceUrl, item)
            .pipe(
                tap(data => console.log("addNewItem data = ", JSON.stringify(data))),
                catchError(this.handleError)
            )
            .subscribe();
    }

    increaseQuantity(item: IWishListItem) : void {
        console.log(`increase quantity for ${item.id}`);
        item.quantity++;
        this.http.put<IWishListItem>(this.serviceUrl, item)
            .subscribe(x => {
                console.log("x = ", x);
            })
            // .pipe(catchError(this.handleError));
    }

    decreaseQuantity(item: IWishListItem) : void {

        console.log(`decrease quantity for ${item.id}`);
        item.quantity--;
        this.http.put<IWishListItem>(this.serviceUrl, item)
            .subscribe(x => {
                console.log("x = ", x);
            })
    }

    deleteItem(id: string) : void {
        this.http.delete(`${this.serviceUrl}?id=${id}`)
            .subscribe({
                next: data => { console.log(data); }
            })
    }

    private handleError(err: HttpErrorResponse) : Observable<never> {
        let errorMessage = '';
        if( err.error instanceof ErrorEvent) {
            errorMessage = `An error occured: ${err.error.message}`;
        }
        else {
            errorMessage = `Server returned code: ${err.status}, Error msg is ${err.message}`
        }
        console.error(errorMessage);

        return throwError(errorMessage);
    }
}