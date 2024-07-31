import { Portfolio } from './portfolio';
import { Ativo } from './ativo';
export interface Transacao {
  id?: string,
  nome: string,
  portfolioId: string,
  portfolio: Portfolio,
  ativoId: string,
  ativo: Ativo,
  preco:string,
  quantidade: number,
  dataTransacao:Date
}
