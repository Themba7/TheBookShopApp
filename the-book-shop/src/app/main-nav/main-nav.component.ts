import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { UserManagerService } from '../services/user-manager/user-manager.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset).pipe(
    map(result => result.matches),
    shareReplay()
  );

  user: User = new User();

  get showProfile(): boolean {
    return !!this.user?.Email;
  }
  
  constructor(private breakpointObserver: BreakpointObserver, private router: Router, private userManagerService: UserManagerService) {
    this.userManagerService.user.subscribe(x => this.user = x);
  }

  signOut(): void {
    this.userManagerService.logout();
  }

  signIn(): void {
    this.router.navigate(['/user/login']);
  }

}
