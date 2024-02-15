import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppUtils } from '../common/app-utils';
import { Product } from '../models/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  private url = `${environment.apiUrl}/api/products`;

  constructor(private http: HttpClient) { }

  public getAllsProducts() : Observable<Product[]>{
    return this.http.get<Product[]>(`${this.url}`).pipe(catchError(AppUtils.handleServiceError));
  }

  public getProduct(id: string) : Observable<Product>{
    return this.http.get<Product>(`${this.url}/${id}`).pipe(catchError(AppUtils.handleServiceError));
  }

  public addProduct(product: Product) : Observable<Product>{
    return this.http.post<Product>(`${this.url}`, product).pipe(catchError(AppUtils.handleServiceError));
  }

  public updateProduct(id: string, product: Product) : Observable<Product>{
    return this.http.put<Product>(`${this.url}/${id}`, product).pipe(catchError(AppUtils.handleServiceError));
  }

  public deleteProduct(id: string) : Observable<void>{
    return this.http.delete<void>(`${this.url}/${id}`).pipe(catchError(AppUtils.handleServiceError));
  }


}
