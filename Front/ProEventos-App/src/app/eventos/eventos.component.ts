import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
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
      Tema: 'Angular e Novidades',
      Local: 'Rio de janeiro'
    }
  ]

  constructor() { }

  ngOnInit() {
  }

}
