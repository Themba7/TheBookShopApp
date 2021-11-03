import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router'
import { PatronSignUp } from 'src/app/models/patron-sign-up';
import { ApiRequestService } from 'src/app/services/api/api-request.service';
import { DialogService } from 'src/app/services/dialog/dialog.service';
import { NotifyService } from 'src/app/services/notification/notify.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  constructor(private apiRequestService: ApiRequestService,
    private notify: NotifyService,
    private dialogService: DialogService) { }

  patron: PatronSignUp = new PatronSignUp();
  hidePassword: boolean = true;
  hidePasswordConfirm: boolean = true;

  ngOnInit(): void {
    this.resetFormState();
  }

  resetFormState(form?: NgForm): void {
    if (form) {
      this.patron = new PatronSignUp();
      form.resetForm();
    }
  }

  async onSubmit(form: NgForm): Promise<void> {
    let result = await this.apiRequestService.signUp(this.patron);

    if (result.IsSuccess) {
      this.notify.open(result.Message || 'Registration successful', 'Success');
      this.resetFormState(form);
    }
    else {
      let message = result.Data.Errors.find(e => e);
      this.dialogService.openDialog(message || result.Message);
    }
  }

}
