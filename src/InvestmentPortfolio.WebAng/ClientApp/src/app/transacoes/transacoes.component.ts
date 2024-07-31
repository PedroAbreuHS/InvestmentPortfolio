import { Component, OnInit } from '@angular/core';
import { TransacaoDataService } from '../_data-services/transacao.data-service';
import { Router } from '@angular/router';
import { PortfolioDataService } from '../_data-services/portfolio.data-service';
import { AtivoDataService } from '../_data-services/ativo.data-service';
import { Transacao } from '../interfaces-types/transacao';
import { Ativo } from '../interfaces-types/ativo';
import { Portfolio } from '../interfaces-types/portfolio';

@Component({
  selector: 'app-transacoes',
  templateUrl: './transacoes.component.html',
  styleUrls: ['./transacoes.component.css']
})

export class TransacoesComponent implements OnInit {
  
  transacoes: Array<Transacao>;
  transacao: any = {};
  userLogin: any = {};
  userLogged: any = {};
  showList: boolean = true;
  isAuthenticated: boolean = false;
  portfolios: Array<Portfolio>;
  ativos: any[] = [
    {
      id:'1',
      nome: 'Bitcoin',
      tipoAtivo: 3,
      codigo: 2      
    },
    {
      id:'2',
      nome: 'Acao',
      tipoAtivo: 1,
      codigo: 1
    },
    {
      id:'3',
      nome: 'Titulo',
      tipoAtivo: 2,
      codigo: 1
    }
  ]
  tipoTransacao: any[] = [
    {
      id:1,
      descricao:'Compra',
    },
    {
      id: 2,
      descricao:'Venda'
    }
  ]

  constructor(private transacaoDataService: TransacaoDataService,
    private portfolioDataService: PortfolioDataService,
    private ativoDataService: AtivoDataService,
    private router: Router) {
  }
  
  ngOnInit(){
      this.getAtivos();
      this.getPortfolios();
  }

  get() {
    return new Promise((resolve, reject) => {
      this.transacaoDataService.get().subscribe((data: any[]) => {
        this.transacao = data;
        this.showList = true;
      }, error => {
        console.log(error);
        alert('erro interno do sistema');
        reject();
      })
    });
  }

  save() {
    if (this.transacao.id) {
      this.put();
    } else {
      this.post();
    }
  }

  openDetails(portfolio) {
    this.showList = false;
    this.transacao = portfolio;
  }

  post() {
    this.transacaoDataService.post(this.transacao).subscribe(async data => {
      if (data) {
        alert('Portfólio cadastrado com sucesso');
        await this.get();
        this.transacao = {};
        this.getUserData();
        if (this.transacao.length >= 1)
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
    this.transacaoDataService.put(this.transacao).subscribe(data => {
      if (data) {
        alert('Portfólio atualizado com sucesso');
        this.get();
        this.transacao = {};
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
    this.transacaoDataService.delete().subscribe(data => {
      if (data) {
        alert('Portfólio excluído com sucesso');
        this.get();
        this.transacao = {};
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

    this.transacao.usuario = {
      nome: this.userLogged.nome,
      senha: this.userLogged.senha,
      email: this.userLogged.email,
      confirmarsenha: ''
    };
    this.transacao.usuarioId = this.userLogged.id;
  }

  getAtivos() {
    this.ativoDataService.get().subscribe((data: any[]) => {      
      this.ativos = data;
      }, error => {
        console.log(error);
        alert('erro interno do sistema');
    });
  }

  getPortfolios() {
    this.portfolioDataService.get().subscribe((data: any[]) => {
        this.portfolios = data;
    }, error => {
        console.log(error);
        alert('erro interno do sistema');
    });
  }
}
