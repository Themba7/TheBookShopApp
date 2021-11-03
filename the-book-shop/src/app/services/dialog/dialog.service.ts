import { Component, Inject, Injectable } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogServiceData } from 'src/app/models/dialog-service-data';

@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(public dialog: MatDialog) { }

  errorMessage: string = 'Oops, something went wrong with the server.'
  headerText: string = 'Error Encounter';

  openDialog(message: string = '', header: string = '') {
    this.dialog.open(DialogComponent, {
      data: { message: message || this.errorMessage, header: header || this.headerText },
      restoreFocus: true
    });
  }
}

@Component({
  selector: 'app-modal-dialog',
  template: `<h2 mat-dialog-title>{{data.header}}</h2> 
  <div mat-dialog-content>{{data.message}}</div>`
})
export class DialogComponent {
  constructor(public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogServiceData
  ) {}
}
