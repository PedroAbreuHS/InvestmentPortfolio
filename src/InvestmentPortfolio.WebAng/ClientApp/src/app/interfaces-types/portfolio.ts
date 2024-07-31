import { Usuario } from './usuario';
export interface Portfolio {
  id?: string,
  nome: string,
  descricao: string,
  usuarioId: string,
  usuario: Usuario
}
