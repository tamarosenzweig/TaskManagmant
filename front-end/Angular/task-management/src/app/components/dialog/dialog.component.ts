import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

export interface DialogData {
  title: string;
  msg: string;
  autoClosing:boolean;
}

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent{

   //----------------CONSTRUCTOR------------------

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { 
      if(this.data.autoClosing)
      setTimeout(() => {
        this.close();
      }, 10000);
    }

  //----------------METHODS------------------

  close() {
    this.dialogRef.close();
  }

}


