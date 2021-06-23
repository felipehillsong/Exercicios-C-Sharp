import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.css']
})
export class EventosComponent implements OnInit {
  
  constructor(
      private evenoService: EventoService
    , private modalService: BsModalService) { }

  nome = 'Felipe';
  eventos: Evento[];
  eventosFiltrados: Evento[];
  imageLargura = 50;
  imageMargem = 2;
  mostrarImagem = true;
  modalRef: BsModalRef;
  
  _filtroLista: string;  
  get filtroLista(): string{
    return this._filtroLista;
  }

  set filtroLista(value: string){
    this._filtroLista = value;
    var temas = this.filtrarEventos(this.filtroLista);
    var locais = this.filtrarLocal(this.filtroLista);
    var listaConcatenada = temas.concat(locais);

    var listaFinal = listaConcatenada.filter(function(e, i) {
      return listaConcatenada.indexOf(e) === i;
  });

    if(listaFinal != null){
      this.eventosFiltrados = listaFinal;
    }  
    else{
      this.eventosFiltrados = this.eventos;
    }  
  } 

  ngOnInit() {
    this.getEventos();    
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);

  }

  getEventos(){
      this.evenoService.getAllEvento().subscribe((_eventos: Evento[]) => {
      this.eventos =_eventos;
      this.eventosFiltrados = this.eventos;
    },
    error => {
      console.log(error);
    });
  }

  alternarImage(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  filtrarEventos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  filtrarLocal(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(evento => evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

}
