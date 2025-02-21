import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import HttpService from './http.service';
import { ProductItem } from '../shared/models/ProductItem';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  jSONWebToken? : string;

  
  constructor(private httpService: HttpService) { 

  }

  getProduct() : Observable<ProductItem> {
    
    const result = this.httpService.get<ProductItem>("/Product/GetProduct?SerialNumber=12345", { token: this.jSONWebToken  });
    return result;

  }

  getProducts() : Observable<ProductItem[]> {

    const result = this.httpService.get<ProductItem[]>("/Product/GetAllProducts", { token: this.jSONWebToken  });
    return result;
    
  }



}
