import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from './custom-modules/material/material.module';
import { NotifyService } from './services/notification/notify.service';
import { ApiRequestService } from './services/api/api-request.service';
import { DialogComponent, DialogService } from './services/dialog/dialog.service';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CatalogComponent } from './catalog/catalog.component';
import { AdminComponent } from './admin/admin.component';
import { PatronComponent } from './patron/patron.component';
import { SignUpComponent } from './patron/sign-up/sign-up.component';
import { SignInComponent } from './patron/sign-in/sign-in.component';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from './services/auth/auth.guard';
import { JwtModule } from '@auth0/angular-jwt';
import { UserManagerService } from './services/user-manager/user-manager.service';
import { SubscriptionComponent } from './subscription/subscription.component';
import { AccountComponent } from './account/account.component';


@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    HomeComponent,
    CatalogComponent,
    AdminComponent,
    PatronComponent,
    SignUpComponent,
    SignInComponent,
    SubscriptionComponent,
    AccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    MaterialModule,
    FlexLayoutModule,
    FormsModule,
    JwtModule.forRoot({})
  ],
  providers: [ 
    NotifyService, 
    ApiRequestService, 
    DialogService,
    AuthGuard,
    UserManagerService
  ],
  bootstrap: [AppComponent],
  entryComponents: [ DialogComponent ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AppModule { }
