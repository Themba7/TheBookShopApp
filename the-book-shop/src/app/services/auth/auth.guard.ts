import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { UserManagerService } from '../user-manager/user-manager.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  constructor(private router: Router, private userManagementService: UserManagerService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean { 
    const allowedRoles = route.data.allowedRoles;
    const isAuthorized = this.userManagementService.isAuthorized(allowedRoles);

    if (!isAuthorized) {
      this.router.navigate(['/home']);
    } 
    
    return isAuthorized;
  }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const allowedRoles = childRoute.data.allowedRoles;
    const isAuthorized = this.userManagementService.isAuthorized(allowedRoles);

    if (!isAuthorized) {
      this.router.navigate(['/home']);
    }

    return isAuthorized;
  }
}
