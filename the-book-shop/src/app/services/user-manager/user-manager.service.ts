import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { PatronSignIn } from 'src/app/models/patron-sign-in';
import { User } from 'src/app/models/user';
import { ApiRequestService } from '../api/api-request.service';
import { DialogService } from '../dialog/dialog.service';
import { NotifyService } from '../notification/notify.service';

@Injectable({
  providedIn: 'root'
})
export class UserManagerService {

  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;
  private jwtHelper = new JwtHelperService();

  constructor(private router: Router, 
    private apiRequestService: ApiRequestService,
    private notify: NotifyService,
    private dialogService: DialogService,
    private jwtHelperService: JwtHelperService) { 
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  async login(user: PatronSignIn): Promise<void> {
    let result = await this.apiRequestService.signIn(user);

    if (result.IsSuccess) {
      localStorage.setItem('token', result.Data.Token);
      localStorage.setItem('user', JSON.stringify(result.Data.User));

      this.userSubject.next(result.Data.User);

      this.notify.open(result.Message || 'Login successful', 'Success');
      this.router.navigate(['/home']);
    }
    else {
      this.dialogService.openDialog(result.Data.ErrorMessage || result.Message);
    }
  }

  logout(): void {
    localStorage.removeItem('user');
    this.userSubject.next(new User());
    this.router.navigate(['/login']);
  }

  isAuthorized(allowedRoles: string[]): boolean {
    if (allowedRoles == null || allowedRoles.length === 0) {
      return true;
    }

    const token = localStorage.getItem('token') || "";
    const decodedToken = this.jwtHelperService.decodeToken(token);

    if (!decodedToken) {
      return false;
    }
    
    return allowedRoles.includes(decodedToken['role']);
  }
}
