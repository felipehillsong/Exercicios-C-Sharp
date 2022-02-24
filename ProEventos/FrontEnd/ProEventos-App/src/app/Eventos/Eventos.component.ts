import { Component, OnInit } from '@angular/core';
import { Evento } from '../Models/Evento';
import { EventoService } from '../Services/Evento.Service';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public larguraImagem = 100;
  public margemImagem = 2;
  public mostrarImagem = true;
  private _filtroListado = '';

  public get filtroLista():string{
    return this._filtroListado;
  }

  public set filtroLista(value:string){
    this._filtroListado = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor:string):Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private eventoServices: EventoService) { }

  public ngOnInit() {
    this.getEventos();
  }

  public getEventos(): void{
    this.eventoServices.getEventos().subscribe(
      (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error)
    );
  }

  public alternarImage(): void{
    this.mostrarImagem = !this.mostrarImagem;
  }

}
