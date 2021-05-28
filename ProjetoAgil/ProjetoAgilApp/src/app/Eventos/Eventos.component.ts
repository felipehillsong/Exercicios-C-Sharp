import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.css']
})
export class EventosComponent implements OnInit {

  constructor(private http: HttpClient) { }

  nome = 'Felipe';
  eventos: any = [];
  imageLargura = 50;
  imageMargem = 2;
  mostrarImage = false;
  filtroLista = "";

  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    this.eventos = this.http.get('https://localhost:44395/api/values').subscribe(Response => {
      this.eventos = Response;            
    },
    error => {
      console.log(error);
    });
  }

  alternarImage(){
    this.mostrarImage = !this.mostrarImage;
  }

}
