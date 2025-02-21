import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';  
import { FormsModule } from '@angular/forms';
import { ProductItem } from '../../shared/models/ProductItem';

@Component({
  selector: 'app-invoke-web-api',
  imports: [FormsModule],
  templateUrl: './invoke-web-api.component.html',
  styleUrl: './invoke-web-api.component.scss'
})
export class InvokeWebAPIComponent {

  private productService : ProductService 
  getProductResponse : string;
  getProductsResponse : string;
  products : ProductItem[];


    constructor(private prodService : ProductService ) {
  
      this.productService = prodService;
  
    }

  invoke_get_product(event: Event) { 

    const strJWT = sessionStorage.getItem('JasonWebToken');

    if ( strJWT ) {

    this.productService.jSONWebToken = (strJWT !== null && strJWT !== undefined ) ? strJWT : "";
    
  }

  this.productService.getProduct().subscribe( (pi) => { this.getProductResponse = `Product Item: ${pi.description}\n`;  console.log(pi); });

  } 

  invoke_get_products(event: Event) { 

    const strJWT = sessionStorage.getItem('JasonWebToken');

    if ( strJWT ) {

      this.productService.jSONWebToken = (strJWT !== null && strJWT !== undefined ) ? strJWT : "";
      
    }

    this.productService.getProducts().subscribe( (pis) => { 
      
      this.products = pis;  console.log(pis); 

      this.getProductsResponse = "";
      
      this.products.forEach( (pi) => { this.getProductsResponse = this.getProductsResponse + `Product Item: ${pi.description}\n` } );

    });
    
  
  } 

}
