import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  public jsonWebToken : string;
  
  objHttp: HttpClient;

  constructor(private http: HttpClient) { 

    this.objHttp = http;

  }

  getProduct() : Observable<any> {
  
    // Content Type Recevied
    const headers = { 'Content-Type': 'application/json', 'bearer': this.jsonWebToken };
    
    let url =  "http://localhost:8042/api/Product/GetProduct?SerialNumber=12345";
    
    return this.http.get(url,
    {headers}
    );

  }


  getProducts() : Observable<any> {

       // Content Type Recevied
    const headers = { 'Content-Type': 'application/json', 'bearer': this.jsonWebToken };
    
    let url =  "http://localhost:8042/api/Product/GetProducts";
    
    return this.http.get(url,
    {headers}
    );

  }



}
