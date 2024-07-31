import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit{
  isExpanded = false;
  isAuthenticated: boolean = false;
  userLogged: any = {};

  constructor(private router: Router) {
  }

  ngOnInit(){
    this.getUserData();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.userLogged != null;
  }

  logout() {
    localStorage.removeItem('user_logged');
    this.userLogged = null;
    this.isAuthenticated = null;
    this.router.navigate(['/']).then(() => {
      window.location.reload();
    });
  }
}
