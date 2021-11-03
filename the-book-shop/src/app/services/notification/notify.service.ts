import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

export type messageType = 'Error' | 'Success' | 'Info' | 'Warning';

@Injectable({
  providedIn: 'root'
})
export class NotifyService {
  
  constructor(private snackBar: MatSnackBar) { }

  color: string = "";

  open(message: string, messageType: messageType = 'Info', dismissText: string = 'Close', durationInSeconds: number = 3) {

    //blue-snackbar
    switch (messageType) {
      case "Error":
        this.color = 'custom-red';
        break;
      case "Success":
        this.color = 'custom-green';
        break;
      case "Info":
        this.color = 'custom-blue';
        break;
      case "Warning":
        this.color = 'custom-orange';
        break;
      default:
        this.color = 'custom-blue';
      break;
    }

    this.snackBar.open(message, dismissText, {
      duration: (durationInSeconds * 1000),
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: [ this.color ]
    });
  }

  
}
