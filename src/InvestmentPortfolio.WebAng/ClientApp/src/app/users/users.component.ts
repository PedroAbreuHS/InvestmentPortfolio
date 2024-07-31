import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {};
  userLogin: any = {};
  userLogged: any = {};
  showList: boolean = true;
  isAuthenticated: boolean = false;
  
  constructor(private userDataService: UserDataService, private router: Router){
  }

  ngOnInit() {
    
  }

  async get() {
    this.userDataService.get().toPromise().then((data: any[]) => {      
      this.users = data;
      this.showList = true;
    }, error => {
        console.log(error);
        alert('erro interno do sistema');
    })
  }

  save() {
    if (this.user.id) {
      this.put();
    } else {
      this.post();
    }    
  }

  openDetails(user) {
    this.showList = false;
    this.user = user;
  }

  post() {   
    this.userDataService.post(this.user).subscribe(data => {
      if (data) {
        alert('Usuário cadastrado com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao cadastrar usuário:')
      }
    }, error => {
      console.log(error);
      alert('Erro interno do sistema:'+ error.error);
    })
  }

  put() {
    this.userDataService.put(this.user).subscribe(data => {
      if (data) {
        alert('Usuário atualizado com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao atualizar usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  delete() {
    this.userDataService.delete().subscribe(data => {
      if (data) {
        alert('Usuário excluído com sucesso');
        this.get();
        this.user = {};
      } else {
        alert('Erro ao excluir usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  authenticate() {
    this.userDataService.authenticate(this.userLogin).toPromise().then((data: any) => {
      if (data) {
        localStorage.setItem('user_logged', JSON.stringify(data));        
        this.getUserData();
        this.router.navigate(['/']).then(() => {
          window.location.reload();
        });
      } else {
        alert('Usuário inválido.');
      }      
    }, error => {
      console.log(error);
      alert('Usuário inválido');
    })
  }

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.userLogged != null;
  }

}
