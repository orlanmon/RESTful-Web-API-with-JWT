import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';  


@Component({
  selector: 'app-invoke-web-api',
  imports: [],
  templateUrl: './invoke-web-api.component.html',
  styleUrl: './invoke-web-api.component.scss'
})
export class InvokeWebAPIComponent {

  private productService : ProductService 
  
    constructor(private prodService : ProductService ) {
  
      this.productService = prodService;
  
    }


  invoke_get_product(event: Event) { 

    this.productService.jsonWebToken = (sessionStorage.getItem('JasonWebToken') !== null ) ? JSON.parse(sessionStorage.getItem('JasonWebToken')) : '';

    this.productService.getProduct();

    console.log("Invoke Get Product");

  } 

  invoke_get_products(event: Event) { 

    this.productService.jsonWebToken = (sessionStorage.getItem('JasonWebToken') !== null ) ? JSON.parse(sessionStorage.getItem('JasonWebToken')) : '';

    this.productService.getProducts();

    console.log("Invoke Get Products");

  } 

}
