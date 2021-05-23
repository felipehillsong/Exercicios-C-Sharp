import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.css']
})
export class EventosComponent implements OnInit {

  nome: string = 'Felipe';
  eventos: any = [
    {
      EventoId: 1,
      Tema: "Angular",
      Local: "Belo Horizonte"
    },

    {
      EventoId: 2,
      Tema: ".Net Core",
      Local: "São Paulo"
    },

    {
      EventoId: 3,
      Tema: "Angulo e .Net Core",
      Local: "Rio de Janeiro"
    }
  ];

  constructor() { }

  ngOnInit() {
  }

}
