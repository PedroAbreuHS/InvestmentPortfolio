import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PortfolioDataService } from '../_data-services/portfolio.data-service';
import { Portfolio } from '../interfaces-types/portfolio';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent implements OnInit {

  portfolios: any[] = [];
  portfolio: any = {};
  userLogin: any = {};
  userLogged: any = {};
  showList: boolean = false;
  isAuthenticated: boolean = false;

  constructor(private portfolioDataService: PortfolioDataService, private router: Router) {
  }

  ngOnInit() {
    this.getUserData();
    this.get();
  }

  async get() {
    return new Promise((resolve, reject) => {
      this.portfolioDataService.get().subscribe(res => {
        console.log('Resposta do serviço:', res);
        console.log('Tipo de res:', Array.isArray(res) ? 'Array' : 'Objeto');

        this.portfolios = Array.isArray(res) ? res : Object.values(res);

      }, error => {
        console.log(error);
        alert('erro interno do sistema');
        reject();
      })
    });
  }

  save() {
    if (this.portfolio.id) {
      this.put();
    } else {
      this.post();
    }
  }

  openDetails(portfolio) {
    this.showList = false;
    this.portfolio = portfolio;
  }

  post() {
    this.portfolioDataService.post(this.portfolio).subscribe(async data => {
      if (data) {
        alert('Portfólio cadastrado com sucesso');
        await this.get();
        this.portfolio = {};
        this.getUserData();
        if (this.portfolios.length >= 1)
          this.showList = true;

      } else {
        alert('Erro ao cadastrar Portfólio:')
      }
    }, error => {
      console.log(error);
      alert('Erro interno do sistema:' + error.error);
    })
  }

  put() {
    this.portfolioDataService.put(this.portfolio).subscribe(data => {
      if (data) {
        alert('Portfólio atualizado com sucesso');
        this.get();
        this.portfolio = {};
        this.getUserData();
      } else {
        alert('Erro ao atualizar Portfólio');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  delete() {
    this.portfolioDataService.delete().subscribe(data => {
      if (data) {
        alert('Portfólio excluído com sucesso');
        this.get();
        this.portfolio = {};
        this.getUserData();
      } else {
        alert('Erro ao excluir Portfólio');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.userLogged != null;

    this.portfolio.usuario = {
      nome: this.userLogged.nome,
      senha: this.userLogged.senha,
      email: this.userLogged.email,
      confirmarsenha: ''
    };
    this.portfolio.usuarioId = this.userLogged.id;
  }
}
