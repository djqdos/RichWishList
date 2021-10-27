import { Component, Injectable, OnDestroy, OnInit } from "@angular/core";
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from "rxjs";
import { IMethodCall } from "./methodcall.interface";

@Injectable({
    providedIn: 'root'
})
@Component({
    selector: 'pm-methodcall',
    templateUrl: './methodcall.component.html'
})
export class MethodCall implements OnInit, OnDestroy, HttpInterceptor {

    methods: IMethodCall[] = [{
        method : "test",
        url : "bob"
    }];


    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
            
        const m: IMethodCall = {
            method: req.method,
            url: req.url
        };
//        this.methods.push(m);

        console.table(this.methods);

        return next.handle(req);

    }

    ngOnInit(): void {

    }
    ngOnDestroy(): void {
        
    }
    
}