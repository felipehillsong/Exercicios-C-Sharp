import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Eventos',
  templateUrl: './Eventos.component.html',
  styleUrls: ['./Eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [
    {
      Tema: 'Angular',
      Local: 'Belo Horizonte'
    },
    {
      Tema: '.NET 5',
      Local: 'São Paulo'
    },
    {
      Tema: 'Java',
      Local: 'Rio de Janeiro'
    }
  ]
  constructor() { }

  ngOnInit() {
  }

}
