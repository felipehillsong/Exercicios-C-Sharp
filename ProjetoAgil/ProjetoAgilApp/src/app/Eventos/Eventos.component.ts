import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.css']
})
export class EventosComponent implements OnInit {

  constructor(private http: HttpClient) { }

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

  _filtroLocal: string;    
  get filtroLocal() : string {
    return this._filtroLocal;
  }
  set filtroLocal(value : string) {
    this._filtroLocal = value;
  }
  

  nome = 'Felipe';
  eventos: any = [];
  eventosFiltrados: any = [];
  imageLargura = 50;
  imageMargem = 2;
  mostrarImage = true;  

  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    this.eventos = this.http.get('https://localhost:44395/api/values').subscribe(Response => {
      this.eventosFiltrados = this.eventos = Response;            
    },
    error => {
      console.log(error);
    });
  }

  alternarImage(){
    this.mostrarImage = !this.mostrarImage;
  }

  filtrarEventos(filtrarPor: string): any{
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
