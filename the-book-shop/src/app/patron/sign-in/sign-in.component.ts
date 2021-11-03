import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PatronSignIn } from 'src/app/models/patron-sign-in';
import { UserManagerService } from 'src/app/services/user-manager/user-manager.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {

  constructor(private userManagerService: UserManagerService) { }

  patron: PatronSignIn = new PatronSignIn();
  hidePassword: boolean = true;

  ngOnInit(): void {
    this.resetFormState();
    this.patron.userName = 'admin@thebookshop.co.za';
    this.patron.password = 'Admin123*';
  }

  resetFormState(form?: NgForm): void {
    if (form) {
      this.patron = new PatronSignIn();
      form.resetForm();
    }
  }

  onSubmit(form: NgForm): void {
    this.userManagerService.login(this.patron || form.value);
  }

}
