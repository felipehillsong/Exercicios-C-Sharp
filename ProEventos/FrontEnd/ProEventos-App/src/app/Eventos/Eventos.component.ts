import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  larguraImagem = 100;
  margemImagem = 2;
  mostrarImagem = true;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  public getEventos(): void{
    this.http.get('https://localhost:44308/api/Eventos').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }

  alternarImage(){
    this.mostrarImagem = !this.mostrarImagem;
  }

}
