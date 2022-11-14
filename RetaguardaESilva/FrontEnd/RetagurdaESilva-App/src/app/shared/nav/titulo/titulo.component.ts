import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { TituloService } from 'src/app/services/titulo.service';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo!: string;
  @Input() iconClass!: string;
  @Input() novo!: string;

  constructor(public titu: TituloService) { }

  ngOnInit() {
  }

}
