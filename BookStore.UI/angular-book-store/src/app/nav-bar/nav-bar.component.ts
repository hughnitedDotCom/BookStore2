import { Component, Input, OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatMenuTrigger } from '@angular/material/menu';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  @ViewChild('menuTrigger') menuTrigger: MatMenuTrigger;

  @Input('title') title: string;

  user: string = "Guest";


  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  // let dialogRef = dialog.open(UserProfileComponent, {
  //   height: '400px',
  //   width: '600px',
  // });

  openDialog() {
    const dialogRef = this.dialog.open(RegisterComponent, { width: "400px", restoreFocus: false});

    // Manually restore focus to the menu trigger since the element that
    // opens the dialog won't be in the DOM any more when the dialog closes.
    dialogRef.afterClosed().subscribe(() => this.menuTrigger.focus());
  }

}
