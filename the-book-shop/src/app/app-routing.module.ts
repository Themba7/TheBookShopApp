import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { AuthGuard } from './services/auth/auth.guard';
import { CatalogComponent } from './catalog/catalog.component';
import { HomeComponent } from './home/home.component';
import { PatronComponent } from './patron/patron.component';
import { Role } from './models/role';
import { SubscriptionComponent } from './subscription/subscription.component';
import { AccountComponent } from './account/account.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'catalog', component: CatalogComponent },
  { path: 'admin', component: AdminComponent }, //data: { allowedRoles: [ Role.Admin ] }, canActivate: [AuthGuard] },
  { path: 'user/login', component: PatronComponent },
  { path: 'subscribe/book/:id', component: SubscriptionComponent },
  { path: 'account', component: AccountComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
