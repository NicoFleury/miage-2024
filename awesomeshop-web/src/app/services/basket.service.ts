import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppUtils } from '../common/app-utils';
import { BasketItem } from '../models/BasketItem';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  private url = `${environment.apiUrl}/api/baskets`;

  constructor(private http: HttpClient) { }

  public addToBasket(userId: string, item: BasketItem) : Observable<void>{
    return this.http.put<void>(`${this.url}/${userId}`, item).pipe(catchError(AppUtils.handleServiceError));
  }

  public getItemFromBasket(userId: string) : Observable<BasketItem[]>{
    return this.http.get<BasketItem[]>(`${this.url}/${userId}`).pipe(catchError(AppUtils.handleServiceError));
  }

  public clearBasket(userId: string) : Observable<void>{
    return this.http.delete<void>(`${this.url}/${userId}`).pipe(catchError(AppUtils.handleServiceError));
  }

  public deleteFromBasket(userId: string, itemId: string) : Observable<void>{
    return this.http.delete<void>(`${this.url}/${userId}/items/${itemId}`).pipe(catchError(AppUtils.handleServiceError));
  }
}
