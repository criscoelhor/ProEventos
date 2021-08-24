import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public events: any = [];
  public filteredEvents: any = [];
  widthImg = 100;
  marginImg = 2;
  showImg = true;
  private _filter: string = '';

  public get filter(){
    return this._filter;
  }

  public set filter(value){
    this._filter = value;
    this.filteredEvents = this.filter ? this.filterEvents(this.filter) : this.events;
  }

  filterEvents(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (evento : any) => evento.tema.toLocaleLowerCase().indexOf(filterBy) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit():void {
    this.getEventos();
  }

  showImage(){
    this.showImg = !this.showImg;
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.events = response,
        this.filteredEvents = this.events
      },
      error => console.log(error)
    );
  }
}
