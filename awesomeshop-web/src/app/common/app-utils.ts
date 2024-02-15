import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';


export class AppUtils {
  
  
  static handleServiceError(err: HttpErrorResponse) {
      let errorMessage = '';
      if (err.error instanceof ErrorEvent) {
        errorMessage = `An error occured: ${err.error.message}`;
      } else {
        errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
      }
      console.error(errorMessage);
      return throwError(err);
    }
  
  
}
