import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UserDataService } from './_data-services/user.data-service';
import { Interceptor } from './app.interceptor.module';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { PortfolioDataService } from './_data-services/portfolio.data-service';
import { TransacoesComponent } from './transacoes/transacoes.component';
import { TransacaoDataService } from './_data-services/transacao.data-service';
import { AtivoDataService } from './_data-services/ativo.data-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
    PortfolioComponent,
    TransacoesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent },
      { path: 'portfolio', component: PortfolioComponent },
      { path: 'transacoes', component: TransacoesComponent }
    ]),
    Interceptor
  ],
  providers: [UserDataService, PortfolioDataService, TransacaoDataService, AtivoDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
