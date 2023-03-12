import {Component, Input, OnInit} from '@angular/core';
import {StudentiComponent} from "../studenti/studenti.component";

@Component({
  selector: 'app-srijeda',
  templateUrl: './srijeda.component.html',
  styleUrls: ['./srijeda.component.css']
})
export class SrijedaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  @Input()
  public nesto?: StudentiComponent | null;
}
