import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { KeycloakAuthGuard } from 'keycloak-angular';
import { AuthGuard } from './auth.guard';
import { BasketComponent } from './components/basket/basket.component';
import { HomeComponent } from './components/home/home.component';
import { ProductComponent } from './components/product/product.component';

const routes: Routes = [
  // { path : '', component: HomeComponent, canActivate: [AuthGuard] },
  // { path : 'basket', component: BasketComponent, canActivate: [AuthGuard]},
  // { path : 'product', component: ProductComponent, canActivate: [AuthGuard]},
  // { path : 'product/:id', component: ProductComponent, canActivate: [AuthGuard]}
  { path : '', component: HomeComponent },
  { path : 'basket', component: BasketComponent },
  { path : 'product', component: ProductComponent},
  { path : 'product/:id', component: ProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
